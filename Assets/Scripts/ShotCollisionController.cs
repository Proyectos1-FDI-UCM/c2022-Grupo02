using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollisionController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float LifeTime = 10;
    private float live = 0;
    [SerializeField]
    private int damage = 1;
    #endregion 

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        EnemyLifeComponent enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (enemy != null && player == null)
        {
            enemy.Damage(damage);
        }
        if (player == null)//sin disparos infinitos preguntad si se puede hacer de otra forma o es admisible
        {
            Destroy(this.gameObject);
        }

    }
    #endregion

}

