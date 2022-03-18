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
    #endregion

    #region methods
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _myUIManager = GameObject.Find("HUD").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
