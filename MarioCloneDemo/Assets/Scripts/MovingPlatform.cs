using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float startLocation;
    private float endLocation;

    // How far to move
    [SerializeField] float distance;
    [SerializeField] float moveSpeed;
    private Vector3 direction = Vector3.up;

    private Rigidbody2D rb;

    private bool isTouched;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startLocation = transform.position.y;
        endLocation = startLocation + distance;
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (transform.position.y >= endLocation)
            {
                direction = Vector3.down;

            }
            else if (transform.position.y <= startLocation)
            {
                direction = Vector3.up;
            }
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouched = true;
        }
    }
}
