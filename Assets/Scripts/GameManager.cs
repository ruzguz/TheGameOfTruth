using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // General vars
    public static GameManager sharedInstance;
    public int difficulty;

    // Level vars
    public int ghostQuantity;
    public int ghostLevelLives;

    // Start is called before the first frame update
    void Start()
    {
        // Singleton initialization
        if (sharedInstance == null) 
        {
            sharedInstance = this;
        } else 
        {
            Destroy(gameObject);
        }

        // TODO: set level values according to the difficulty
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
