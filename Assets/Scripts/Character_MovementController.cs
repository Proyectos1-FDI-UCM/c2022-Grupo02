using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_MovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    float acceleration = 1.5f;
    [SerializeField]
    float maxSpeed = 3f;
    [SerializeField]
    private float _movementSpeed = 0f;
    #endregion

    #region references
    private CharacterController _myCharacterController;
    private JumpController _myJumpController;
    #endregion

    #region properties
    private Vector3 _movementDirection;
    private Vector3 _jumpDirection;
    #endregion

    #region methods
    public void SetDirection(Vector3 movementDirection)
    {
        _movementDirection = movementDirection.normalized;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterController = GetComponent<CharacterController>();
        _myJumpController = GetComponent<JumpController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_movementDirection.x != 0 && _movementSpeed < maxSpeed)
        {
            _movementSpeed += acceleration * Time.deltaTime;
        }
        else if (_movementDirection.x == 0 && _movementSpeed > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            _movementSpeed = 0;
        }

        _jumpDirection = _myJumpController.SetGravity();
        _movementDirection = _movementDirection * _movementSpeed;

        _myCharacterController.Move((_movementDirection + _jumpDirection) * Time.deltaTime);
    }
}
