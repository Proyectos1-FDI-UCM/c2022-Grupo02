using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    int muerteInstanntanea = 6;

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Toca");
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            //Debug.Log("Detecta");
            player.damage(muerteInstanntanea);
        }
    }
}
