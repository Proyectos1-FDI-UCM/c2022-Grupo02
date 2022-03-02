using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    #region parameters
    [SerializeField]
    private int _maxLife = 3;
    [SerializeField]
    private int _hitDamage = 1;
    private Transform _myTransform;
    private Transform _targetTransform;
    [SerializeField]
    private GameObject _targetObject;
    #endregion

    #region properties
    private int _currentLife;
    #endregion

    #region methods

    private void OnTriggerEnter(Collider collision)
    {
        EstaticEnemy_Controller enemy = collision.gameObject.GetComponent<EstaticEnemy_Controller>();

        if(enemy != null && _myTransform.position.x > _targetTransform.position.x) { enemy.EatLeft();}
        else if(enemy != null && _myTransform.position.x < _targetTransform.position.x) { enemy.EatRight(); }
        Damage();
    }

    public void Damage()
    {
        _currentLife = _currentLife - _hitDamage;
        if (_currentLife == 0)
        {
            _currentLife = _maxLife;
        }
    }
    #endregion

    void Start()
    {
        _currentLife = _maxLife;
        _myTransform = GetComponent<Transform>();
        _targetTransform = _targetObject.GetComponent<Transform>();
    }

        
 
}
