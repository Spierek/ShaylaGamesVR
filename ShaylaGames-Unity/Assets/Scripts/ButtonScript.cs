using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    #region Variables
    public int ID;

    private bool isPressed;
    private ParticleSystem particles;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
        particles = transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    
    private void Update () {
    
    }

    private void OnCollisionEnter(Collision col) {
        if (!isPressed && col.gameObject.layer == LayerMask.NameToLayer("Nose")) {
            GetComponent<MeshRenderer>().material.color = Color.green;
            transform.localPosition += new Vector3(0, 0, 0.1f);

            ButtonStatus.Instance.SetButton(ID);
            particles.Play();
            isPressed = true;
        }
    }
    #endregion

    #region Methods
    #endregion
}
