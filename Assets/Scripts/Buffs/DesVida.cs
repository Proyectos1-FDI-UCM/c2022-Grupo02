using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesVida : MonoBehaviour
{
    [SerializeField]
    private GameObject _sound;
    [SerializeField]
    private GameObject _textoCorazon;
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (player != null)
        {
            player.unlockExHealth();
            Destroy(this.gameObject);
            _sound.SetActive(true);
            _textoCorazon.SetActive(true);
        }
    }
}
