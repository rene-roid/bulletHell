using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelControl : MonoBehaviour
{
    public GameObject levelCompletedCanvas;

    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        levelCompletedCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager.levelCompleted)
        {
            levelCompletedCanvas.SetActive(true);
        }
    }

    public void AddLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel + 1 > playerValues.levelsUnlocked)
        {
            playerValues.levelsUnlocked = currentLevel + 1;
        }
    }

    public void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
