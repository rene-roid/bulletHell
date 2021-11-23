using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Health bar
    public Image lifeBar;
    private float totalLife;

    // Burst bar
    public Image burstBar;
    private float maxBurst = 60;

    // Icon && Name
    public Sprite[] character;
    public string[] playerName;

    public Image renderImage;
    public GameObject playerText;

    // Ammo
    public Text ammoText;

    // Bottom stats
    public GameObject player2, player3;
    public Image lifeBar2, lifeBar3;
    public Image burstBar2, burstBar3;

    // Skills
    public Sprite[] skillsIcons;
    public Image skillRenderer;
    public Image burstRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        HealthBar();
        BurstBar();
        Profile();
        Ammo();
    }

    private void HealthBar()
    {
        switch (playerValues.partyMember)
        {
            case 1:
                totalLife = playerValues.playerMAXHP1;
                break;
            case 2:
                totalLife = playerValues.playerMAXHP2;
                break;
            case 3:
                totalLife = playerValues.playerMAXHP3;
                break;
            default:
                break;
        }

        if (playerValues.partyMember == 1)
        {
            float finalLife = playerValues.playerHP1 / totalLife;
            lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, finalLife, 0.6f * Time.deltaTime);

            // Side characters hp
            SideCharacterStats(playerValues.playerHP2, playerValues.playerMAXHP2, playerName[1], playerValues.playerHP3, playerValues.playerMAXHP3, playerName[2], playerValues.plyrBurst2, playerValues.plyrBurst3);

        } else if (playerValues.partyMember == 2)
        {
            float finalLife = playerValues.playerHP2 / totalLife;
            lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, finalLife, 0.6f * Time.deltaTime);

            // Side characters hp
            SideCharacterStats(playerValues.playerHP1, playerValues.playerMAXHP1, playerName[0], playerValues.playerHP3, playerValues.playerMAXHP3, playerName[2], playerValues.plyrBurst2, playerValues.plyrBurst3);

        } else if (playerValues.partyMember == 3)
        {
            float finalLife = playerValues.playerHP3 / totalLife;
            lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, finalLife, 0.6f * Time.deltaTime);

            // Side characters hp
            SideCharacterStats(playerValues.playerHP1, playerValues.playerMAXHP1, playerName[0], playerValues.playerHP2, playerValues.playerMAXHP2, playerName[1], playerValues.plyrBurst2, playerValues.plyrBurst3);
        }

    }

    private void BurstBar()
    {
        if (playerValues.partyMember == 1)
        {
            float actualBurst = playerValues.plyrBurst1 / maxBurst;
            burstBar.fillAmount = Mathf.MoveTowards(burstBar.fillAmount, actualBurst, 0.6f * Time.deltaTime);
        }
        else if (playerValues.partyMember == 2)
        {
            float actualBurst = playerValues.plyrBurst2 / maxBurst;
            burstBar.fillAmount = Mathf.MoveTowards(burstBar.fillAmount, actualBurst, 0.6f * Time.deltaTime);
        }
        else if (playerValues.partyMember == 3)
        {
            float actualBurst = playerValues.plyrBurst3 / maxBurst;
            burstBar.fillAmount = Mathf.MoveTowards(burstBar.fillAmount, actualBurst, 0.6f * Time.deltaTime);
        }
    }

    private void Profile()
    {
        if (playerValues.partyMember == 1)
        {
            renderImage.sprite = character[0];
            playerText.GetComponentInChildren<TextMeshProUGUI>().text = playerName[0];

            // Skill/Burst
            skillBurstRenderer(skillsIcons[0], skillsIcons[1]);
        }
        else if (playerValues.partyMember == 2)
        {
            renderImage.sprite = character[1];
            playerText.GetComponentInChildren<TextMeshProUGUI>().text = playerName[1];

            skillBurstRenderer(skillsIcons[2], skillsIcons[3]);
        }
        else if (playerValues.partyMember == 3)
        {
            renderImage.sprite = character[2];
            playerText.GetComponentInChildren<TextMeshProUGUI>().text = playerName[2];

            skillBurstRenderer(skillsIcons[4], skillsIcons[5]);
        }
    }

    private void Ammo()
    {
        if (playerValues.partyMember == 1)
        {
            ammoText.text = cannonControl.Pamo1.ToString();
        }
        else if (playerValues.partyMember == 2)
        {
            ammoText.text = cannonControl.Pamo2.ToString();
        }
        else if (playerValues.partyMember == 3)
        {
            ammoText.text = cannonControl.Pamo3.ToString();
        }
    }

    private void SideCharacterStats(float _side2HP, float side2totalHP, string _side2Name, float _side3HP, float side3totalHP, string _side3Name, float _side2Burst, float _side3Burst)
    {
        float finalLife2 = _side2HP / side2totalHP; // Player hp
        lifeBar2.fillAmount = Mathf.MoveTowards(lifeBar2.fillAmount, finalLife2, 0.6f * Time.deltaTime);
        // Player name
        player2.GetComponentInChildren<TextMeshProUGUI>().text = _side2Name;
        // Player burst
        float finalBurst2 = _side2Burst / 60f;
        burstBar2.fillAmount = Mathf.MoveTowards(burstBar2.fillAmount, finalBurst2, 0.6f * Time.time);
        
        float finalLife3 = _side3HP / side3totalHP;
        lifeBar3.fillAmount = Mathf.MoveTowards(lifeBar3.fillAmount, finalLife3, 0.6f * Time.deltaTime);
        player3.GetComponentInChildren<TextMeshProUGUI>().text = _side3Name;
        float finalBurst3 = _side3Burst / 60f;
        burstBar3.fillAmount = Mathf.MoveTowards(burstBar3.fillAmount, finalBurst3, 0.6f * Time.time);
    }

    private void skillBurstRenderer(Sprite _skill, Sprite _burst)
    {
        skillRenderer.sprite = _skill;
        burstRenderer.sprite = _burst;
    }
}
