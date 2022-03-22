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
    private MeleAttack _myMeleAttack;
    #endregion

    #region parameters
    public int dir;
    private float change = 6;
    #endregion


    void Start()
    {
        _myCharacterMovementController = GetComponent<Character_MovementController>();
        _myCharacterController = GetComponent<CharacterController>();
        _myTransform = GetComponent<Transform>();
        _jumpController = GetComponent<JumpController>();
        _AttackController = GetComponent<AttackController>();
        _myMeleAttack = GameObject.Find("AtDer").GetComponent<MeleAttack>();

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

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetBool("Melé", true);
            _myMeleAttack.Attack(dir);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            _jumpController.Jump();
        }

        if(Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", true);
            _AttackController.Shoot(dir);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.SetPause();
        }

        if (change >= 0.3f)// cambiar los booleanos a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", false);
            gameObject.GetComponent<Animator>().SetBool("Melé", false);
            change = 0; 
        } //revisar, no tiene mucho sentido
        _myCharacterMovementController.SetDirection(movementDirection);
    }

}
