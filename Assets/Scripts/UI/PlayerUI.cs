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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BottomUI();
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
        } else if (playerValues.partyMember == 2)
        {
            float finalLife = playerValues.playerHP2 / totalLife;
            lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, finalLife, 0.6f * Time.deltaTime);
        } else if (playerValues.partyMember == 3)
        {
            float finalLife = playerValues.playerHP3 / totalLife;
            lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, finalLife, 0.6f * Time.deltaTime);
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
        }
        else if (playerValues.partyMember == 2)
        {
            renderImage.sprite = character[1];
            playerText.GetComponentInChildren<TextMeshProUGUI>().text = playerName[1];
        }
        else if (playerValues.partyMember == 3)
        {
            renderImage.sprite = character[2];
            playerText.GetComponentInChildren<TextMeshProUGUI>().text = playerName[2];
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

    private void BottomUI()
    {
        if (playerValues.partyMember == 1)
        {
            BottomUIController(playerValues.playerHP2, playerValues.playerHP3, playerValues.playerMAXHP2, playerValues.playerMAXHP3, playerValues.plyrBurst2, playerValues.plyrBurst3, playerName[1], playerName[2]);
        }
        else if (playerValues.partyMember == 2)
        {
            BottomUIController(playerValues.playerHP1, playerValues.playerHP3, playerValues.playerMAXHP1, playerValues.playerMAXHP3, playerValues.plyrBurst1, playerValues.plyrBurst3, playerName[0], playerName[2]);
        }
        else if (playerValues.partyMember == 3)
        {
            BottomUIController(playerValues.playerHP1, playerValues.playerHP2, playerValues.playerMAXHP1, playerValues.playerMAXHP2, playerValues.plyrBurst1, playerValues.plyrBurst2, playerName[0], playerName[1]);
        }
    }

    private void BottomUIController(float _player2HP, float _player3HP, float _player2maxHP, float _playermax3HP, float _player2Burst, float _player3Burst, string _player2Name, string _player3Name)
    {
        // Player 2
        // HP2
        float finalLife2 = _player2HP / _player2maxHP;
        lifeBar2.fillAmount = Mathf.MoveTowards(lifeBar2.fillAmount, finalLife2, 0.6f * Time.deltaTime);
        // Burst2
        float actualBurst2 = _player2Burst / maxBurst;
        burstBar2.fillAmount = Mathf.MoveTowards(burstBar2.fillAmount, actualBurst2, 0.6f * Time.deltaTime);
        // Name
        player2.GetComponentInChildren<TextMeshProUGUI>().text = _player2Name;

        // Player 3
        // HP2
        float finalLife3 = _player3HP / _playermax3HP;
        lifeBar2.fillAmount = Mathf.MoveTowards(lifeBar3.fillAmount, finalLife3, 0.6f * Time.deltaTime);
        // Burst2
        float actualBurst3 = _player3Burst / maxBurst;
        burstBar3.fillAmount = Mathf.MoveTowards(burstBar3.fillAmount, actualBurst3, 0.6f * Time.deltaTime);
        // Name
        player3.GetComponentInChildren<TextMeshProUGUI>().text = _player3Name;
    }
}
