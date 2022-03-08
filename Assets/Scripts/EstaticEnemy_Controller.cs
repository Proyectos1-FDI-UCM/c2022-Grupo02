using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaticEnemy_Controller : MonoBehaviour
{
    #region parameters
    private float change;
    [SerializeField]
    private int health = 3;
    #endregion
    #region references
    [SerializeField]
    Transform _ScottieTransform;
    Transform _myTransform;
    #endregion

    #region methods
    private void EatLeft()
    {
        gameObject.GetComponent<Animator>().SetBool("EatLeft", true);
    }

    private void EatRight()
    {
        gameObject.GetComponent<Animator>().SetBool("EatRight", true);
    }

    public void Choose()
    {
        if (_ScottieTransform.position.x > _myTransform.position.x) { EatLeft(); }
        else if (_ScottieTransform.position.x < _myTransform.position.x) { EatRight(); }
    }
    #endregion

    void Update()
    {
        if(Time.time >= change)
        {
            gameObject.GetComponent<Animator>().SetBool("EatRight", false);
            gameObject.GetComponent<Animator>().SetBool("EatLeft", false);
            change = Time.time + 0.5f;
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
