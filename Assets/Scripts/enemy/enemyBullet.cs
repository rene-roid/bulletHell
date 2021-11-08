using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Default
    public int bulletSpeed = 5;
    public enum bulletMode { normal, spiral };
    public bulletMode bulletType = bulletMode.normal;

    public static int bulletDamage;
    public int bulletDmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = bulletDmg;
    }

    // Update is called once per frame
    void Update()
    {

        // bullet type switch
        switch (bulletType)
        {
            case bulletMode.normal:
                transform.Translate((transform.up * bulletSpeed * Time.deltaTime) * -1f);
                break;
            case bulletMode.spiral:
                spiralBullet();
                break;
            default:
                transform.Translate((transform.up * bulletSpeed * Time.deltaTime) * -1f);
                break;
        }
        
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Playerbullet hits enemy
        if (other.tag == "Player")
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
}
