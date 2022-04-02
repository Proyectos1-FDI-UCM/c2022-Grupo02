using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    #region references
    private Character_MovementController _myCharacterMovementController;
    private CharacterController _myCharacterController;
    private Transform _myTransform;
    private JumpController _jumpController;
    private AttackController _AttackController;
    private LoadScript _myload;
    #endregion

    #region parameters
    public int dir;
    private float change = 6;
    public int magia = 0;
    public int vida = 1;
    public int up = 0;
    public int salto = 0;
    #endregion

    private void Awake()
    {
        magia = PlayerPrefs.GetInt("magia", 0);
        salto = PlayerPrefs.GetInt("salto", 0);
    }
    void Start()
    {
        _myload = GetComponent<LoadScript>();
        _myCharacterMovementController = GetComponent<Character_MovementController>();
        _myCharacterController = GetComponent<CharacterController>();
        _myTransform = GetComponent<Transform>();
        _jumpController = GetComponent<JumpController>();
        _AttackController = GetComponent<AttackController>();
        dir = +1;
    }

    void Update()
    {
        change += Time.deltaTime;
        Vector3 movementDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
           
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            movementDirection.x = -1.0f;
            dir = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
           
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            movementDirection.x = 1.0f;
            dir = +1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            up = 1;
            gameObject.GetComponent<Animator>().SetBool("MeleUp", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            up = 0;
            gameObject.GetComponent<Animator>().SetBool("Melé", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpController.Jump(salto);
        }

        if (Input.GetMouseButton(1) && magia == 1)
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", true);
            _AttackController.Shoot(dir);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetPause();
        }

        if (change >= 0.3f)// cambiar los booleanos a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", false);
            gameObject.GetComponent<Animator>().SetBool("Melé", false);
            gameObject.GetComponent<Animator>().SetBool("MeleUp", false);
            change = 0; 
        } 
        _myCharacterMovementController.SetDirection(movementDirection);
    }
    public void DesSalto()
    {
        salto = 1;
        PlayerPrefs.SetInt("salto", salto);
        PlayerPrefs.Save();
    }
    public void DesMagia()
    {
        magia = 1;
        PlayerPrefs.SetInt("magia", magia);
        PlayerPrefs.Save();
    }
}
