using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _pauseMenu;
    #endregion
    #region parameters
    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private int _inicialHealth;
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
        _mainMenu.SetActive(enabled); 
    }
    
    public void SetContinueButton(bool enabled)
    {
        _continueButton.SetActive(enabled); 
    }

    /// Calls Game Manager method to Quit Game.
    public void QuitGame()
    {
        GameManager.Instance.QuitGame(); //Instancia el Game Manager (QuitGame).
    }
    #endregion


    void Start()
    {
        UpdatePlayerLife(_inicialHealth);
    }

    void Update()
    {
        
    }
}
