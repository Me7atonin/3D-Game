using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    string levelToLoad = "Play";
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Controls()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void HowToPlay()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void QuitGame() {
    Application.Quit();
    }
}