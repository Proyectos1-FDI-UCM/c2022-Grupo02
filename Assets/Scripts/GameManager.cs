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
    private CambioNivel _mycambio;    
    #endregion

    #region parameters 
    float timeToDeadScreen = 100f;
    public int scene = 1;
    [SerializeField]
    public float volume = 0.5f;
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
        _myUIManager.UpdatePlayerLife(0);
    }

    public void FinJuego()
    {
        _myPlayer.SetActive(false);//desactivar a Scottie 
        _myUIManager.FinJuego();// llama al Ui Manager
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
        if(scene == 1)
        {
            PlayerPrefs.DeleteKey("magia");
        }
        if (scene == 2)
        {
            PlayerPrefs.DeleteKey("salto");
        }
        if (scene == 3)
        {
            PlayerPrefs.DeleteKey("vida");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
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
        _mycambio = GetComponent<CambioNivel>();
    }

    // Start is called before the first frame update
    void Start()
    {
        do
        {
            _myUIManager = GameObject.Find("UI").GetComponent<UI_Manager>();
        } while (_myUIManager == null);

        do 
        {
            _myPlayer = GameObject.Find("Scottie");
        } while (_myPlayer == null);
        _myInputManager = _myPlayer.GetComponent<InputManager>();
        _myCharacterMovementController = _myPlayer.GetComponent<Character_MovementController>();
        //_myUIManager.UpdatePlayerLife(_myUIManager._inicialHealth);
    }
}
