using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    // Flag to indicate if the game is paused
    private bool isPaused = false;
    public GameObject PauseCanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        PauseCanvas.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
        if(isPaused == true)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
    public void ExitToGame()
    {
        Application.Quit();

    }
    //public void LoadNextLevel()
    // {
    // SceneManager.LoadScene(1);
    //  var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    // var NewSceneIndex = currentSceneIndex + 1;
    //  PlayerPrefs.SetInt("CurrentSceneIndex", NewSceneIndex);
    // SceneManager.LoadScene(currentSceneIndex + 1);

    //}
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("CurrentSceneIndex", 1);
        SceneManager.LoadScene(1);
    }
    public void LoadCurrentLevel()
    {
        var CurrentLevel = PlayerPrefs.GetInt("CurrentSceneIndex");
        SceneManager.LoadScene(CurrentLevel);
    }
    private void TogglePauseGame()
    {
        isPaused = !isPaused; // Flip the pause flag

        // Implement pausing logic here:
        if (isPaused)
        {
            // Pause the game (e.g., set Time.timeScale to 0)
            Time.timeScale = 0f;
            PauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            // Optionally, display a pause menu or visual indicator
        }
        else
        {
            // Resume the game (e.g., set Time.timeScale back to 1)
            Time.timeScale = 1f;
            PauseCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            // Optionally, hide the pause menu or visual indicator
        }
    }
    public void GettingBackIntoTheGame()
    {
        // Resume the game (e.g., set Time.timeScale back to 1)
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        // Optionally, hide the pause menu or visual indicator
    }
}

