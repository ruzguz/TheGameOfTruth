using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float speed;
    public float limitX, limitY;

    // Start is called before the first frame update
    void Start()
    {
        limitX = GhostLevelManager.sharedInstance.xLimit;
        limitY = GhostLevelManager.sharedInstance.yLimit;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);    

        // Destroy projectile if goes outside the limits
        if (Mathf.Abs(transform.position.x) > limitX || Mathf.Abs(transform.position.y) > limitY) 
        {
            Destroy(gameObject);
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
