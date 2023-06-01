using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetagame : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    float speed, gravity, jumpForce;
    float directionY;

    [SerializeField]
    GroundCheck groundCheck;

    Vector3 velocity;

    private void Update()
    {
        Move();
    }
    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");


        directionY += gravity * Time.deltaTime;
        velocity.y = directionY;
        if (groundCheck.ground) directionY = 0;
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.ground)
        {
            directionY = jumpForce;
            groundCheck.ground = false;
        }


        velocity = new Vector3(inputX, velocity.y, inputZ);
        characterController.Move(velocity * speed * Time.deltaTime);

    }
}
