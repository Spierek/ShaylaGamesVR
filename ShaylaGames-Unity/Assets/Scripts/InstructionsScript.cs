using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionsScript : MonoBehaviour {
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
            StartCoroutine(Hide());
        }

        timer += Time.deltaTime;
    }
    #endregion

    #region Methods
    private IEnumerator Hide() {
        float duration = 2f;
        float t = duration;
        tempC = sprite.color;

        while (t > 0) {
            tempC.a = t / duration;
            sprite.color = tempC;

            t -= Time.deltaTime;
            yield return null;
        }

        sprite.color = new Color(1,1,1,0);
    }
    #endregion
}
