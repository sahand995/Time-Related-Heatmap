using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_1 : MonoBehaviour
{
    float speed = 2;
    float rotSpeed = 150;
    float rot = 0f;
    float gravity = 8;

    private Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("condition", 1);
            moveDir = new Vector3(0, 0, 1) * speed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal_1") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y = gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    public Vector3 GetMoveDir()
    {
        return moveDir;
    }
}
