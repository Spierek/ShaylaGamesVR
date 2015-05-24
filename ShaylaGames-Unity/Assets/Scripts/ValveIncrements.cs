using UnityEngine;
using System.Collections;

public class ValveIncrements : MonoBehaviour {

	public Transform valvePoint;
	public Transform centerPoint;
	// Use this for initialization
	public float increment = 0.0f;
	public int nbrTurns = 5;
	private float turnCount = 0f;
	private Vector3 startDirection;
	private float buffer = 2f;
	private bool above = false;
	//public Animator displayAnim;
	void Start () {
		startDirection = (valvePoint.position - centerPoint.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 currentDirection = valvePoint.position - centerPoint.position;
		float currentAngle = Vector3.Angle(startDirection.normalized,currentDirection.normalized);
		//set angle interval 360 degrees
		if (0 >= Vector3.Dot (currentDirection.normalized, -Vector3.up)) {
			currentAngle *= -1f;
			currentAngle += 360;
		}
			if (currentAngle > 360 - buffer || currentAngle < buffer) {
			currentAngle = 0;
		}


		if (0+ buffer*0.01f >= Vector3.Dot (currentDirection.normalized, -Vector3.up)) {
			if (!above){
				//Debug.Log ("Set above");
				above = true;
				if (currentAngle > 360 - buffer*10f || currentAngle < buffer*10f){
					turnCount -= 360;
					turnCount = Mathf.Clamp(turnCount,0f,360*(nbrTurns+1));
					Debug.Log (turnCount);
				}
			}
		} else 
		{
			if (above){
				//Debug.Log ("set below");
				above = false;
				if (currentAngle > 360 - buffer*10f || currentAngle < buffer*10f){
					turnCount += 360;
					turnCount = Mathf.Clamp(turnCount,0f,360*(nbrTurns+1));

					Debug.Log (turnCount);
				}
			}
		}

		if (turnCount == 0f|| turnCount ==360*(nbrTurns+1)) {
			currentAngle = 0f;
		}
		float tempIncrement = (Mathf.Max(turnCount-360f,0f) + currentAngle) / ((float)nbrTurns * 360);
		if (Mathf.Abs (increment - tempIncrement) < 0.1)
		   increment = tempIncrement;

        FrameScript.Instance.UpdateHeight(increment);

		//Debug.Log (increment);
		//displayAnim.SetFloat ("AnimProgress", increment);
	}
}
