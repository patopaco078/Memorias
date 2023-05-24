using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    [SerializeField] private IntroductionCinematic cinematicController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cinematicController.EndCinematic();
            Destroy(this);
        }
    }
}
