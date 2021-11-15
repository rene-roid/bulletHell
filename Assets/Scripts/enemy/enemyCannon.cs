using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCannon : MonoBehaviour
{
    public enum enemyCanon { none, straight, point };
    public enemyCanon cannonType = enemyCanon.none;

    public float fireRate = 0.1f;
    private float timepassed;
    public GameObject enemyBullet;

    public Transform target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timepassed = Time.time;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerBurst.isTimeStop)
        {
            switch (cannonType)
            {
                case enemyCanon.none:
                    break;
                case enemyCanon.straight:
                    straightBullet();
                    break;
                case enemyCanon.point:
                    pointCannon();
                    break;
                default:
                    cannonType = enemyCanon.none;
                    break;
            }
        }

    }

    private void straightBullet()
    {
        if (Time.time > timepassed)
        {
            GameObject bulletCopy = Instantiate(enemyBullet, transform.position, transform.rotation);
            Destroy(bulletCopy, 2);
            timepassed = Time.time + fireRate;
        }
    }

    private void pointCannon()
    {
        if (Time.time > timepassed)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
            GameObject bulletCopy = Instantiate(enemyBullet, transform.position, transform.rotation);
            Destroy(bulletCopy, 2);
            timepassed = Time.time + fireRate;
        }
    }
}
