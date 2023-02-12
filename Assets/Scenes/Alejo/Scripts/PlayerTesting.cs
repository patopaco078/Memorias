using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTesting : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;
    CharacterController characterController;
    Vector3 move = new Vector3();

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * speed);
    }
}
