using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

	public GameObject key;
	public GameObject fran;
	public float distance;
	
	public Text testText;

	// Use this for initialization
	void Start () {
		testText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posS = key.transform.position;
		Vector3 posC = fran.transform.position;	
		distance = Vector3.Distance(posS, posC);
		if (Vector3.Distance(posS, posC) < 1) {
			testText.text = "Found !";
		} else {
			testText.text = "";	
		}
	}
}
