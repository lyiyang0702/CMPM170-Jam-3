using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour
{
    public string tipToShow;
    private float timeToWait = 0.5f;


    public void OnPointerEnter(PointerEventData eventData){
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }
     public void OnPointerExit(PointerEventData eventData){
        StopAllCoroutines();
        Debug.Log("Exited");
    }
    private void ShowMessage(){
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }
    private IEnumerator StartTimer(){
        yield return new WaitForSeconds(timeToWait);
        ShowMessage();
    }
}

