using UnityEngine;
using System.Collections;

public class SafeController : MonoBehaviour {
	public int[] sequence;
	public Transform[] Numbers;
	private int[] enteredSequence;
	private int pos= -1;
	//private bool unlocked = false;
	// Use this for initialization
	void Start () {
		enteredSequence = new int[sequence.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enter(int number){
		if (number == 0)
			return;
		Debug.Log("entered n: " + number );
		Numbers[number-1].localScale*=1.2f;
		if (pos == sequence.Length-1) {
			Debug.Log("nteredSequence [0] n: " + enteredSequence [0]);
			Numbers[enteredSequence [0]-1].localScale/=1.2f;
			for (int i = 0; i<sequence.Length-1; i++) {
				enteredSequence [i] = enteredSequence [i + 1];
			}
		} else {
			pos++;//count up until last element and stop
		}
		Debug.Log("entered n: " + number + " pos: "+ pos);
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
