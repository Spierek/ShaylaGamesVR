using UnityEngine;
using System.Collections;

public class NoseController : MonoBehaviour {
    #region Variables
    public float        noseResizeSpeed = 0.01f;
    public Vector2      noseLengthRange = new Vector2(0.5f, 4f);
    [Space(10)]
    public Transform    raycastFront;
    public Transform    raycastBack;
    [Space(10)]
    public Transform    twigParent;
    public Transform    twigPosition;
    [Space(10)]
    public TextMesh     textMesh;
    
    private float       initialDelayTimer;
    private float       initialDelay = 0.5f;

    private Transform   parent;

    private Vector3     tempV3;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        parent = transform.parent;
    }
    
    private void Update () {
        if (initialDelayTimer > initialDelay) {
            if (SystemInfo.deviceName == "<unknown>") {
                UpdateNoseSizeGear();
            }
            else {
               UpdateNoseSizeEditor();
            }
            ClampNoseLength();
        }
        else {
            initialDelayTimer += Time.deltaTime;
        }

        UpdateTwigPosition();

        textMesh.text = parent.transform.localScale.z.ToString();
    }

    private void OnCollisionEnter(Collision col) {
        //textMesh.text = col.gameObject.name;
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

    private void ClampNoseLength() {
        tempV3 = parent.localScale;
        tempV3.z = Mathf.Clamp(tempV3.z, noseLengthRange.x, noseLengthRange.y);
        parent.localScale = tempV3;
        tempV3 = Vector3.zero;
    }

    private void UpdateTwigPosition() {
        twigParent.position = twigPosition.position;
    }
    #endregion
}
