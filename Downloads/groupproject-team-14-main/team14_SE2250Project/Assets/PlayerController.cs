using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rigidBody;
    public Transform groundPoint;
    public bool isOnGround = true;
    public LayerMask whatisGround;

    public Animator animator;

    public BulletController shotToFire;
    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //moving on x axis
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigidBody.velocity.y);

        //direction change brev innit
        if (rigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (rigidBody.velocity.x > 0)
        {
            transform.localScale =  Vector3.one;

        }


        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatisGround);
        //jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

        }


        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDirection = new Vector2(transform.localScale.x, 0f);

            animator.SetTrigger("ShotFired");
        }













        animator.SetBool("isOnGround", isOnGround);
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    }
}
