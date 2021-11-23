using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Default
    public int bulletSpeed = 5;
    public enum bulletMode { normal, spiral, autoAim };
    public bulletMode bulletType = bulletMode.normal;

    public static int bulletDamage;
    public int bulletDmg = 1;

    private Transform target;
    private GameObject player;
    private Vector2 movement;


    public GameObject deathExplosion;
    private Rigidbody2D rg;

    public int bulletLife = 3;

    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = bulletDmg;

        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                target = player.transform;
                rg = GetComponent<Rigidbody2D>();
            }
        } catch
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        // bullet type switch
        switch (bulletType)
        {
            case bulletMode.normal:
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                break;
            case bulletMode.spiral:
                spiralBullet();
                break;
            case bulletMode.autoAim:
                AutoAimBullet();
                break;
            default:
                bulletType = bulletMode.normal;
                break;
        }
        
        Destroy(gameObject, bulletLife);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Playerbullet hits enemy
        if (other.tag == "Player" || other.tag == "shield_skill")
        {
            Destroy(gameObject);
        }

    }

    // Does not work
    private void spiralBullet()
    {
        // DOES NOT WORK

        Vector2 finalPos = transform.position;
        finalPos.x = Mathf.Sin(finalPos.x + bulletSpeed) * Time.time;
        finalPos.y += (bulletSpeed * Time.deltaTime) * -1f;
        transform.position = new Vector2(finalPos.x, finalPos.y);
    }

    private void AutoAimBullet()
    {
        if (player)
        {
            // Getting distance between asteroid and player
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            rg.rotation = angle;
            direction.Normalize();
            movement = direction;
        }

        // Moving bullet
        transform.position = (Vector2)transform.position + (movement * bulletSpeed * Time.deltaTime);
    }
}
