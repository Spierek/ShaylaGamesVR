using UnityEngine;
using System.Collections;

public class DialTrigger : MonoBehaviour {
	
		
		public SafeController safe;
		public float duration = 1.0f;
	public Transform[] Numbers;
		// Use this for initialization
		void Start () {
			if (safe == null)
				Debug.LogError ("Set the safe object");
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnTriggerEnter(Collider other) {
		if (other.tag == "Number") {
				
			Debug.Log ("startTimer for number " + int.Parse (other.name));
			switch (int.Parse (other.name)) {
			case 1:
				StartCoroutine ("Timer" + other.name);//
				break;
			case 2:
				StartCoroutine ("Timer" + other.name);//
				break;
			case 3:
				StartCoroutine ("Timer" + other.name);//
				break;
			case 4:
				StartCoroutine ("Timer" + other.name);//
				break;
			}
		}
	}
		
		void OnTriggerExit(Collider other){
		if(other.tag == "Number") {
			Debug.Log ("stop Timer for number "+ int.Parse(other.name));
			switch (int.Parse (other.name)) {
			case 1:
				StopCoroutine ("Timer" + other.name);//
				//Numbers[0].localScale*=0.1
				break;
			case 2:
				StopCoroutine ("Timer" + other.name);//
				break;
			case 3:
				StopCoroutine ("Timer" + other.name);//
				break;
			case 4:
				StopCoroutine ("Timer" + other.name);//
				break;
			}
			}
		}
		
		//sorry bout this
		private IEnumerator Timer1(){			
			yield return new WaitForSeconds (duration); 
				safe.Enter (1);
		yield return 0;
		}
				private IEnumerator Timer2(){			
			yield return new WaitForSeconds (duration); 
				safe.Enter (2);
		yield return 0;
		}
		
	private IEnumerator Timer3(){			
		yield return new WaitForSeconds (duration); 
		safe.Enter (3);
		yield return 0;
	}
	private IEnumerator Timer4(){			
		yield return new WaitForSeconds (duration); 
		safe.Enter (4);
		yield return 0;
	}

		
}
	
	
