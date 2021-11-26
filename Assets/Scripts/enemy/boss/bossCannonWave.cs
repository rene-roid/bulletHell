using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCannonWave : MonoBehaviour
{
    public int cannonSpeed = 10;
    Transform cannonsInitalPosition;
    public int cannonDamage = 10;

    private float posX, posY;

    public bool goCannon = false;

    public float timer;
    private float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        cannonsInitalPosition = this.transform;

        posX = transform.position.x;
        posY = transform.position.y;

        maxTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (goCannon)
        {
            transform.position += transform.right * cannonSpeed * Time.deltaTime;

            timer -= Time.deltaTime;
            if (timer <= 0) { goCannon = false; }
        }
        else if (!goCannon)
        {
            transform.position = new Vector2(posX, posY);
            timer = maxTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Playerbullet hits enemy
        if (other.tag == "Player" || other.tag == "shield_skill")
        {
            if (playerValues.partyMember == 1) { playerValues.playerHP1 -= cannonDamage; }
            if (playerValues.partyMember == 2) { playerValues.playerHP2 -= cannonDamage; }
            if (playerValues.partyMember == 3) { playerValues.playerHP3 -= cannonDamage; }
        }
    }
}
