using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    #region paremeters
    [SerializeField]
    private GameObject _myAttackL;
    [SerializeField]
    private GameObject _myAttackR;
    private int _damage = 2;
    float _crono = 1;
    #endregion

    #region methods
    public void Attack(int _direction)
    {
        if (_direction == 1)
        {
            _myAttackR.SetActive(true);
        }
        else
        {
            _myAttackL.SetActive(true);
        }
            
        _crono = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        EnemyLifeComponent _enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();

        if (_enemy != null)
        {
            _enemy.Damage(_damage);
            Debug.Log(_enemy);
        }
    }
    #endregion

    void Update()
    {
        _crono += Time.deltaTime;
        if (_crono > 0.3f)
        {
            _crono = 0;
            _myAttackL.SetActive(false);
            _myAttackR.SetActive(false);
        }

    }
}
