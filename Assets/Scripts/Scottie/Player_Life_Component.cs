using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    #region parameters
    [SerializeField]
    public int _maxLife = 3;
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
    private InputManager _myinputmanager;
    CharacterController _myCharacterController;
    private LoadScript _myload;
    #endregion

    #region methods
    private void Awake()
    {
        _maxLife = PlayerPrefs.GetInt("vida", health);
    }
    public void damage(int damage)
    {
        //Debug.Log(_myUIManager == null);
        gameObject.GetComponent<Animator>().SetBool("Hit", true);

        if (_damageChrono > _timeToRecieveDamage) 
        {
            health -= damage; //Esto es lo que se llama desde el evento de la animación
            _damageChrono = 0;
        }

        if (health < 0) // Limitar el daño
        {
            health = 0;
        }
        
        if (health == 0) // Muerte    
        {
            gameObject.GetComponent<Animator>().SetBool("Death", true);
            GameManager.Instance.OnPlayerDies();
        }

        _myUIManager.UpdatePlayerLife(health);
    }

    public void heal(int healValue)
    {
        if (health + healValue <= _maxLife)
        {
            health += healValue;
        }
        else
        {
            health = _maxLife;
        }
        _myUIManager.UpdatePlayerLife(health);
    }

    public void unlockExHealth()
    {
        _maxLife = 8;
        health = 8;
        _myUIManager.HPIncrease(_maxLife);
        PlayerPrefs.SetInt("vida", health);//preguntar
        PlayerPrefs.Save();
    }
    #endregion

    void Start()
    {
        health = _maxLife;
        //_myUIManager = GetComponent<UI_Manager>();
        _myCharacterController = GetComponent<CharacterController>();
        _myinputmanager = GetComponent<InputManager>();
        _myload = GetComponent<LoadScript>();
    }

    void Update()
    {
        if (Time.time >= change)// cambiar el booleano a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", false);
            change = Time.time + 0.5f;
        }
        _damageChrono += Time.deltaTime; 
    }
}
