using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

	public GameObject magnetDefault;
	
	public GameObject barDefault;
	
	public GameObject fran;
	public GameObject magnetFran;
	public GameObject barFran;
	
	public GameObject key;
	
	public float franToMagnet, franToBar;
	
	public bool gotMagnet, gotBar;
	
	//public Text test;

	// Use this for initialization
	void Start () {
		gotMagnet = false;
		gotBar = false;
		magnetFran.SetActive(false);
		barFran.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posF = fran.transform.position;	
		Vector3 posM = magnetDefault.transform.position;
		Vector3 posB = barDefault.transform.position;
		
		franToMagnet = Vector3.Distance(posM, posF);
		franToBar = Vector3.Distance(posB, posF);
		
		if (gotMagnet || franToMagnet < 1.7) {
			gotMagnet = true;
			magnetFran.SetActive(true);
			magnetDefault.SetActive(false);
			
			if (gotBar || franToBar < 1.7) {
				gotBar = true;
				barFran.SetActive(true);
				barDefault.SetActive(false);
				
				Vector3 posK = key.transform.localPosition;
				//test.text = key.transform.localPosition.x.ToString("R");
				if (posK.x > 1.97F){
					key.transform.localPosition = new Vector3(posK.x - 0.02F, posK.y, posK.z);
				}	
			}
		}
	}
}
