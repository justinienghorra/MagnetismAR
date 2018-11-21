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
				
				Vector3 posK = key.transform.position;
				if (posK.x > 2){
					key.transform.position -= new Vector3(0.005f, 0, 0);
				}	
			}
		}
	}
}
