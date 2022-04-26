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
    public void PruebaCombate()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }
    public void PruebaMovimiento()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
    public void PruebaPowerUp()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
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
