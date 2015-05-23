using UnityEngine;
using System.Collections;

public class SafeNumber : MonoBehaviour {

	public SafeController safe;
	public int Number = 1;
	public float duration = 1.0f;
	// Use this for initialization
	void Start () {
		if (safe == null)
			Debug.LogError ("Set the dial object on "+this.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("startTimer for number "+ Number);
		if (other.tag == "Dial") {
			Debug.Log ("startTimer for number "+ Number);
			StartCoroutine ("Timer");
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Dial") {
			Debug.Log ("stop Timer for number "+ Number);
			StopAllCoroutines ();
		}
	}

	//private float startTime = float.MinValue;

	private IEnumerator Timer(){			
					yield return new WaitForSeconds (duration); 
		safe.Enter (Number);
	}



}


