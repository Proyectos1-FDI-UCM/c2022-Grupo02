using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    GameManager _mygamemanager;

    private void Awake()
    {
        _mygamemanager = GetComponent<GameManager>();
        _mygamemanager.scene = PlayerPrefs.GetInt("Scena", 1);
        //Debug.Log(scene);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        Debug.Log(player);
        if (player != null)
        {
            _mygamemanager.scene = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("Scena", _mygamemanager.scene);
            SceneManager.LoadScene(_mygamemanager.scene);
        }
 
    }
}
