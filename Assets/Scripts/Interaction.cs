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
	
	private bool gotMagnet, gotBar;
	
	private bool success, jump;
	private int jumpCount;
	
	private bool barAttracted, keyAttracted;

	IEnumerator TimerKey() {
		yield return new WaitForSeconds(1.0f);
		keyAttracted = true;
	}
	
	IEnumerator TimerBar() {
		yield return new WaitForSeconds(0.5f);
		barAttracted = true;
	}

	void Start () {
		gotMagnet = false;
		gotBar = false;
		success = false;
		
		barAttracted = false;
		keyAttracted = false;
		
		magnetFran.SetActive(false);
		barFran.SetActive(false);
		
		jump = false;
		jumpCount = 0;
	}
	
	void Update () {
		Vector3 posF = fran.transform.position;	
		Vector3 posM = magnetDefault.transform.position;
		Vector3 posB = barDefault.transform.position;
		
		franToMagnet = Vector3.Distance(posM, posF);
		franToBar = Vector3.Distance(posB, posF);
		
		if(success) {
			if(posF.y < -3.46) {
				fran.transform.position = new Vector3(posF.x-0.008f, posF.y+0.02f, posF.z);
			} else if(jumpCount < 10) {
				if(!jump && posF.z < 1.355f) {
					fran.transform.position = new Vector3(posF.x, posF.y, posF.z+0.005f);
				} else {
					if(posF.z > 1.345f) {
						jump = true;
						fran.transform.position = new Vector3(posF.x, posF.y, posF.z-0.005f);
					} else {
						jump = false;
						jumpCount++;
					}
				}
			}
		} else if (!success && (gotMagnet || franToMagnet < 2.4)) {
			gotMagnet = true;
			magnetFran.SetActive(true);
			magnetDefault.SetActive(false);
			
			if (gotBar || franToBar < 2.3) {
				gotBar = true;
				barFran.SetActive(true);
				barDefault.SetActive(false);
				
				if(!barAttracted) {
					StartCoroutine(TimerBar());
				} else {
					Vector3 posK = key.transform.localPosition;
					Vector3 rotK = key.transform.eulerAngles;
					
					if (posK.x > 3.3f){
						key.transform.localPosition = new Vector3(posK.x - 0.0225f, posK.y, posK.z + 0.01f);
						key.transform.eulerAngles = new Vector3(rotK.x, rotK.y - 2, rotK.z);
					} else {
						if(!keyAttracted) {
							StartCoroutine(TimerKey());
						} else {
							key.SetActive(false);
							barFran.SetActive(false);
							magnetFran.SetActive(false);
							if (posF.y > -5.0f && !success) {
								fran.transform.position = new Vector3(posF.x, posF.y-0.02f, posF.z);
							} else if(!success) {
								success = true;
								Vector3 localPosF = fran.transform.localPosition;
								fran.transform.localPosition = new Vector3(4.7f, localPosF.y, localPosF.z);
							}
						}
					}
				}				
			}
		}
	}
}
