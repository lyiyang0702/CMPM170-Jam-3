using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFanBar : MonoBehaviour
{
    [SerializeField]
	protected GameObject unit;

    [SerializeField]
	private float maxValue;

    [SerializeField]
	private float tracker;
	private Vector2 initialScale;

	void Start() {
		this.initialScale = this.gameObject.transform.localScale;
	}
    // Update is called once per frame
    void Update()
    {
        GameObject FanBar = GameObject.Find("FanBar");
		UnitStats CurrentHealth = FanBar.GetComponent<UnitStats> ();
		tracker = CurrentHealth.returnHealth();
        Debug.Log("Tracker Test 2:" + tracker);
    
        
    }
}
