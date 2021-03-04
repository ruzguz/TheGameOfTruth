using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GhostLevelManager : MonoBehaviour
{

    public Texture2D cursorTexture;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;

    // UI vars
    public GameObject transitionPanelWin;
    public GameObject transitionPanelLose;

    // Level config vars
    private bool _canGenerate2nd = true;
    private bool _canGenerate3rd = true;
    private GameObject _currentBlock;
    public float limit1 = 0.3f;
    public float limit2 = 0.6f;
    public GameObject[] blocks;
    
    private int _blocksQty = 3;
    public int[] blocksForLevel;
    public static GhostLevelManager sharedInstance;
    public int ghostQuantity = 10;
    public int ghostDestroyed = 0;
    public int patientLives = 3;
    public float spawnTime;
    private float _timer;
    public GameObject ghost;
    public GameObject ghost2;
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

        Cursor.SetCursor(cursorTexture, _hotSpot, _cursorMode);

        // Generate blocks for the game
        blocksForLevel = new int[_blocksQty];
        GenerateBlocks();

        // Show first block
        _currentBlock = Instantiate(blocks[blocksForLevel[0]], Vector3.zero, Quaternion.identity);
        

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
            //gInstantiate(ghost2, randomPoint, Quaternion.identity);
            _timer = spawnTime;
        }

        Debug.Log((int)(ghostQuantity*limit2));

        // Transition form first block to second
        if (ghostDestroyed >= (int)(ghostQuantity*limit1) && ghostDestroyed < (int)(ghostQuantity*limit2) && _canGenerate2nd) 
        {
            Debug.Log("Second Block");
            _currentBlock.SetActive(false);
            _currentBlock = Instantiate(blocks[blocksForLevel[1]], Vector3.zero, Quaternion.identity);
            _canGenerate2nd = false;
            
        }

        // Transition from second block to third
        if (ghostDestroyed >= ghostQuantity*limit2 && _canGenerate3rd) 
        {
            Debug.Log("Third Block");
            _currentBlock.SetActive(false);
            _currentBlock = Instantiate(blocks[blocksForLevel[2]], Vector3.zero, Quaternion.identity);
            _canGenerate3rd = false;
        }

        // Win condition
        if(ghostDestroyed >= ghostQuantity)
        {
            // TODO: go to win scene
            transitionPanelWin.SetActive(true);
            transitionPanelWin.GetComponent<Animator>().Play("panel-in");

        }


        // Lose Condiiton
        if (patientLives <= 0) 
        {
            // TODO: go to lose scene
            transitionPanelLose.SetActive(true);
            transitionPanelLose.GetComponent<Animator>().Play("panel-in");
        }
    }

    void GenerateBlocks()
    {
        for (int i = 0; i < _blocksQty; i++) 
        {
            int randomNumber = -1;
            while(blocksForLevel.Contains(randomNumber) || randomNumber == -1) {
                randomNumber = Random.Range(0, blocks.Length);
            }
            blocksForLevel[i] = randomNumber;
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
