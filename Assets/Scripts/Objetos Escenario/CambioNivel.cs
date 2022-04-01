using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public int scene;
    private void Awake()
    {
        scene = PlayerPrefs.GetInt("Scena", 1);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();
        Debug.Log(player);
        if (player != null)
        {
            scene = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("Scena", scene);
            SceneManager.LoadScene(scene);
        }
 
    }
}
