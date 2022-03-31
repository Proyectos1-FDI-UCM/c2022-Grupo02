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
    private InputManager _myInputManager;
    private Character_MovementController _myCharacterMovementController;
    #endregion

    #region methods
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPause()
    {
        _myUIManager.SetPauseMenu(true);
        _myInputManager.enabled = false;
        _myCharacterMovementController.enabled = false;
        Time.timeScale = 0.0f;
    }

    public void ContinueGame()
    {
        _myInputManager.enabled = true;
        _myCharacterMovementController.enabled = true;
        Time.timeScale = 1.0f;
    }

    public void Death()
    {
        _myCharacterMovementController.enabled = false;
        _myInputManager.enabled = false;
    }

    public void FinJuego()
    {
        //desactivar a Scottie 
        //Activar el texto de la puntuación
        //Activar el texto de Fin de Juego
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
        _myInputManager = _myPlayer.GetComponent<InputManager>();
        _myCharacterMovementController = _myPlayer.GetComponent<Character_MovementController>();
        //_myUIManager.UpdatePlayerLife(_myUIManager._inicialHealth);
    }
}
