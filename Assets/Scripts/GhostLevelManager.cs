using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLevelManager : MonoBehaviour
{

    // Level config vars
    public static GhostLevelManager sharedInstance;
    [SerializeField]
    private int _ghostQuantity = 10;
    private int _ghostDestroyed = 0;
    [SerializeField]
    private int _patientLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        if (sharedInstance == null) 
        {
            sharedInstance = this;
        } else 
        {
            Destroy(gameObject);
        }


        //_ghostQuantity = GameManager.sharedInstance.ghostQuantity;
        //_patientLives = GameManager.sharedInstance.ghostLevelLives;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
