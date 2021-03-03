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
        Debug.Log(Time.deltaTime);
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            float randomX = Random.Range(-xLimit, xLimit);
            float randomY = yLimit * _sign[Random.Range(1,3)];
            Vector3 randomPoint = new Vector3(randomX, randomY, 0f);
            Instantiate(ghost, randomPoint, Quaternion.identity);
            _timer = spawnTime;
        }
    }
}
