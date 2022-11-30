using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassInventory : MonoBehaviour
{
    GameObject playerParty;
    // Start is called before the first frame update
    void Start()
    {
        playerParty = GameObject.Find("PlayerParty");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
