using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int health = 1;
    [SerializeField]
    public float volume = 0.5f;
    #endregion

    #region references
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    private Transform _myTransform;
    private HealthDropComponent _myHealthDropComponent;
    #endregion

    public void Damage(int Damage)
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        health -= Damage;
        audioSource.PlayOneShot(clip, volume);
        if (health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", false);
            gameObject.GetComponent<Animator>().SetBool("Efecto", true);
        }
    }

    private void Die()
    {
        
        Destroy(gameObject);
        


        if (_myHealthDropComponent != null)
        {
            _myHealthDropComponent.TryToDrop(_myTransform.position);
        }
        AudioSource.PlayClipAtPoint(clip2, transform.position, volume);
    }

    private void Start()
    {
        _myTransform = GetComponent<Transform>();
        _myHealthDropComponent = GetComponent<HealthDropComponent>();
    }
}
