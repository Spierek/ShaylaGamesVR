using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PlayerScript : MonoBehaviour {
    #region Variables
    public static PlayerScript Instance;

    public SpriteRenderer fade;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        Instance = this;
    }
    
    private void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(0);
        }
    }
    #endregion

    #region Methods
    public void ActivateBloom() {
        StartCoroutine(FinalBloom());
    }

    private IEnumerator FinalBloom() {
        float timer = 0;
        float duration = 3f;
        Color tempC = Color.white;

        while (timer < duration) {
            tempC.a = Mathf.Lerp(0, 1, timer / duration);
            fade.color = tempC;

            timer += Time.deltaTime;
            yield return null;
        }

        tempC.a = 1;
        fade.color = tempC;
    }
    #endregion
}
