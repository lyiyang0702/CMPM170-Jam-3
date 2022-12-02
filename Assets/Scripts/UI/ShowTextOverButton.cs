using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOverButton : MonoBehaviour
{
    public GameObject UItext;

    
    [SerializeField]
	protected GameObject unit;
    public void Start()
    {
        Debug.Log("Highlight Text");
        UItext.SetActive(false);
        //UIImage.SetActive(false);
    }

    public void OnMouseOver(){
          Debug.Log("Mouse Over Button Text");
        UItext.SetActive(true);
        //UIImage.SetActive(true);
    }

    public void OnMouseExit()
    {
        UItext.SetActive(false);
        //UIImage.SetActive(false);
    }
}
