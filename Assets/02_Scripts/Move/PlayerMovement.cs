using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2;
    [SerializeField]
    float jumpForce = 15;
    float x;
    bool isGrounded = true;
    bool jumpTime = true;

    [SerializeField]
    LayerMask ground;
    Vector3 dir;
    Rigidbody2D playerRig;

    private void Awake()
    {
        playerRig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        dir = new Vector3(x, 0, 0);
        isGrounded = Physics2D.OverlapBox(transform.position - new Vector3(0, 0.5f, 0), new Vector3(0.5f, 0.05f, 1), 0, ground);

        StartCoroutine(Jump());
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerRig.velocity = new Vector3(x * speed, playerRig.velocity.y, 0);
    }

    IEnumerator Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true && jumpTime == true)
        {
            playerRig.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

            jumpTime = false;

            yield return new WaitForSeconds(0.01f);

            jumpTime = true;
        }
    }
}
