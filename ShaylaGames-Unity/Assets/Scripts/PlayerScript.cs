using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PlayerScript : MonoBehaviour {
    #region Variables
    public Bloom bloomLeft;
    public Bloom bloomRight;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
    
    }
    
    private void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            StartCoroutine(FinalBloom());
        }
    }
    #endregion

    #region Methods
    private IEnumerator FinalBloom() {
        float timer = 0;
        float duration = 5f;
        float finalBloom = 15f;

        while (timer < duration) {
            bloomLeft.bloomIntensity = Mathf.Lerp(0, finalBloom, timer / duration);
            bloomRight.bloomIntensity = Mathf.Lerp(0, finalBloom, timer / duration);

            timer += Time.deltaTime;
            yield return null;
        }

        bloomLeft.bloomIntensity = finalBloom;
        bloomRight.bloomIntensity = finalBloom;
    }
    #endregion
}
