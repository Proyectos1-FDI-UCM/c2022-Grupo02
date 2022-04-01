using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private CambioNivel _mycambionivel;
    private LoadScript _myloadscript;
    void start()
    {
        _mycambionivel = GetComponent<CambioNivel>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(_mycambionivel.scene);
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
