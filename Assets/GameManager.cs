using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region references
    public GameObject player;
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    //public Text gameOverText;

    public Text textoContador;
    public int contador;
    #endregion

    #region parameters
    private bool _isGameRunning = true;
    #endregion

    #region methods
    private void gameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        _isGameRunning = false;
       //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //foreach (GameObject enemy in enemies)
            //GameObject.Destroy(enemy);
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject Player in player)
            GameObject.Destroy(Player);
   
    }

    public void OnEnemyReachesBL()
    {
        GameManager.Instance.gameOver();
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
