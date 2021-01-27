using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    click
}

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public PlayerState currentState;
    private Rigidbody2D myRigidbody2D;
    private Vector3 vector;
    public Vector2 lastMotionVector;
    private Animator animator;

    //Use this for initialization
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();

        
    }

    private void Awake()
    {
        // Deleting all objects from the inventory
        foreach (ItemSlot itemSlot in GameManager.instance.inventoryContainer.slots)
        {
            if (itemSlot != null)
            {
                if (itemSlot.item != null)
                {
                    GameManager.instance.inventoryContainer.RemoveItem(itemSlot.item, itemSlot.count);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        vector = Vector3.zero;
        vector.x = Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");

        if(Input.GetMouseButtonDown(0) && currentState != PlayerState.click)
        {
            StartCoroutine(ClickCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator ClickCo()
    {
        animator.SetBool("clicking", true);
        currentState = PlayerState.click;
        yield return null;
        animator.SetBool("clicking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
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
            if (FindObjectOfType<SoundManager>().SoundIsPlaying("Walk"))
            {
                FindObjectOfType<SoundManager>().Stop("Walk");
            }
        }
    }
    //Move character
    void Move()
    {
        myRigidbody2D.MovePosition(transform.position + vector * speed * Time.deltaTime);
        if (!FindObjectOfType<SoundManager>().SoundIsPlaying("Walk"))
        {
            FindObjectOfType<SoundManager>().Play("Walk");
        }
    }
}
