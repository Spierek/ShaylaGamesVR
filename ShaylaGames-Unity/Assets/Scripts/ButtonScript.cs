using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    #region Variables
    public int ID;

    private bool isPressed;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
    
    }
    
    private void Update () {
    
    }

    private void OnCollisionEnter(Collision col) {
        if (!isPressed) {
            GetComponent<MeshRenderer>().material.color = Color.green;
            transform.localPosition += new Vector3(0, 0, 0.1f);

            ButtonStatus.Instance.SetButton(ID);
            isPressed = true;
        }
    }
    #endregion

    #region Methods
    #endregion
}
