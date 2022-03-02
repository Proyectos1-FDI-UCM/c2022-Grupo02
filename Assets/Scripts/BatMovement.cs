using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _range;

    [SerializeField]
    private Transform _characterTransform;

    [SerializeField]
    private Transform _batTransform;

    [SerializeField]
    private Rigidbody _batRigidBody;


    void Update()
    {

        Vector2 _target = new Vector2(_characterTransform.position.x, _characterTransform.position.y);
        if (Vector2.Distance(_batTransform.position, _characterTransform.position) < _range && Vector2.Distance(_batTransform.position, _characterTransform.position) > _range / 3.0f)
        {
            Vector2 _newPosition = Vector2.MoveTowards(_batRigidBody.position, _target, _speed * Time.deltaTime);
            _batRigidBody.MovePosition(_newPosition);
        }
        else if (Vector2.Distance(_batTransform.position, _characterTransform.position) < _range)
        {
            Vector2 _newPosition = Vector2.MoveTowards(_batRigidBody.position, _target, _speed / 2.0f * Time.deltaTime);
            _batRigidBody.MovePosition(_newPosition);
        }


    }

}
