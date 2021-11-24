using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossKnife : MonoBehaviour
{
    // Default
    public static int knifeSpeed = 5;

    public static int bulletDamage;
    public int bulletDmg = 1;

    private Transform target;
    private GameObject player;
    private Vector2 movement;


    public GameObject deathExplosion;
    private Rigidbody2D rg;

    public int bulletLife = 10;

    private Vector2 anim, limitAnim;

    public int knifeDamage = 2;

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
        }
        catch
        {

        }

        anim = new Vector2(transform.position.x, transform.position.y + .5f);
        limitAnim = anim;

    }

    // Update is called once per frame
    void Update()
    {
        if (amongUsBoss.isAiming)
        {

            if (transform.position.y < limitAnim.y)
            {
                transform.position = (Vector2)transform.position + (anim * 1 * Time.deltaTime);
            }
            AutoAimBullet();
        } else
        {
            // Moving knife
            transform.position = (Vector2)transform.position + (movement * knifeSpeed * Time.deltaTime);
        }
        Destroy(gameObject, bulletLife);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "shield_skill")
        {
            Destroy(gameObject);
        }

        // Playerbullet hits enemy
        if (other.tag == "Player")
        {
            if (playerValues.partyMember == 1) { playerValues.playerHP1 -= knifeDamage; }
            if (playerValues.partyMember == 2) { playerValues.playerHP2 -= knifeDamage; }
            if (playerValues.partyMember == 3) { playerValues.playerHP3 -= knifeDamage; }
            Destroy(gameObject);
        }
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
    }


}
