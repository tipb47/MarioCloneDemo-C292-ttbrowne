using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 newPosition = new Vector2(0, 1);
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }

        Move();
    }


    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        // (1,0)
        // new Vector2(1, 0)
        transform.Translate(moveInput * Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void Jump() 
    {
        // (0,1)
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
