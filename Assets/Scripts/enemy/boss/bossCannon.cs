using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCannon : MonoBehaviour
{
    public int cannonSpeed = 10;
    Transform cannonsInitalPosition;
    public bool isRed = false;

    private float posX, posY;

    public int cannonDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        cannonsInitalPosition = this.transform;

        if (cannonsInitalPosition.position.x < 0)
        {
            isRed = true;
        } else
        {
            isRed = false;
        }

        posX = transform.position.x;
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (amongUsBoss.goRedCannon && isRed)
        {
            transform.position += transform.right * cannonSpeed * Time.deltaTime;
        } else if (!amongUsBoss.goRedCannon && isRed)
        {
            transform.position = new Vector2(posX, posY);
        }

        if (amongUsBoss.goYellowCannon && !isRed)
        {
            transform.position += -transform.right * cannonSpeed * Time.deltaTime;
        } else if (!amongUsBoss.goYellowCannon && !isRed)
        {
            transform.position = new Vector2(posX, posY);
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
