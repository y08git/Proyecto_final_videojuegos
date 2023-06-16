using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuit : MonoBehaviour
{
    [SerializeField] Button _quitGame;
    // Start is called before the first frame update
    void Start()
    {
        _quitGame.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
