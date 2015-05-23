using UnityEngine;
using System.Collections;

public class ButtonStatus : MonoBehaviour {
    #region Variables
    public static ButtonStatus Instance;

    private static int  buttonCount = 4;

    private bool[]      buttons = new bool[buttonCount];
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        Instance = this;
    }
    
    private void Update () {
        
    }
    #endregion

    #region Methods
    public void SetButton(int ID) {
        buttons[ID] = true;
        transform.GetChild(ID).GetComponent<MeshRenderer>().material.color = Color.green;

        CheckButtons();
    }

    private void CheckButtons() {
        bool check = true;
        for (int i = 0; i < buttonCount; ++i) {
            check = buttons[i];
        }

        if (check) {
            // TODO: do something
            Debug.Log("all buttons pressed");
        }
    }
    #endregion
}
