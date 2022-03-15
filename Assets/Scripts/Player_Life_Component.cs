using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    #region parameters
    [SerializeField]
    private int _maxLife = 3;
    [SerializeField]
    private int health = 3;
    private float change = 0;
    #endregion

    #region properties
    private int _currentLife;
    #endregion

    #region references
    [SerializeField]
    private UI_Manager _myUIManager;
    #endregion

    #region methods
    public void damage(int damage)
    {
        //Debug.Log(_myUIManager == null);
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        health -= damage;
        if (health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Death", true);
        }
        _myUIManager.UpdatePlayerLife(health);

    }
    #endregion

    void Start()
    {
        _currentLife = _maxLife;
        //_myUIManager = GetComponent<UI_Manager>();
    }

    void Update()
    {
        if (Time.time >= change)// cambiar el booleano a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", false);
            change = Time.time + 0.5f;
        }
    }

        
 
}
