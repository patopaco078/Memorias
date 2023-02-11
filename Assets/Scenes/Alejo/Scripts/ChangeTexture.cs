using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//BY: ALEJO LOPEZ

public class ChangeTexture : MonoBehaviour
{
    [SerializeField] Texture m_MainTexture;
    Renderer m_Renderer;
    private void Awake() {
        m_Renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
        }
    }
}
