using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//BY: ALEJO LOPEZ

public class ChangeTexture : MonoBehaviour
{
    /*INSTRUCCIONES: El script se agrega a un objeto padre, el cual contiene el trigger.
     Los hijos son todos los elementos a los que se le van a cambiar la textura del material.
    Se agregan las texturas en el inspector. Se debe QUITAR el componente MATERIAL al padre*/
    [Header("Textures"), SerializeField] Texture [] m_OtherTexture;
    Renderer [] m_Renderer;
    Texture [] m_OriginalTexture;
    private void Awake() {

        m_Renderer = GetComponentsInChildren<Renderer>();
        m_OriginalTexture = new Texture[m_OtherTexture.Length];
    }

    private void Start() {

        for(int i = 0; i <m_OtherTexture.Length; i++) { //Se guardan las texturas originales
            m_OriginalTexture[i] = m_Renderer[i].material.mainTexture;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) { //Se cambian las texturas originales por las puestas en el inspector
            for (int i = 0; i < m_OtherTexture.Length; i++) {
                m_Renderer[i].material.SetTexture("_BaseMap", m_OtherTexture[i]);//API Unity: SetTexture
            }
        }
    }

   /* private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) { //Se regresan las texturas originales a cada G.O.
            for(int i = 0; i < m_OtherTexture.Length; i++) {
                m_Renderer[i].material.SetTexture("_MainTex", m_OriginalTexture[i]);
            }
        }
    }*/
}
