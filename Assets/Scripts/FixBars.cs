using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	

public class FixBars : MonoBehaviour {


	public GameObject bigBar;
	public GameObject smallBar;
	public bool attracted;
	
	public Vector3 posB;
	public Vector3 posS;
	public Vector3 eulB;
	
	// Use this for initialization
	void Start () {
		attracted = false;
	}
	
	// Update is called once per frame
	void Update () {
		posB = bigBar.transform.position;
		posS = smallBar.transform.position;
		
		if (attracted || Vector3.Distance(posB, posS) < 1.5) {
			attracted = true;
			
			eulB = bigBar.transform.eulerAngles;
			smallBar.transform.position = new Vector3(posB.x+3, posB.y, posB.z);
			smallBar.transform.eulerAngles = new Vector3(eulB.x, eulB.y, eulB.z);
		
		}
	}
}
