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
    private combateScottie _combateScottie;
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
            gameObject.GetComponent<Animator>().SetBool("Melé", true);
            _combateScottie.cambiabooleano();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            _jumpController.Jump();
        }

        if(Input.GetMouseButton(0))
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", true);
            _AttackController.Shoot(dir);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.SetPause();
        }

        if (Time.time >= change)// cambiar los booleanos a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", false);
            gameObject.GetComponent<Animator>().SetBool("Melé", false);
            change = Time.time + 0.25f;
        }
        _myCharacterMovementController.SetDirection(movementDirection);
    }

}
