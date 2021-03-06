using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesSalto : MonoBehaviour
{
    [SerializeField]
    private GameObject _sound;
    [SerializeField]
    private GameObject _textMagia;
    private void OnTriggerEnter(Collider collision)
    {
        InputManager _inputmanager = collision.gameObject.GetComponent<InputManager>();
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (player != null)
        {
            _inputmanager.DesSalto();
            Destroy(this.gameObject);
            if(_sound != null)_sound.SetActive(true);
            if(_textMagia != null)_textMagia.SetActive(true);
        }

    }
}
