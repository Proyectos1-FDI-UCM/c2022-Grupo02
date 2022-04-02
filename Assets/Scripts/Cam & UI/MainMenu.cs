using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private CambioNivel _mycambionivel;
    private LoadScript _myloadscript;
    private GameManager _mygamemanager;
    void start()
    {
        _mygamemanager = GetComponent<GameManager>();
        _mycambionivel = GetComponent<CambioNivel>();
    }
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(_mygamemanager.scene);
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
