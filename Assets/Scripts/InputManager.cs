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
    [SerializeField]
    private float firerate = 0.25f;
    [SerializeField]
    private float canfire = 0.0f;
    [SerializeField]
    private float ShotSpeed = 0.0f;
    [SerializeField]
    private GameObject myShot;
    public Transform shoopos;
    public int dir;
    #endregion

    void Start()
    {
        _myCharacterMovementController = GetComponent<Character_MovementController>();
        _myCharacterController = GetComponent<CharacterController>();
        _myTransform = GetComponent<Transform>();
        _jumpController = GetComponent<JumpController>();
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            _jumpController.Jump();
        }
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }
        _myCharacterMovementController.SetDirection(movementDirection);
    }
    private void Shoot()
    {
        if(Time.time > canfire)
        {
            GameObject newshoot =  Instantiate(myShot, shoopos.position, Quaternion.identity); //disparar
            Debug.Log(dir);
            newshoot.GetComponent<Rigidbody2D>(/*Animaciones de la bala*/).velocity = new Vector2 (ShotSpeed * dir *Time.fixedDeltaTime, 0f);
            canfire = Time.time +firerate;//indica la cadencia del tiro
        }
    }
}
