using UnityEngine;
using System.Collections;

public class FrameScript : MonoBehaviour {
    #region Variables
    public static FrameScript Instance;

    private Vector3 initialPos;
    public Vector3 finalOffset;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        Instance = this;
        initialPos = transform.localPosition;
    }
    
    private void Update () {
        
    }
    #endregion

    #region Methods
    public void UpdateHeight(float range) {
        Debug.Log(range);
        transform.localPosition = Vector3.Lerp(initialPos, initialPos + finalOffset, range);
    }
    #endregion
}
