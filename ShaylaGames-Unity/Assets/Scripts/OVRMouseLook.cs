using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class OVRMouseLook : MonoBehaviour {
    #region Variables
    [SerializeField] private MouseLook m_MouseLook;
    [SerializeField] private Transform m_Camera;
    #endregion

    #region Monobehaviour Methods
    private void Awake () {
    #if UNITY_EDITOR
		m_MouseLook.Init(transform, m_Camera);
    #endif
    }
    
    private void Update () {
    #if UNITY_EDITOR
        m_MouseLook.LookRotation (transform, m_Camera);
    #endif
    }
    #endregion

    #region Methods
    #endregion
}
