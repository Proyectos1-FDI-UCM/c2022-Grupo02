using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    #region parameters
    [SerializeField]
    private int _maxLife = 3;
    [SerializeField]
    private int health = 3;
    private float change = 0;
    private float _damageChrono = 10;
    [SerializeField]
    private float _timeToRecieveDamage;
    #endregion

    #region properties
    private int _currentLife;
    #endregion

    #region references
    [SerializeField]
    private UI_Manager _myUIManager;
    CharacterController _myCharacterController;
    #endregion

    #region methods
    public void damage(int damage)
    {
        //Debug.Log(_myUIManager == null);
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
<<<<<<< HEAD

        if (_damageChrono > _timeToRecieveDamage) 
        {
            health -= damage; //Esto es lo que se llama desde el evento de la animación
            _damageChrono = 0;
        }

        if (health < 0)
        {
            health = 0;
        }
        
        if (health == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Death", true);
        }
=======
        health -= damage;
        //Esto es lo que se llama desde el evento de la animación

>>>>>>> 66882df4b8659f62732d11eac6cd3cef914ba581
        _myUIManager.UpdatePlayerLife(health);

    }
    #endregion

    void Start()
    {
        _currentLife = _maxLife;
        //_myUIManager = GetComponent<UI_Manager>();
        _myCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Time.time >= change)// cambiar el booleano a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", false);
            change = Time.time + 0.5f;
        }
<<<<<<< HEAD
        _damageChrono += Time.deltaTime;
=======

        if (health <= 0 && _myCharacterController.isGrounded)
        {
                gameObject.GetComponent<Animator>().SetBool("Death", true);
        }
>>>>>>> 66882df4b8659f62732d11eac6cd3cef914ba581
    }

        
 
}
