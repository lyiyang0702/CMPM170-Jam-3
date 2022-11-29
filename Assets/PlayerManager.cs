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

    private void FixedUpdate()
    {
        //Players[1].transform.position = Vector3.MoveTowards(CurrentPlayer.transform.position + new Vector3(-1,1, 0), Players[1].transform.position, 3f * Time.deltaTime);
        //Players[2].transform.position = Vector3.MoveTowards(CurrentPlayer.transform.position + new Vector3(1, 1, 0), Players[2].transform.position, 3f * Time.deltaTime);
    }
    void ChangePlayer()
    {
        if (_isSwitched)
        {
            GameObject oldPlayer = CurrentPlayer;
            CurrentPlayer.GetComponent<PlayerMovement>().enabled = false;
            //CurrentPlayer.GetComponent<PlayerController>().enabled = true;
            Players.Remove(oldPlayer);
            //Change Current player to next player in the list
            CurrentPlayer = Players[0];
            Players.Add(oldPlayer);
            CurrentPlayer.GetComponent<PlayerMovement>().enabled = true;
            //CurrentPlayer.GetComponent<PlayerController>().enabled = false;
            Debug.Log("current player is " + CurrentPlayer.name);


            // reload UI
            InventoryUI.instance.ReloadUI(CurrentPlayer);
        }
        _isSwitched = false;
    }


}
