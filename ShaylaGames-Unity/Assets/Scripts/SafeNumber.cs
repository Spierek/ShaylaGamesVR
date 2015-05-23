using UnityEngine;
using System.Collections;

public class SafeNumber : MonoBehaviour {

	public Transform Dial;

	// Use this for initialization
	void Start () {
		if (Dial == null)
			Debug.LogError ("Set the dial object");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Dial") {
			Debug.Log ("startTimer");
			StartCoroutine ("Timer");
		}
	}

	//private float startTime = float.MinValue;
	public float duration = 1.0f;
	private IEnumerator Performance(){			
					yield return new WaitForEndOfFrame (); 
			}



}


