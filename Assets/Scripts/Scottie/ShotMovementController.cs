using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int damage = 1;
    #endregion 

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        EnemyLifeComponent enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();
        BossLife_Controller boss = collision.gameObject.GetComponent<BossLife_Controller>();
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        BloqueDestructible bloque = collision.gameObject.GetComponent<BloqueDestructible>();

        if (enemy != null)
        {
            enemy.Damage(damage);
        }
        else if (boss != null)
        {
            boss.Damage(damage);
        }
        if (bloque != null)
        {
            bloque.Damage(damage);
        }
        if (player == null)//sin disparos infinitos preguntad si se puede hacer de otra forma o es admisible
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

}

