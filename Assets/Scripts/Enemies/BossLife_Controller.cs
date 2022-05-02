using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLife_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    public int health = 1;
    [SerializeField]
    public int maxHealth = 20;
    [SerializeField]
    public float volume = 0.5f;
    #endregion

    #region references
    private Transform _myTransform;
    public Slider HealthBar;
    public AudioSource audioSource;
    public AudioClip clip;

    #endregion

    public void Damage(int Damage)
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        health -= Damage;
        HealthBar.value = health;
        audioSource.PlayOneShot(clip, volume);
        if (health <= 0)
        {
            //gameObject.GetComponent<Animator>().SetBool("Hit", false);
            gameObject.GetComponent<Animator>().SetBool("Efecto", true);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.FinJuego();
        
    }

    private void Start()
    {
        health = maxHealth;
        //HealthBar.SetHealth(health, maxHealth);
        _myTransform = GetComponent<Transform>();
    }
}
