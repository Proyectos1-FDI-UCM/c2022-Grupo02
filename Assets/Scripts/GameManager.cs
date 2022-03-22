using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region references
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private UI_Manager _myUIManager;
    private GameObject _myPlayer;
    #endregion

    #region methods
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPause()
    {
        _myUIManager.SetPauseMenu(true);
        _myPlayer.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ContinueGame()
    {
        _myPlayer.SetActive(true);
        Time.timeScale = 1.0f;
    }

    private void SaveGameStatus()
    {
        PlayerPrefs.SetInt("Magia",/*variable magia*/1);
        PlayerPrefs.SetInt("Salto",/*variable Salto doble*/1);
        PlayerPrefs.SetInt("Vida",/*variable Vida maxima*/1);
        PlayerPrefs.SetInt("Scena",/*variable Vida nivel*/0);
    }

    public void Quit()
    {
        SaveGameStatus();
        Application.Quit();
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myUIManager = GameObject.Find("UI").GetComponent<UI_Manager>();
        _myPlayer = GameObject.Find("Scottie");
        //_myUIManager.UpdatePlayerLife(_myUIManager._inicialHealth);
    }
}
