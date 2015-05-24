using UnityEngine;
using System.Collections;

public class ValveCompartment : MonoBehaviour {
    #region Variables
    public float            desiredYOffset = -0.7f;

    private Vector3         initialPosition;
    private bool            wasActivated;
    private ParticleSystem  particles;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        initialPosition = transform.localPosition;
        particles = transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    
    private void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            StartCoroutine(SlideDown());
        }
    }
    #endregion

    #region Methods
    public void Open() {
        if (wasActivated) {
            wasActivated = true;
            StartCoroutine(SlideDown());
        }
    }

    private IEnumerator SlideDown() {
        float timer = 0f;
        float duration = 2f;
        Vector3 tempV3;

        particles.Play();

        while (timer < duration) {
            tempV3 = initialPosition;
            tempV3.y += Mathf.SmoothStep(0, desiredYOffset, timer / duration);
            transform.localPosition = tempV3;

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = initialPosition + new Vector3(0, desiredYOffset);
    }
    #endregion
}
