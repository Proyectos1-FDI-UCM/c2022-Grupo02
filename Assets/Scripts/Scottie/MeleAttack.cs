using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    #region paremeters
    [SerializeField]
    private int _damage = 2;
    float _crono = 1;
    #endregion

    #region methods
    public void Attack()
    {
        gameObject.SetActive(true);
        _crono = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        EnemyLifeComponent enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();
        BossLife_Controller boss = collision.gameObject.GetComponent<BossLife_Controller>();

        if (enemy != null)
        {
            enemy.Damage(_damage);
            Debug.Log(enemy);
        }
        if(boss != null)
        {
            boss.Damage(_damage);
        }
    }

    #endregion

    void Update()
    {
        _crono += Time.deltaTime;
        if (_crono > 0.3f)
        {
            _crono = 0;
            gameObject.SetActive(false);
        }
    }
}
