using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    public Text hpText;
    public Text switchCD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpUIController();
        SwitchCD();
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
}
