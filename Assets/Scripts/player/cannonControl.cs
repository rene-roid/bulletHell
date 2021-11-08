using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonControl : MonoBehaviour
{
    public float fireRate = 0.1f;
    private float timepassed;
    public GameObject bullet;

    public GameObject fireEffect;

    // Start is called before the first frame update
    void Start()
    {
        timepassed = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > timepassed)
        {
            fireEffect.GetComponent<Animator>().Play("fireBulletEffect");
            GameObject bulletCopy = Instantiate(bullet, transform.position, Quaternion.identity);
            timepassed = Time.time + fireRate;
        }

        //if (!fireEffect.GetComponent<Animator.Contr)
        //{
        //    fireEffect.SetActive(false);
        //} else
        //{
        //    fireEffect.SetActive(true);
        //}
    }
}
