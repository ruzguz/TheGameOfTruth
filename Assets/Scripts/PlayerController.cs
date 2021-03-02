using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // General vars
    public float playerSpeed = 5;
    private float _h,_v;
    private Vector2 _moveDirection;

    // Components vars
    private Rigidbody2D _playerRB;
    private SpriteRenderer _playerSR;
    private Animator _playerAnim;

    private void Awake() 
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerSR = GetComponent<SpriteRenderer>();
        _playerAnim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        _moveDirection.x = _h;
        _moveDirection.y = _v;

        // Detect when user make click
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("SHOOT");
            _playerAnim.SetTrigger("shoot");
        }


    }

    private void FixedUpdate() 
    {
        MovePlayer(_moveDirection);
    }

    // Handle collisions
    private void OnCollisionEnter2D(Collision2D other) {

    }

    // Player movement
    private void MovePlayer(Vector2 direction)
    {
        _playerRB.AddForce(direction * playerSpeed);
        // Flip sprite
        if (_h > 0)
        {
            _playerSR.flipX = false;
            _playerAnim.SetBool("isRunning", true);
        } else if (_h < 0) 
        {
            _playerSR.flipX = true;
            _playerAnim.SetBool("isRunning", true);
        } else 
        {
            _playerAnim.SetBool("isRunning", false);
        }
    }


}