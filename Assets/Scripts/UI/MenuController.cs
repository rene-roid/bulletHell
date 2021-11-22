using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject player, pausePanel;
    private bool isPaused;

    private void Awake()
    {
        isPaused = false;

        try
        {
            pausePanel.SetActive(false);
        } catch
        {

        }

    }

    private void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        try
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                PauseControl();
            }
        }
        catch
        {

        }
    }

    public void PauseControl()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        player.SetActive(!isPaused);
    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Quitting game
        Debug.Log("Quit");
        Application.Quit();
    }
}
