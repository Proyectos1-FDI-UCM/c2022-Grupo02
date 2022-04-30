using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueDestructible : MonoBehaviour
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
        health -= Damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _myTransform = GetComponent<Transform>();
    }
}

