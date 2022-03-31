using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int health = 1;
    #endregion

    #region references
    private Transform _myTransform;
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
        _myTransform = GetComponent<Transform>();
    }
}
