using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{

    public int bulletSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(transform.up * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Playerbullet hits enemy
        if (other.tag == "Enemy" && gameObject.tag == "player_bullet")
        {
            Destroy(gameObject);
        }
    }
}
