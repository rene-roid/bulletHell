using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossKnife2 : MonoBehaviour
{
    // Default
    public int knifeSpeed = 15;
    public int knifeDamage = 2;
    public int knifeLife = 2;
    public bool goKnife = false;
    public bool animateKnife = false;

    private Transform target;
    private GameObject player;
    private Vector2 movement;

    private Rigidbody2D rg;

    public int bulletLife = 10;
    private Vector2 anim, limitAnim;

    private float timer = 0;
    public float timeC = 2;

    // Start is called before the first frame update
    void Start()
    {
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
        timer += Time.deltaTime;

        if (timer < timeC)
        {
            AutoAimBullet();
            if (animateKnife)
            {
                if (transform.position.y < limitAnim.y)
                {
                    transform.position = (Vector2)transform.position + (anim * 1 * Time.deltaTime);
                }
            }
        } else
        {
            transform.position = (Vector2)transform.position + (movement * knifeSpeed * Time.deltaTime);
            Destroy(gameObject, knifeLife);
        }
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
