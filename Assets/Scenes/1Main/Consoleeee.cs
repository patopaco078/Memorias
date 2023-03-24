using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consoleeee : MonoBehaviour
{
    [SerializeField] RectTransform ObjectUI;

    private void Update()
    {
        Debug.Log(ObjectUI.anchoredPosition);
    }
}
