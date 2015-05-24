using UnityEngine;
using System.Collections;

public class RoomDoorScript : MonoBehaviour {
    #region Variables
    public static RoomDoorScript Instance;
    private Vector3 tempV3;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        Instance = this;
    }
    
    private void Update () {
        if (Input.GetKeyDown(KeyCode.O)) {
            StartCoroutine(Open());
        }
    }
    #endregion

    #region Methods
    public void OpenDoor() {
        StartCoroutine(Open());
    }

    private IEnumerator Open() {
        float timer = 0;
        float duration = 2f;
        PlayerScript.Instance.ActivateBloom();

        while (timer < duration) {
            tempV3.y = -30f * Time.deltaTime;
            transform.Rotate(tempV3);

            timer += Time.deltaTime;
            yield return null;
        }
    }
    #endregion
}
