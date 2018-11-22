using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Help : MonoBehaviour, Vuforia.ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	
	public GameObject sparks;

	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		
		sparks.SetActive(false);
	}
	
	public void OnTrackableStateChanged (TrackableBehaviour.Status newStatus) {
        OnTrackableStateChanged (default(TrackableBehaviour.Status), newStatus);
    }
	
	public void OnTrackableStateChanged(
         TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
         if (newStatus == TrackableBehaviour.Status.DETECTED ||
             newStatus == TrackableBehaviour.Status.TRACKED ||
             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
            sparks.SetActive(true);
        } else {
			sparks.SetActive(false);
		}
    }  
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
