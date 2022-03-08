using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    #region parameters
    [SerializeField]
    private int _maxLife = 3;
    [SerializeField]
    private int health = 1;
    [SerializeField]
    private int damage = 1;
    #endregion

    #region properties
    private int _currentLife;
    #endregion

    #region methods

    private void OnTriggerEnter(Collider collision)
    {
        EstaticEnemy_Controller enemy = collision.gameObject.GetComponent<EstaticEnemy_Controller>();
    }
    public void Dano(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    #endregion

    void Start()
    {
        _currentLife = _maxLife;
    }

        
 
}
