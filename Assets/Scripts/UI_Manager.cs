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
    private GameObject _continueButton; // Botón de continue
    [SerializeField]
    private GameObject _controlsButton; // Botón de controles
    [SerializeField]
    private GameObject _quitButton; // Botón de quit
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
        Debug.Log("Controles");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        GameManager.Instance.Quit(); 
    }
    #endregion

    void Start()
    {
        UpdatePlayerLife(_inicialHealth);
    }


}
