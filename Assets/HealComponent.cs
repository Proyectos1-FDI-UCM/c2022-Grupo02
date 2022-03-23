using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealComponent : MonoBehaviour
{
    [SerializeField]
    int lifeToHeal = 1;

    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            player.heal(lifeToHeal);
            Destroy(gameObject);
        }
    }
}
