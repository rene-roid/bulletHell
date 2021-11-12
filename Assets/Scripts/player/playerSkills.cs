using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkills : MonoBehaviour
{
    // Public Vars shield
    public float ShieldSkillCooldown;
    public float ShieldSkillDuration;
    public GameObject Shield;

    // Private Vars shield
    private float shieldTime;
    private float nextShield;

    // Public vars team heal
    [Range(0.0f, 100.0f)] public float mySliderFloat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShieldSkill();
    }

    private void ShieldSkill()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextShield)
        {
            Shield.SetActive(true); // Activating Shield

            shieldTime = Time.time + ShieldSkillDuration; // Calculating duration of shield
            nextShield = Time.time + ShieldSkillDuration + ShieldSkillCooldown; // Calculating next shield
        }

        // Turning off shield when timer runs out
        if (Time.time >= shieldTime)
        {
            Shield.SetActive(false);
        }
    }

    private void teamHeal()
    {
        
    }
}
