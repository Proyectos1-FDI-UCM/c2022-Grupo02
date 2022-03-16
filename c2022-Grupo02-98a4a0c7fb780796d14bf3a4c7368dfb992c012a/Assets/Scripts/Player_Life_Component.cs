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
    private float change;
    #endregion

    #region properties
    private int _currentLife;
    #endregion

    #region methods
    public void damage(int damage)
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        health -= damage;
        if (health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Death", true);
        }
    }
    #endregion

    void Start()
    {
        _currentLife = _maxLife;
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
