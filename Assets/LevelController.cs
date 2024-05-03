using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadNextLevel()
    {
      //  SceneManager.LoadScene(1);
      //  var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       // var NewSceneIndex = currentSceneIndex + 1;
      //  PlayerPrefs.SetInt("CurrentSceneIndex", NewSceneIndex);
       // SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void BackToMainMenu()
    {
     //   SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("CurrentSceneIndex", 1);
        //SceneManager.LoadScene(1);
    }
    public void LoadCurrentLevel()
    {
        var CurrentLevel = PlayerPrefs.GetInt("CurrentSceneIndex");
       // SceneManager.LoadScene(CurrentLevel);
    }
}
