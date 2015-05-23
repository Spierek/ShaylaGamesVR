using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;

public class NoseController : MonoBehaviour {
    #region Variables
    public float        noseResizeSpeed = 0.01f;
    public Vector2      noseLengthRange = new Vector2(0.5f, 4f);
    [Space(10)]
    public Transform    raycastPoint;
    [Space(10)]
    public Transform    twigParent;
    public Transform    twigPosition;
    [Space(10)]
    public TextMesh     textMesh;
    
    private float       initialDelayTimer;
    private float       initialDelay = 0.5f;
    private float       noseLengthLimit;

    private Transform   parent;

    private Vector3     tempV3;
    private Ray         ray;
    private RaycastHit  hit;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        parent = transform.parent;
        noseLengthLimit = noseLengthRange.y;
    }
    
    private void Update () {
        if (initialDelayTimer > initialDelay) {
            GetScrollDelta();
            if (!RaycastCheck()) {
                noseLengthLimit = Mathf.Clamp(noseLengthLimit, noseLengthRange.x, noseLengthRange.y);
                parent.localScale += tempV3;
            }
            ClampNoseLength();
        }
        else {
            initialDelayTimer += Time.deltaTime;
        }

        UpdateTwigPosition();
    }

    private void OnCollisionEnter(Collision col) {
        //textMesh.text = col.gameObject.name;
    }
    #endregion

    #region Methods
    private void GetScrollDelta() {
        // desktop
        if (SystemInfo.deviceName != "<unknown>") {
            tempV3.z = Input.mouseScrollDelta.y * noseResizeSpeed * 5f;
        }
        // gear vr
        else if (Input.mousePosition.x != 1280) {
            tempV3.z = -Input.GetAxis("Mouse X") * noseResizeSpeed;
        }
    }

    private bool RaycastCheck() {
        ray.origin = raycastPoint.position;
        ray.direction = transform.forward;
        if (Physics.Raycast(ray, out hit, noseLengthRange.y, 1 << LayerMask.NameToLayer("Static"))) {
            textMesh.text = hit.collider.gameObject.name;
            noseLengthLimit = Vector3.Distance(hit.point, ray.origin);
            return false;
        }

        noseLengthLimit = noseLengthRange.y;
        return false;
    }

    private void ClampNoseLength() {
        tempV3 = parent.localScale;
        tempV3.z = Mathf.Clamp(tempV3.z, noseLengthRange.x, noseLengthLimit);
        parent.localScale = tempV3;
        tempV3 = Vector3.zero;
    }

    private void UpdateTwigPosition() {
        twigParent.position = twigPosition.position;
    }
    #endregion
}
