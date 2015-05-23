using UnityEngine;
using System.Collections;

public class NoseController : MonoBehaviour {
    #region Variables
    public float noseResizeSpeed = 0.01f;
    
    private float initialDelayTimer;
    private float initialDelay = 0.5f;

    private TextMesh textMesh;
    private Transform parent;

    private Vector3 tempV3;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        parent = transform.parent;
        textMesh = parent.parent.GetChild(1).GetComponent<TextMesh>();
    }
    
    private void Update () {
        if (initialDelayTimer > initialDelay) {
            if (SystemInfo.deviceName == "<unknown>") {
                UpdateNoseSizeGear();
            }
            else {
               UpdateNoseSizeEditor();
            }
        }
        else {
            initialDelayTimer += Time.deltaTime;
        }

        //t.text = Input.GetAxis("Mouse X") + " " + Input.mousePosition.x;
    }

    private void OnCollisionEnter(Collision col) {
        textMesh.text = col.gameObject.name;
    }
    #endregion

    #region Methods
    private void UpdateNoseSizeEditor() {
        tempV3.z = Input.mouseScrollDelta.y * noseResizeSpeed * 5f;
        parent.localScale += tempV3;
    }

    private void UpdateNoseSizeGear() {
        if (Input.mousePosition.x != 1280) {
            tempV3.z = Input.GetAxis("Mouse X") * noseResizeSpeed;
            parent.localScale -= tempV3;
        }
    }
    #endregion
}
