using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int health = 1;
    #endregion

    #region references
    private Transform _myTransform;
    private HealthDropComponent _myHealthDropComponent;
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

        if (_myHealthDropComponent != null)
        {
            _myHealthDropComponent.TryToDrop(_myTransform.position);
        }
    }

    private void Start()
    {
        _myTransform = GetComponent<Transform>();
        _myHealthDropComponent = GetComponent<HealthDropComponent>();
    }
}
