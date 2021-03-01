using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{

    // General vars
    public Animator instructionLabelAnim;

    // Components vars
    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //_spriteRenderer.material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if player is close
        if (other.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.material.color = Color.yellow;
            instructionLabelAnim.Play("instruction-label-in");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // Check if player go away
        if (other.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.material.color = Color.white;
            instructionLabelAnim.Play("instruction-label-out");
        }    
    }
}
