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
    [SerializeField]
    private combateScottie rangoAtaque;
    #endregion


    public int dir;


    void Start()
    {
        _myCharacterMovementController = GetComponent<Character_MovementController>();
        _myCharacterController = GetComponent<CharacterController>();
        _myTransform = GetComponent<Transform>();
        _jumpController = GetComponent<JumpController>();
        _AttackController = GetComponent<AttackController>();
        dir = +1;
    }

    void Update()
    {
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

        if (Input.GetKey(KeyCode.E))
        {
            rangoAtaque.cambiabooleano();
        }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            _jumpController.Jump();
        }
        if(Input.GetMouseButton(0))
        {
            _AttackController.Shoot(dir);
        }
        _myCharacterMovementController.SetDirection(movementDirection);
    }

}
