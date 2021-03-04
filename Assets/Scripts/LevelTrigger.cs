using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{


    public GameObject transitionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transitionPanel.SetActive(true);
            transitionPanel.GetComponent<Animator>().Play("panel-in");
        }
    }

}
