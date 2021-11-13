using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    public Text hpText;
    public Text switchCD;
    public Text DMGText; // Temp

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpUIController();
        SwitchCD();
        DMGUIController();
    }

    private void HpUIController()
    {
        hpText.text = "Player 1: " + playerValues.playerHP1 + '\n' +
                      "Player 2: " + playerValues.playerHP2 + '\n' +
                      "Player 3: " + playerValues.playerHP3;
    }

    private void SwitchCD()
    {
        switchCD.text = "Switch: ";
    }

    private void DMGUIController()
    {
        DMGText.text = "Player 1: " + playerValues.player1BulletDMG + '\n' +
                      "Player 2: " + playerValues.player2BulletDMG + '\n' +
                      "Player 3: " + playerValues.player3BulletDMG;
    }

}
