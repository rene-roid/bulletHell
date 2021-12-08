using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Secret : MonoBehaviour
{
    public Button[] Add;
    public Button[] Subs;
    public GameObject[] info;

    public GameObject panel;

    private KeyCode[] sequence = new KeyCode[] {
        KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.B, KeyCode.A
    };

    private int sequenceIndex;

    private void Start()
    {
        SyncStats();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(sequence[sequenceIndex]))
        {
            if (++sequenceIndex == sequence.Length)
            {
                sequenceIndex = 0;
                // sequence typed
                panel.SetActive(true);
            }
        }
        else if (Input.anyKeyDown) sequenceIndex = 0;
    }

    // HP
    public void PlayerHP1Add()
    {
        playerValues.playerMAXHP1++;
        info[0].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP1.ToString();
    }
    public void PlayerHP1Subs()
    {
        playerValues.playerMAXHP1--;

        if (playerValues.playerMAXHP1 < 1)
        {
            playerValues.playerMAXHP1 = 1;
        }

        info[0].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP1.ToString();
    }
    public void PlayerHP2Add()
    {
        playerValues.playerMAXHP2++;
        info[1].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP2.ToString();
    }
    public void PlayerHP2Subs()
    {
        playerValues.playerMAXHP2--;

        if (playerValues.playerMAXHP2 < 1)
        {
            playerValues.playerMAXHP2 = 1;
        }

        info[1].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP2.ToString();
    }
    public void PlayerHP3Add()
    {
        playerValues.playerMAXHP3++;
        info[2].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP3.ToString();
    }
    public void PlayerHP3Subs()
    {
        playerValues.playerMAXHP3--;

        if (playerValues.playerMAXHP3 < 1)
        {
            playerValues.playerMAXHP3 = 1;
        }

        info[2].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP3.ToString();
    }

    // DMG
    public void PlayerDMG1Add()
    {
        playerValues.player1BulletDMG++;

        if (playerValues.player1BulletDMG < 1)
        {
            playerValues.player1BulletDMG = 1;
        }

        info[3].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player1BulletDMG.ToString();
    }
    public void PlayerDMG1Subs()
    {
        playerValues.player1BulletDMG--;
        info[3].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player1BulletDMG.ToString();
    }
    public void PlayerDMG2Add()
    {
        playerValues.player2BulletDMG++;
        info[4].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player2BulletDMG.ToString();
    }
    public void PlayerDMG2Subs()
    {
        playerValues.player2BulletDMG--;

        if (playerValues.player2BulletDMG < 1)
        {
            playerValues.player2BulletDMG = 1;
        }

        info[4].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player2BulletDMG.ToString();
    }
    public void PlayerDMG3Add()
    {
        playerValues.player3BulletDMG++;
        info[5].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player3BulletDMG.ToString();
    }
    public void PlayerDMG3Subs()
    {
        playerValues.player3BulletDMG--;

        if (playerValues.player3BulletDMG < 1)
        {
            playerValues.player3BulletDMG = 1;
        }

        info[5].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player3BulletDMG.ToString();
    }

    // AMO
    public void PlayerAMO1Add()
    {
        playerValues.maxAmmo1++;
        info[6].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo1.ToString();
    }
    public void PlayerAMO1Subs()
    {
        playerValues.maxAmmo1--;

        if (playerValues.maxAmmo1 < 1)
        {
            playerValues.maxAmmo1 = 1;
        }

        info[6].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo1.ToString();
    }
    public void PlayerAMO2Add()
    {
        playerValues.maxAmmo2++;
        info[7].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo2.ToString();
    }
    public void PlayerAMO2Subs()
    {
        playerValues.maxAmmo2--;

        if (playerValues.maxAmmo2 < 1)
        {
            playerValues.maxAmmo2 = 1;
        }

        info[7].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo2.ToString();
    }
    public void PlayerAMO3Add()
    {
        playerValues.maxAmmo3++;
        info[8].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo3.ToString();
    }
    public void PlayerAMO3Subs()
    {
        playerValues.maxAmmo3--;

        if (playerValues.maxAmmo3 < 1)
        {
            playerValues.maxAmmo3 = 1;
        }

        info[8].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo3.ToString();
    }

    // Levels
    public void LevelsAdd()
    {
        playerValues.levelsUnlocked++;

        if (playerValues.levelsUnlocked > 5)
        {
            playerValues.levelsUnlocked = 5;
            info[9].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.levelsUnlocked.ToString();
        }

        info[9].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.levelsUnlocked.ToString();
    }
    public void LevelsSubs()
    {
        playerValues.levelsUnlocked--;

        if (playerValues.levelsUnlocked < 1)
        {
            playerValues.levelsUnlocked = 1;
            info[9].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.levelsUnlocked.ToString();
        }

        info[9].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.levelsUnlocked.ToString();
    }


    // Sync
    private void SyncStats()
    {
        info[0].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP1.ToString();
        info[1].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP2.ToString();
        info[2].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.playerMAXHP3.ToString();
        info[3].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player1BulletDMG.ToString();
        info[4].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player2BulletDMG.ToString();
        info[5].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.player3BulletDMG.ToString();
        info[6].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo1.ToString();
        info[7].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo2.ToString();
        info[8].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.maxAmmo3.ToString();
        info[9].GetComponentInChildren<TextMeshProUGUI>().text = playerValues.levelsUnlocked.ToString();
    }
}
