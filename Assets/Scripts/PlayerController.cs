using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // General vars
    public float playerSpeed = 5;
    private float _h,_v;
    private Vector3 _moveDirection;

    // Components vars



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        _moveDirection.x = _h;
        _moveDirection.y = _v;

        transform.position += _moveDirection * Time.deltaTime * playerSpeed;

    }

    // Handle collisions
    private void OnCollisionEnter2D(Collision2D other) {

    }
}
