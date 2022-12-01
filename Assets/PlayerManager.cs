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
    public GameObject currentPlayerUnit;
    public bool _isSwitched = false;
    GameObject[] playerUnits;
    [SerializeField]
    float distance;
    private void Start()
    {
        for (int i = 1; i < Players.Count; i++)
        {
            DisablePlayer(Players[i]);
        }

        CurrentPlayer = Players[0];

        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        CheckCurrentPlayerInBattle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isSwitched = true;
            return;
        }
        ChangePlayer();

        for (int i = 1; i < Players.Count; i++)
        {
            PlayerKeepDistance(Players[i]);
        }

        
    }

    void ChangePlayer()
    {
        if (_isSwitched)
        {
            GameObject oldPlayer = CurrentPlayer;
            DisablePlayer(oldPlayer);
            Players.Remove(oldPlayer);
            //Change Current player to next player in the list
            CurrentPlayer = Players[0];
            Players.Add(oldPlayer);
            EnablePlayer(CurrentPlayer);
            Debug.Log("current player is " + CurrentPlayer.name);

            CheckCurrentPlayerInBattle();
            // reload UI
            InventoryUI.instance.ReloadUI(currentPlayerUnit);
        }
        _isSwitched = false;
    }

    void DisablePlayer(GameObject player)
    {
        if (player)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void EnablePlayer(GameObject player)
    {
        if (player)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    void PlayerKeepDistance(GameObject player)
    {
        if (player)
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

    void CheckCurrentPlayerInBattle()
    {
        foreach (GameObject playerUnit in playerUnits)
        {

            if (playerUnit.name == CurrentPlayer.name)
            {
                currentPlayerUnit = playerUnit;
            }
        }

    }
}