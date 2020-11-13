using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector3 vector;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    private Animator animator;

    //Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vector = Vector3.zero;
        vector.x = Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");

        motionVector = new Vector2(vector.x, vector.y);

        UpdateAnimationAndMove();

        if (vector.x != 0 || vector.y != 0)
        {
            lastMotionVector = new Vector2(vector.x, vector.y).normalized;
        }
    }
    void UpdateAnimationAndMove()
    {
        if (vector != Vector3.zero)
        {
            Move();
            animator.SetFloat("moveX", vector.x);
            animator.SetFloat("moveY", vector.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    //Move character
    void Move()
    {
        myRigidbody2D.MovePosition(transform.position + vector * speed * Time.deltaTime);
    }
}
