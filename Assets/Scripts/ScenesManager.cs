using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        TitleScreen,
        Level1,
        Level2
    }
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void NewGame()
    {
        SceneManager.LoadScene(Scene.Level1.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(Scene.TitleScreen.ToString());
    }
}
