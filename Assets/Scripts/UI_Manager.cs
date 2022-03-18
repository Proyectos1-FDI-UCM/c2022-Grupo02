using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

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
    #endregion




    void Start()
    {
        UpdatePlayerLife(_inicialHealth);
    }

    void Update()
    {
        
    }
}
