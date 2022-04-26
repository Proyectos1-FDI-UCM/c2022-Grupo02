using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public HealthBar HealthBar;
    public AudioSource audioSource;
    public AudioClip clip;

    #endregion

    public void Damage(int Damage)
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        health -= Damage;
        audioSource.PlayOneShot(clip, volume);
        if (health <= 0)
        {
            Die();
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
        HealthBar.SetHealth(health, maxHealth);
        _myTransform = GetComponent<Transform>();
       
    }
}
