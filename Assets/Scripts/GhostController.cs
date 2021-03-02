using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    // General vars
    public float speed = 1;
    private GameObject _patient;


    // Start is called before the first frame update
    void Start()
    {
        _patient = GameObject.Find("Patient");
    }

    // Update is called once per frame
    void Update()
    {
        // Move to the patient
        transform.position = Vector3.MoveTowards(transform.position, _patient.transform.position, speed * Time.deltaTime);
    }
}
