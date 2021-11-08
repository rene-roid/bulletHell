using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCannon : MonoBehaviour
{
    public float fireRate = 0.1f;
    private float timepassed;
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        timepassed = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timepassed)
        {
            GameObject bulletCopy = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            Destroy(bulletCopy, 2);
            timepassed = Time.time + fireRate;
        }
    }
}
