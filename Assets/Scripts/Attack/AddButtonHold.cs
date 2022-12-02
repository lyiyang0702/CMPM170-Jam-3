using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

//AddButtonCallBack is a script used for making a button have  
public class AddButtonHold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	private bool mouse_over = false;
	[SerializeField] private GameObject UItext;
	[SerializeField] private GameObject UItext2;
	[SerializeField] private GameObject UItext3;
	[SerializeField] private GameObject UItext4;
	[SerializeField] private GameObject UItext5;
	[SerializeField] private GameObject UItext6;

	[SerializeField] private GameObject TextBox;

	private SFXManager sfxMan;

	void Start()
	{
		sfxMan = FindObjectOfType<SFXManager>();
	}

	void Update()
    {
		
		int Element = checkElement();
        if (mouse_over)
         {
            Debug.Log("Mouse Over");
			if (Element == 0){
				Debug.Log("Fire Element");
				UItext.SetActive(true);

			 }
			 else if(Element == 1){
				UItext2.SetActive(true);
				Debug.Log("Wind Element");

			 }
			  else if(Element == 2){
				UItext3.SetActive(true);
				Debug.Log("Ice Element");

			 }
			else if(Element == 3){
				UItext4.SetActive(true);
				Debug.Log("Water Element");

			 }
			  else if(Element == 4){
				UItext5.SetActive(true);
				Debug.Log("Earth Element");
			 }
			 else if(Element == 5){
				UItext5.SetActive(true);
				Debug.Log("Thunder Element");

			 }
			 TextBox.SetActive(true);
			 
         }
     }
 
     public void OnPointerEnter(PointerEventData eventData)
     {
         mouse_over = true;
         Debug.Log("Mouse enter");
	 } 
 
     public void OnPointerExit(PointerEventData eventData)
     {
         mouse_over = false;
         Debug.Log("Mouse exit");
		 sfxMan.Dequip.Play();
		 UItext.SetActive(false);
		 UItext2.SetActive(false);
		 UItext3.SetActive(false);
		 UItext4.SetActive(false);
		 UItext5.SetActive(false);
		 UItext6.SetActive(false);
		 TextBox.SetActive(false);
     }

	 private int checkElement() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		return playerParty.GetComponent<SelectUnit> ().returnElement();
	}
 }
