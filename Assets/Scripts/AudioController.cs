using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    // Components vars
    private AudioSource _audioSource;
    

    // General vars
    private float _min = 0;
    private float _max = 1;
    [SerializeField]
    private int _fadeSpeed = 1;
    public bool fadeIn = true;


    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for fade
        if (fadeIn)
        {
            FadeIn();
        } else 
        {
            FadeOut();
        }

    }

    public void FadeIn()
    {
        if (_audioSource.volume < _max)
        {
            _audioSource.volume += _fadeSpeed * Time.deltaTime;
        }
    }

    public void FadeOut()
    {
        if (_audioSource.volume > _min) 
        {
            _audioSource.volume -= _fadeSpeed * Time.deltaTime;
        }
    }
}
