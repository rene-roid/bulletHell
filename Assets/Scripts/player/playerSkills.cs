using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkills : MonoBehaviour
{
    // Public vars shield
    public float ShieldSkillCooldown;
    public float ShieldSkillDuration;
    public GameObject Shield;

    // Private vars shield
    private float shieldTime;
    private float nextShield;

    // Public vars team heal
    [Range(0.0f, 1.0f)] public float healPercentage;
    public float healSkillCooldown;

    // Private vars team heal
    private float nextHeal;

    // Public vars team buff
    [Range(0.0f, 1.0f)] public float buffPercentage;
    public float BuffSkillDuration;
    public float buffSkillCooldown;

    // Private vars team buff
    private float buffTime;
    private float nextBuff;
    private float bulletDamage1, bulletDamage2, bulletDamage3;

    private void Awake()
    {
        bulletDamage1 = playerValues.player1BulletDMG;
        bulletDamage2 = playerValues.player2BulletDMG;
        bulletDamage3 = playerValues.player3BulletDMG;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerValues.partyMember)
        {
            case 1:
                StartCoroutine(ShieldSkill());
                break;
            case 2:
                StartCoroutine(TeamBuff()); 
                break;
            case 3:
                StartCoroutine(TeamHeal());
                break;
            default:
                break;
        }
        CheckTruco();
    }


    IEnumerator ShieldSkill()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextShield)
        {
            Shield.SetActive(true); // Activating Shield

            shieldTime = Time.time + ShieldSkillDuration; // Calculating duration of shield
            nextShield = Time.time + ShieldSkillDuration + ShieldSkillCooldown; // Calculating next shield
            yield return null;
        }
    }

    IEnumerator TeamHeal()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextHeal)
        {
            GetComponent<ShipGlowController>().Heal();
            playerValues.playerHP1 += (playerValues.playerMAXHP1 * healPercentage);
            playerValues.playerHP2 += (playerValues.playerMAXHP2 * healPercentage);
            playerValues.playerHP3 += (playerValues.playerMAXHP3 * healPercentage);
            nextHeal = Time.time + healSkillCooldown;
            yield return null;
        }
    }

    IEnumerator TeamBuff()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextBuff)
        {
            playerValues.player1BulletDMG += (playerValues.player1BulletDMG * buffPercentage);
            playerValues.player2BulletDMG += (playerValues.player2BulletDMG * buffPercentage);
            playerValues.player3BulletDMG += (playerValues.player3BulletDMG * buffPercentage);

            buffTime = Time.time + BuffSkillDuration;
            nextBuff = Time.time + BuffSkillDuration + buffSkillCooldown;
            yield return null;
        }
    }

    private void CheckTruco()
    {
        // ShieldSkill
        if (Time.time >= shieldTime) // Turning off shield when timer runs out
        {
            Shield.SetActive(false);
        }

        // TeamBuffSkill
        if (Time.time >= buffTime) // Reverting buff when it runs out
        {
            playerValues.player1BulletDMG = bulletDamage1;
            playerValues.player2BulletDMG = bulletDamage2;
            playerValues.player3BulletDMG = bulletDamage3;
        }
    }
}
