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

    [SerializeField]
    float distance;

    private void Update()
    {

        for (int i = 1; i < Players.Count; i++)
        {
            PlayerKeepDistance(Players[i]);
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
}