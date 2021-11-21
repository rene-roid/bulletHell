using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public enum enemyModes { none, straight, animation, cabum };
    public enemyModes enemyType = enemyModes.none;

    public float hp = 10;
    public int speed = 5;

    public float burstPoints = 3;


    // Cabum mode
    public Transform target;
    public GameObject player;
    private Vector2 movement;


    public GameObject deathExplosion;

    // Start is called before the first frame update
    void Start()
    {
        if (player)
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case enemyModes.none:
                break;            
            case enemyModes.animation:
                break;
            case enemyModes.straight:
                straightEnemy();
                break;
            case enemyModes.cabum:
                CabumMode();
                break;
            default:
                enemyType = enemyModes.none;
                break;
        }

        if (hp <= 0)
        {
            Debug.Log("yamete kudasai");
            playerBurst.pointsGiven = 3;

            GameObject newExplosion = Instantiate(deathExplosion, transform.position, Quaternion.identity);
            Destroy(newExplosion, 0.3f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player_bullet")
        {
            hp += -playerValues.playerBulletDMG;
        }

        // Only cabum
        if (other.tag == "Player" && enemyType == enemyModes.cabum)
        {
            if (playerValues.partyMember == 1)
            {
                playerValues.playerHP1 -= 20;
            }
            else if (playerValues.partyMember == 2)
            {
                playerValues.playerHP2 -= 20;
            }
            else if (playerValues.partyMember == 3)
            {
                playerValues.playerHP3 -= 20;
            }

            GameObject newExplosion = Instantiate(deathExplosion, transform.position, Quaternion.identity);
            Destroy(newExplosion, 0.3f);

            Destroy(gameObject);
        }
    }

    private void straightEnemy()
    {
        transform.Translate((transform.up * speed * Time.deltaTime) * -1f);
    }

    private void CabumMode()
    {
        if (player)
        {
            // Getting distance between asteroid and player
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            movement = direction;
        }

        // Moving asteroid
        transform.position = (Vector2)transform.position + (movement * speed * Time.deltaTime);
    }
}
