using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossUpAttack : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int damage = 1;
    #endregion

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (player != null)
        {
            player.damage(damage);
            Destroy(this.gameObject);
        }
    }
    #endregion

}
