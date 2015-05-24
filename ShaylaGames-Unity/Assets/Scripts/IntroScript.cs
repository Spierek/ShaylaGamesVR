using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
    #region Variables
    private bool isVisible = true;
    private float initialDelay = 5f;
    private float timer;

    private SpriteRenderer sprite;
    private Color tempC;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    
    private void Update () {
        if (isVisible && timer > initialDelay && Input.GetMouseButtonDown(0)) {
            isVisible = false;
            Application.LoadLevel(1);
        }

        timer += Time.deltaTime;
    }
    #endregion
}
