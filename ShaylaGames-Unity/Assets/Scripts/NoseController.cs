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
    private float       desiredNoseLength;
    private float       maximumAllowedNoseLength;

    private Transform   parent;
    private Vector3     initialScale;

    private Vector3     tempV3;
    private Ray         ray;
    private RaycastHit  hit;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        parent = transform.parent;
        initialScale = parent.localScale;
        desiredNoseLength = noseLengthRange.x;
        maximumAllowedNoseLength = noseLengthRange.y;
    }
    
    private void Update () {
        if (initialDelayTimer > initialDelay) {
            GetDesiredNoseLength();
            if (!RaycastCheck()) {
                CalculateNoseLength();
            }
        }
        else {
            initialDelayTimer += Time.deltaTime;
        }

        textMesh.text = desiredNoseLength + " " + maximumAllowedNoseLength;

        UpdateTwigPosition();
    }

    private void OnCollisionEnter(Collision col) {
        //textMesh.text = col.gameObject.name;
    }
    #endregion

    #region Methods
    private void GetDesiredNoseLength() {
        // desktop
        if (SystemInfo.deviceName != "<unknown>") {
            tempV3.z = Input.mouseScrollDelta.y * noseResizeSpeed * 5f;
        }
        // gear vr
        else if (Input.mousePosition.x != 1280) {
            tempV3.z = -Input.GetAxis("Mouse X") * noseResizeSpeed;
        }

        desiredNoseLength += tempV3.z;
        desiredNoseLength = Mathf.Clamp(desiredNoseLength, noseLengthRange.x, noseLengthRange.y);
    }

    private bool RaycastCheck() {
        ray.origin = raycastPoint.position;
        ray.direction = transform.forward;
        if (Physics.Raycast(ray, out hit, noseLengthRange.y, 1 << LayerMask.NameToLayer("Static"))) {
            textMesh.text = hit.collider.gameObject.name;
            maximumAllowedNoseLength = Vector3.Distance(hit.point, ray.origin);
            return false;
        }
        return false;
    }

    private void CalculateNoseLength() {
        tempV3 = initialScale;
        tempV3.z = Mathf.Clamp(desiredNoseLength, noseLengthRange.x, maximumAllowedNoseLength);
        parent.localScale = tempV3;
        tempV3 = Vector3.zero;
    }

    private void UpdateTwigPosition() {
        twigParent.position = twigPosition.position;
    }
    #endregion
}
