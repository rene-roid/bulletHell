using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public int speed = 10;
    public Animator movement_anim;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, -4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        anim_mov();
        print(playerValues.playerHP);
    }
    private void movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        transform.Translate(Vector2.up * speed * Time.deltaTime * Input.GetAxis("Vertical"));

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
        if(other.tag == "Enemy") { playerValues.playerHP -= 5; }
        if(other.tag == "enemy_bullet") { PlayerTakeDamage(); }
    }

    void PlayerTakeDamage()
    {
        playerValues.playerHP = playerValues.playerHP - enemyBullet.bulletDamage;
    }
}
