using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLevelManager : MonoBehaviour
{

    // UI vars
    public GameObject transitionPanel;

    // Level config vars
    public static GhostLevelManager sharedInstance;
    public int ghostQuantity = 10;
    public int ghostDestroyed = 0;
    public int patientLives = 3;
    public float spawnTime;
    private float _timer;
    public GameObject ghost;
    public float xLimit;
    public float yLimit;
    private int[] _sign = new int[] {1, -1};


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

        _timer = spawnTime;

        //_ghostQuantity = GameManager.sharedInstance.ghostQuantity;
        //_patientLives = GameManager.sharedInstance.ghostLevelLives;       
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn enemies
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            float randomX = Random.Range(-xLimit, xLimit);
            float randomY = yLimit * _sign[Random.Range(1,2)];
            Vector3 randomPoint = new Vector3(randomX, randomY, 0f);
            Instantiate(ghost, randomPoint, Quaternion.identity);
            _timer = spawnTime;
        }


        // Win condition
        if(ghostDestroyed >= ghostQuantity)
        {
            // TODO: go to win scene
            Debug.Log("Win game");
            transitionPanel.SetActive(true);
            transitionPanel.GetComponent<Animator>().Play("panel-in");

        }


        // Lose Condiiton
        if (patientLives <= 0) 
        {
            // TODO: go to lose scene
            Debug.Log("Lose Game");
            transitionPanel.SetActive(true);
            transitionPanel.GetComponent<Animator>().Play("panel-in");
        }
    }

    public void IncreaseScore()
    {
        ghostDestroyed++;
    }

    public void DamagePatient()
    {
        patientLives--;
    }


}
