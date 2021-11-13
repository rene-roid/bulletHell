using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float playerSwitchCD;

    private float switchCoolDown = 0;
    private int speed;
    public Animator movement_anim;

    // Start is called before the first frame update
    void Start()
    {
        // Initial position
        transform.position = new Vector2(0, -4.0f);

        // Setting up cooldown
        switchCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {

        SwitchingPlayer();

        // Giving stats depending on ship type
        switch (playerValues.partyMember)
        {
            case 1: // Party member 1 values
                speed = playerValues.player1Speed;
                cannonControl.fireRateShip = 0.1f;
                playerValues.playerBulletDMG = playerValues.player1BulletDMG; 
                break;
            case 2: // Party member 2 values
                speed = playerValues.player2Speed;
                cannonControl.fireRateShip = 0.5f;
                playerValues.playerBulletDMG = playerValues.player2BulletDMG; 
                break;
            case 3: // Party member 3 values
                cannonControl.fireRateShip = 1f;
                speed = playerValues.player3Speed;
                playerValues.playerBulletDMG = playerValues.player3BulletDMG; 
                break;
            default:
                playerValues.partyMember = 1;
                break;
        }

        movement();
        anim_mov();
        teamHPControl();
    }
    private void movement()
    {
        transform.Translate(Vector2.right * speed * Time.unscaledDeltaTime * Input.GetAxis("Horizontal"));
        transform.Translate(Vector2.up * speed * Time.unscaledDeltaTime * Input.GetAxis("Vertical"));

        if (transform.position.y > 2.5f)
        {
            transform.position = new Vector2(transform.position.x, 2.5f);
        }
        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }

        if (transform.position.x < -8.4f)
        {
            transform.position = new Vector2(-8.4f, transform.position.y);
        }
        else if (transform.position.x > 8.4f)
        {
            transform.position = new Vector2(8.4f, transform.position.y);
        }
    }

    private void anim_mov()
    {
        // Animating the character
        movement_anim.SetFloat("right_speed", Input.GetAxis("Horizontal"));
        movement_anim.SetFloat("left_speed", Input.GetAxis("Horizontal"));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy") { PlayerTakeDamage(5); }
        if(other.tag == "enemy_bullet") { PlayerTakeDamage(enemyBullet.bulletDamage); }
    }

    void PlayerTakeDamage(int _damage)
    {
        switch (playerValues.partyMember)
        {
            case 1:
                playerValues.playerHP1 = playerValues.playerHP1 - _damage;
                break;
            case 2:
                playerValues.playerHP2 = playerValues.playerHP2 - _damage;
                break;
            case 3:
                playerValues.playerHP3 = playerValues.playerHP3 - _damage;
                break;
            default:
                break;
        }
    }

    private void SwitchingPlayer()
    {
        // switching player to a different character with cooldown
        if (Input.GetKeyDown(KeyCode.Alpha1) && switchCoolDown <= Time.time && playerValues.partyMember != 1)
        {
            playerValues.partyMember = 1; switchCoolDown = playerSwitchCD + Time.time; movement_anim.SetInteger("partyShip", 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && switchCoolDown <= Time.time && playerValues.partyMember != 2)
        {
            playerValues.partyMember = 2; switchCoolDown = playerSwitchCD + Time.time; movement_anim.SetInteger("partyShip", 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && switchCoolDown <= Time.time && playerValues.partyMember != 3)
        {
            playerValues.partyMember = 3; switchCoolDown = playerSwitchCD + Time.time; movement_anim.SetInteger("partyShip", 3);
        }
    }

    private void teamHPControl()
    {
        if (playerValues.playerHP1 > playerValues.playerMAXHP1) { playerValues.playerHP1 = playerValues.playerMAXHP1; }
        if (playerValues.playerHP2 > playerValues.playerMAXHP2) { playerValues.playerHP2 = playerValues.playerMAXHP2; }
        if (playerValues.playerHP3 > playerValues.playerMAXHP3) { playerValues.playerHP3 = playerValues.playerMAXHP3; }
    }
}
