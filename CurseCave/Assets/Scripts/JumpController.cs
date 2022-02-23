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
    [SerializeField]
    float _maxGravity = 9.8f;
    Vector2 velocity;
    #endregion

    #region referneces
    CharacterController _myCharacterController;
    #endregion

    #region methods
    public void Jump()
    {
        if (_myCharacterController.isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("StartJumping", true);
            velocity.y = _jumpSpeed;
        }
    }

    private void SetGravity()
    {
        if (velocity.y >= - _maxGravity)
        {
            velocity.y -= _gravity * Time.deltaTime;
            Debug.Log(velocity.y);
        }
        _myCharacterController.Move(velocity * Time.deltaTime);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
        if (_myCharacterController.isGrounded) {
            gameObject.GetComponent<Animator>().SetBool("StartJumping", false);
        }
    }
}

