using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    CharacterController _characterController;
    Animator _animator;
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 1f;
    public float allowPlayerRotation = 0.1f;
    public float desiredRotationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        MoveCharacter();
    }

    void MoveCharacter() {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");
        bool isMoving = (xMovement != 0) || (zMovement > 0);


        if (zMovement < 0)
            zMovement = 0;

        transform.Rotate(0f, xMovement * 3.5f, 0f);

        Vector3 moveDir = Vector3.forward * zMovement;

        moveDir = transform.TransformDirection(moveDir);
        moveDir *= movementSpeed;

        _characterController.Move(moveDir);

        _animator.SetBool("Run", isMoving);
    }
}
