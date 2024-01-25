using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int playerNumber;
    public float speed = 5f;

    [SerializeField] private float horizontalMove;
    [SerializeField] private float verticalMove;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (playerNumber)
        {
            case 1:
                horizontalMove = Input.GetAxis("Horizontal" + playerNumber) * speed;
                verticalMove = Input.GetAxis("Vertical" + playerNumber) * speed;
                break;
            case 2:
                horizontalMove = Input.GetAxis("Horizontal" + playerNumber) * speed;
                verticalMove = Input.GetAxis("Vertical" + playerNumber) * speed;
                break;
            default:
                break;
        }
        rb.velocity = new Vector3(horizontalMove, 0, verticalMove);
    }
}
