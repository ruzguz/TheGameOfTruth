﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change Scene
    public void ChangeScene() 
    {
        SceneManager.LoadScene(sceneName);
    }
}
