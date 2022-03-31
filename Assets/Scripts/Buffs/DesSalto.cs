using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesSalto : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        InputManager _inputmanager = collision.gameObject.GetComponent<InputManager>();
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (player != null)
        {
            _inputmanager.DesSalto();
            Destroy(this.gameObject);
        }

    }
}
