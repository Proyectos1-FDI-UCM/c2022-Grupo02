using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Toca");
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            //Debug.Log("Detecta");
            GameManager.Instance.OnPlayerDies();
            player.gameObject.GetComponent<Animator>().SetBool("Death", true);
        }
    }

}
