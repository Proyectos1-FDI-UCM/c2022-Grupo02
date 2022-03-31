using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _pauseMenu; // Objeto que contiene el menú de pausa
    [SerializeField]
    private GameObject _deadMenu; // Objeto que contiene el menú de muerte
    [SerializeField]
    private GameObject _controlsMenu; // Menú de controles

    [SerializeField]
    private GameObject _continueButton; // Botón de continue
    [SerializeField]
    private GameObject _controlsButton; // Botón de controles
    [SerializeField]
    private GameObject _quitButton; // Botón de quit
    [SerializeField]
    private GameObject _backButton; // Botón de back (vuelve de controles al menú de pausa)
    [SerializeField]
    private GameObject _retryButton; // Botón de retry (vuelve a cargar el nivel)

    [SerializeField]
    private Text _finJuego;// Texto de Fin de Juego
    #endregion

    #region parameters
    [SerializeField]
    private GameObject[] _hearts;
    [SerializeField]
    public int _inicialHealth;
    [SerializeField]
    private int _maximumHealth;
    #endregion

    #region methods
    public void UpdatePlayerLife(int _newHP)
    {
        for(int i = 0; i < _newHP; i++)
        {
            _hearts[i].SetActive(true);
        }
        for (int i = _newHP; i < _maximumHealth ; i++)
        {
            _hearts[i].SetActive(false);
        }
    }

    public void SetPauseMenu(bool enabled)
    {
       _pauseMenu.SetActive(enabled);
    }

    public void ContinueGame()
    {
        SetPauseMenu(false);
        GameManager.Instance.ContinueGame();
    }

    public void SetControlsMenu()
    {
        _controlsMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void SetDeadScreen(bool enabled)
    {
        _deadMenu.SetActive(enabled);
    }

    public void BackButton()
    {
        _controlsMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        GameManager.Instance.Quit(); 
    }

    public void RetryLevel()
    {
        //Debug.Log("Retry");
        GameManager.Instance.Retry();
    }

    public void FinJuego()
    {
        _finJuego.enabled = true;// acctivar fin de juego
        //_hearts[1].SetActive(false);
    }
    #endregion

    void Start()
    {
        UpdatePlayerLife(_inicialHealth);
        _finJuego.enabled = false;// desactivar fin de juego por defecto
    }
}
