using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Singleton
    public static InventoryUI instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Transform itemsParent;
    public GameObject inventoryUI;

    public Inventory inventory;
    [SerializeField]
    InventorySlot[] slots;

    private void Start()
    {
        //inventory = PlayerManager.instance.Players[0].GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void ReloadUI(GameObject CurrentPlayer)
    {
        inventory = CurrentPlayer.GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;

        UpdateUI();
    }
    void UpdateUI()
    {
        Debug.Log("Updating UI");
        // Loop through all the slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                // Otherwise clear the slot
                slots[i].RemoveItem();
            }
        }
    }
}
