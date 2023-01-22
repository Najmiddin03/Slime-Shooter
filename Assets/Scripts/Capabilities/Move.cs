using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    [SerializeField] 
    private InputController input = null;
    [SerializeField, Range(0f, 100f)] 
    private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] 
    private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] 
    private float maxAirAcceleration = 20f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject model;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
        Rotate();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;

        animator.SetFloat("Speed", Convert.ToInt32(onGround) * Mathf.Abs(velocity.x));

 
    }
    private void Rotate()
    {
        int _input = input.RetrieveMoveInput();
        if (_input > 0)
        {
            model.transform.eulerAngles = new Vector3(0, 180f, 0);
        }
        else if (_input < 0)
        {
            model.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
