using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBurstControl : MonoBehaviour
{
    public Animator movement_anim;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        MirrorBurst();
    }

    // Update is called once per frame
    void Update()
    {
        MirrorBurst();
        anim_mov();
    }

    private void MirrorBurst()
    {
        transform.position = new Vector2(-player.position.x, player.position.y);
    }

    private void anim_mov()
    {
        // Animating the character
        movement_anim.SetFloat("right_speed", -Input.GetAxis("Horizontal"));
        movement_anim.SetFloat("left_speed", -Input.GetAxis("Horizontal"));

        if (playerValues.partyMember == 1)
        {
            movement_anim.SetInteger("partyShip", 1);
        }
        else if (playerValues.partyMember == 2)
        {
            movement_anim.SetInteger("partyShip", 2);
        }
        else if (playerValues.partyMember == 3)
        {
            movement_anim.SetInteger("partyShip", 3);
        }
    }
}
