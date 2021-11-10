using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonControl : MonoBehaviour
{
    private float fireRate;
    public static float fireRateShip;
    private float timepassed;
    public GameObject bullet;

    public GameObject fireEffect;

    // Start is called before the first frame update
    void Start()
    {
        timepassed = Time.time;
        fireRate = fireRateShip;
    }

    // Update is called once per frame
    void Update()
    {
        // Update ship firerate
        fireRate = fireRateShip;

        // Firerate shoot
        if (Input.GetKey(KeyCode.Space) && Time.time > timepassed)
        {
            GameObject bulletCopy = Instantiate(bullet, transform.position, Quaternion.identity);
            timepassed = Time.time + fireRate;
        }


        // Fire effect when shooting
        if (timepassed - fireRate + 0.05f > Time.time)
        {
            fireEffect.SetActive(true);
        } else
        {
            fireEffect.SetActive(false);
        }

    }
}
