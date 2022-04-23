using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesMagia : MonoBehaviour
{
    [SerializeField]
    private GameObject _sound;

        //public AudioSource audioSource;


    // public AudioSource audioSource;
    private void OnTriggerEnter(Collider collision)
    {
        InputManager _inputmanager = collision.gameObject.GetComponent<InputManager>();
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (player != null)
        {
            //audioSource.Play();
            _inputmanager.DesMagia();
            Destroy(this.gameObject);
            _sound.SetActive(true);
        }

    }
 }


    
       
 