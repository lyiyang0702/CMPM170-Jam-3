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
    [SerializeField]
    Inventory inventory;
    InventorySlot[] slots;
    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    private void FixedUpdate()
    {
        //inventory = PlayerManager.instance.currentPlayerUnit.GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;
    }
    public void ReloadUI(GameObject CurrentPlayer)
    {
        inventory = CurrentPlayer.GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;
        Debug.Log(CurrentPlayer.name);
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
