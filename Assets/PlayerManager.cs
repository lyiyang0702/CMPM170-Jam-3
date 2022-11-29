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
            Players[i].GetComponent<PlayerController>().enabled = false;
        }

        CurrentPlayer = Players[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
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
            CurrentPlayer.GetComponent<PlayerController>().enabled = false;
            Players.Remove(oldPlayer);
            CurrentPlayer = Players[0];
            Players.Add(oldPlayer);
            CurrentPlayer.GetComponent<PlayerController>().enabled = true;
            Debug.Log("current player is " + CurrentPlayer.name);


            // reload UI
            InventoryUI.instance.ReloadUI(CurrentPlayer);
        }
        _isSwitched=false;
    }

    void DisablePlayer(GameObject player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
    }

    void EnablePlayer(GameObject player)
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
    void PlayerKeepDistance(GameObject player)
    {
        for (int i = 0; i < Players.Count; i++)
        {
            if (player != Players[i])
            {
                player.transform.position = (player.transform.position - Players[i].transform.position).normalized * distance + Players[i].transform.position;
            }
        }
    }
}
