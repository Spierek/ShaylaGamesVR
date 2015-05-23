using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    #region Variables
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
    
    }
    
    private void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(0);
        }
    }
    #endregion

    #region Methods
    #endregion
}
