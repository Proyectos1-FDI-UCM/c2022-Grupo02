using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float LifeTime = 6;
    private float live = 0;
    [SerializeField]
    private int damage = 1;
    #endregion 

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        EstaticEnemy_Controller EstaticEnemy = collision.gameObject.GetComponent<EstaticEnemy_Controller>();
        FlyingEnemy_Controller FlyingEnemy = collision.gameObject.GetComponent<FlyingEnemy_Controller>();
        GroundEnemy_Controller GroundEnemy = collision.gameObject.GetComponent<GroundEnemy_Controller>();
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player == null)
        {                          
            if (EstaticEnemy != null)
            {
                EstaticEnemy.Damage(damage);
            }
            else if (FlyingEnemy != null)
            {
                FlyingEnemy.Damage(damage);
            }
            else if (GroundEnemy != null)
            {
                GroundEnemy.Damage(damage);
            }
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

