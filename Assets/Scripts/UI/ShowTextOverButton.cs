using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOverButton : MonoBehaviour
{
    public GameObject UItext;
    public void Start()
    {
        UItext.SetActive(false);
    }

    public void OnMouseOver(){
        UItext.SetActive(true);
    }
}
