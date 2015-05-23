using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {
	public HingeJoint attach;
	public Rigidbody on;
	public Rigidbody off;
	public bool state= false;
	// Use this for initialization
	void Start () {
		if (state)
			attach.connectedBody = on;
		else {
			attach.connectedBody = off;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Switch")
			state = !state;
		if (state)
			attach.connectedBody = on;
		else {
			attach.connectedBody = off;
		}
	}
}
