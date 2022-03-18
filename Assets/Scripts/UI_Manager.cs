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
    private GameObject[] hearts;
    [SerializeField]
    public int _inicialHealth;
    #endregion

    #region methods
    public void UpdatePlayerLife(int newLife)
    {
        for(int i = 0; i < newLife; i++)
        {
            hearts[i].SetActive(true);
        }
        for (int i = newLife; i < 6 ; i++)
        {
            hearts[i].SetActive(false);
        }
        //Debug.Log("Buenas tardes");
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
        Debug.Log("controles");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        GameManager.Instance.Quit(); 
    }
    #endregion
}
