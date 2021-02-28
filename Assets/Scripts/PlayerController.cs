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

    private void Awake() 
    {
        _playerRB = GetComponent<Rigidbody2D>();
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
    }
}
