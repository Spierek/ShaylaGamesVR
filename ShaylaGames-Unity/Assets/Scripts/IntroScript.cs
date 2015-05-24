using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class IntroScript : MonoBehaviour {
    #region Variables
    private bool isVisible = true;
    private float initialDelay = 3f;
    private float timer;
    private float check;

    private SpriteRenderer sprite;
    private Color tempC;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    
    private void Update () {
        if (isVisible && timer > initialDelay) {
            if (Input.GetMouseButton(0)) {
                check += Time.deltaTime;
            }
            if (check > 0.5f) {
                isVisible = false;
                Application.LoadLevel(1);
            }
        }

        timer += Time.deltaTime;
    }
    #endregion
}
