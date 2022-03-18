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
        Time.timeScale = 0.0f;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
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
        _myUIManager.UpdatePlayerLife(_myUIManager._inicialHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
