using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int n = 0;

        while (n < playerValues.levelsUnlocked)
        {
            buttons[n].GetComponent<Button>().interactable = true;
            n++;
        }
    }
}
