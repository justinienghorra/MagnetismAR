using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void GoHome() {
		SceneManager.LoadScene("menu", LoadSceneMode.Single);
	}
	
	public void GoLevel() {
		SceneManager.LoadScene("projet", LoadSceneMode.Single);
	}
}
