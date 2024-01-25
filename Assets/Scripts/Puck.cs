using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public delegate void GoalHandler();
    public event GoalHandler OnGoal;
    public GameObject goal;

    public float deceleration = .99f;
    private Rigidbody puckRb;

    void Start()
    {
        puckRb = GetComponent<Rigidbody>();
        puckRb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        puckRb.velocity = new Vector3(
            puckRb.velocity.x * deceleration,
            puckRb.velocity.y,
            puckRb.velocity.z * deceleration
            );
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
        // Invoke's the methods stored into the handler
        if ( collision.gameObject.CompareTag(goal.tag))
        {   
            OnGoal?.Invoke(); 
            puckRb.velocity = Vector3.zero;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
