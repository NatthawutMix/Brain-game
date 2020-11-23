using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movementSpeed;
    public static int count = 0;
    [SerializeField] private float walkSpeed, runSpeed;
    [SerializeField] private KeyCode runKey;

    public static bool canMove = true;
    public static bool Stop = true;


    private CharacterController charController;
    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

   
    private void Update()
    {
        if (canMove && Stop)
            PlayerMovement();
    }
    private void PlayerMovement()
    {
        float horiInput = Input.GetAxis("Horizontal") * movementSpeed;
        float verInput = Input.GetAxis("Vertical")* movementSpeed;
        Vector3 forwardMovement = transform.forward * verInput;
        Vector3 rightMovement = transform.right * horiInput;

        charController.SimpleMove(forwardMovement + rightMovement);
        SetMovementSpeed();
    }
    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime );
        else
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime );
    }
}
