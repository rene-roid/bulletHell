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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        HealthBar();
        BurstBar();
        Profile();
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
}
