using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovementController : MonoBehaviour
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
        if (enemy != null)
        {
            enemy.Damage(damage);
        }
        if (player == null)//sin disparos infinitos preguntar si se puede hacer de otra forma o es admisible
        {
            Destroy(this.gameObject);
        }

    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        live = live + (1 * Time.fixedDeltaTime);
        if (live >= LifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}

