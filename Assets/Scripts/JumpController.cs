using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    float _gravity = 9.8f;
    [SerializeField]
    float _jumpSpeed = 0f;
    Vector3 velocity;
    private bool uno = true;
    #endregion

    #region properties
    float _gravitySpeed;
    #endregion

    #region referneces
    CharacterController _myCharacterController;
    #endregion

    #region methods
    public void Jump(int salto)
    {
        if (_myCharacterController.isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("StartJumping", true);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            velocity.y = _jumpSpeed;
        }
        else if (!_myCharacterController.isGrounded && salto == 1 && uno)
        {
            _gravitySpeed = 0;
            gameObject.GetComponent<Animator>().SetBool("StartJumping", true);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            velocity.y = _jumpSpeed;
            uno = false;
        }

    }

    public Vector3 SetGravity()
    {
        if (!_myCharacterController.isGrounded)
        {
            _gravitySpeed -= _gravity * (Time.deltaTime/2.0f);
            velocity.y -= _gravitySpeed;
            //Debug.Log(velocity.y);
        }
        else
        {
            _gravitySpeed = 0;
            uno = true;
            //Debug.Log("estoy en el suelo");
        }
        return velocity;
    }

    public void TouchCeiling()
    {
        velocity.y = -2;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_myCharacterController.isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("StartJumping", false);
            velocity.y = 2 * _gravity;
        }
    }
} 
