using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    // screen boundaries
    [SerializeField] float screenLeftEdge;
    [SerializeField] float screenRightEdge;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        CheckOutOfBounds();
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void CheckOutOfBounds()
    {
        if (transform.position.x < screenLeftEdge)
        {
            Vector2 newPosition = new Vector2(screenRightEdge, transform.position.y);
            transform.position = newPosition;
        }
    }
}
