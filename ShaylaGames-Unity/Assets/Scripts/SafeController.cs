using UnityEngine;
using System.Collections;

public class SafeController : MonoBehaviour {
	public int[] sequence;
	private int[] enteredSequence;
	private int pos= 0;
	//private bool unlocked = false;
	// Use this for initialization
	void Start () {
		enteredSequence = new int[sequence.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enter(int number){

		if (pos == sequence.Length-1) {
			for (int i = 0; i<sequence.Length-1; i++) {
				enteredSequence [i] = enteredSequence [i + 1];
			}
		} else {
			pos++;//count up until last element and stop
		}
		enteredSequence [pos] = number;
		Debug.Log ("printSequence :");
		for (int i = 0; i <sequence.Length; i++) {
			Debug.Log (enteredSequence [i]);
		}
		//compare
		for (int i = 0; i <sequence.Length; i++) {
			if (enteredSequence [i] != sequence [i])
				break;
			if (i == sequence.Length-1)
				Unlock ();
		}

	}

	private void Unlock()
	{
		Debug.Log ("Unlock!!!!!!!!!!!!!!!!!!!!!!!");
	}
}
