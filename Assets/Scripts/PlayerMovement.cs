using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform foot;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource JumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);
        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
            Jump();
        }

        if(transform.position.y<-10f)
        {
            GetComponent<PlayerLife>().Die();
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        JumpSound.Play();
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(foot.position, .1f, ground);
    }
}
