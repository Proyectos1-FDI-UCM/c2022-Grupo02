using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    public int health = 1;
    [SerializeField]
    public int maxHealth = 20;
    #endregion

    #region references
    private Transform _myTransform;
    public HealthBar HealthBar;

    #endregion

    public void Damage(int Damage)
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        health -= Damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.FinJuego();
        
    }

    private void Start()
    {
        health = maxHealth;
        HealthBar.SetHealth(health, maxHealth);
        _myTransform = GetComponent<Transform>();
       
    }
}
