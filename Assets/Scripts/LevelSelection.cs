using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{

    // General vars
    public Animator instructionLabelAnim;
    public bool isActive = true;
    public int status = 0; // 0 = pending, -1 = sick, 1 = healed

    // Components vars
    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if player is close
        if (other.gameObject.CompareTag("Player") && isActive)
        {
            _spriteRenderer.material.color = Color.yellow;
            instructionLabelAnim.gameObject.SetActive(true);
            instructionLabelAnim.Play("instruction-label-in");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // Check if player go away
        if (other.gameObject.CompareTag("Player") && isActive)
        {
            _spriteRenderer.material.color = Color.white;
            instructionLabelAnim.gameObject.SetActive(false);
        }    
    }

    public void ChangeLevel()
    {
        Debug.Log("Chaging level");
    }
}
