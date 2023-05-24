using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaSala : MonoBehaviour
{
    [SerializeField] private GameObject openDoor;

    public void OpenDoor()
    {
        openDoor.SetActive(true);
        gameObject.SetActive(false);
    }
}
