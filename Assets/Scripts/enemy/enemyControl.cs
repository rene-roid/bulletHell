using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public enum enemyModes { none, straight, animation };
    public enemyModes enemyType = enemyModes.none;

    public float hp = 10;
    public int speed = 5;

    public float burstPoints = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerBurst.isTimeStop)
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
                default:
                    enemyType = enemyModes.none;
                    break;
            }

            if (hp <= 0)
            {
                Debug.Log("yamete kudasai");
                playerBurst.pointsGiven = 3;
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player_bullet")
        {
            hp += -playerValues.playerBulletDMG;
            Debug.Log("knya");
            Debug.Log(hp);
        }
    }

    private void straightEnemy()
    {
        transform.Translate((transform.up * speed * Time.deltaTime) * -1f);
    }
}
