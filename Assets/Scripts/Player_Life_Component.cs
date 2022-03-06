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
    #endregion

    #region properties
    private int _currentLife;
    #endregion

    #region methods

    private void OnTriggerEnter(Collider collision)
    {
        EstaticEnemy_Controller enemy = collision.gameObject.GetComponent<EstaticEnemy_Controller>();

        if(enemy != null) { enemy.Choose();}
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
    }

        
 
}
