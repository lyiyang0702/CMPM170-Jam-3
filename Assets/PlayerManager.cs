using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //public GameObject player;
    public List<GameObject> Players = new List<GameObject>();

    public GameObject CurrentPlayer;

    public bool _isSwitched = false;

    private void Start()
    {
        for (int i = 1; i < Players.Count; i++)
        {
            Players[i].GetComponent<PlayerMovement>().enabled = false;
        }

        CurrentPlayer = Players[0];
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isSwitched = true;
            return;
        }
        ChangePlayer();
        
    }

    void ChangePlayer()
    {
        if (_isSwitched)
        {
            GameObject oldPlayer = CurrentPlayer;
            CurrentPlayer.GetComponent<PlayerMovement>().enabled = false;
            Players.Remove(oldPlayer);
            CurrentPlayer = Players[0];
            Players.Add(oldPlayer);
            CurrentPlayer.GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("current player is " + CurrentPlayer.name);


            // reload UI
            InventoryUI.instance.ReloadUI(CurrentPlayer);
        }
        _isSwitched=false;
    }

}
