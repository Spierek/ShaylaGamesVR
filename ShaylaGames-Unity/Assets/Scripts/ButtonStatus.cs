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

        if (CheckButtons()) {
            ValveCompartment.Instance.Open();
        }
    }

    private bool CheckButtons() {
        for (int i = 0; i < buttonCount; ++i) {
            if (!buttons[i]) {
                return false;
            }
        }

        return true;
    }
    #endregion
}
