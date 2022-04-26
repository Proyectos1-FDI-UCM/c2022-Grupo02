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
    //private bool groPrevFrame = false;
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
            velocity.y += _gravity * (Time.deltaTime);
        }
        else
        {
            if (velocity.y < -2) velocity.y = -1;
            uno = true;
        }

        //groPrevFrame = _myCharacterController.isGrounded;
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
        }
        //Debug.Log(velocity.y);
        //Debug.Log(_myCharacterController.isGrounded);
    }
} 
