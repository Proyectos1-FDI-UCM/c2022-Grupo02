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

    #region parameters 
    float timeToDeadScreen = 100f;
    #endregion

    #region methods
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPause()
    {
        _myUIManager.SetPauseMenu(true);
        playerMovementActive(false);
        Time.timeScale = 0.0f;
    }

    public void ContinueGame()
    {
        playerMovementActive(true);
        Time.timeScale = 1.0f;
    }

    public void OnPlayerDies()
    {
        playerMovementActive(false);

        _myUIManager.SetDeadScreen(true);
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

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SaveGameStatus();
        Application.Quit();
    }

    private void playerMovementActive(bool enabled)
    {
        _myCharacterMovementController.enabled = enabled;
        _myInputManager.enabled = enabled;
    }
    #endregion

    void Awake()
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
