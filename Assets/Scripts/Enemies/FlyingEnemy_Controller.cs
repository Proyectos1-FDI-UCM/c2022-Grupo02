using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _speed;
    private float change;
    [SerializeField]
    private int damagetoplayer = 1;
    [SerializeField]
    private float _range;
    #endregion

    #region references
    [SerializeField]
    private Transform _characterTransform;

    [SerializeField]
    private Transform _batTransform;

    [SerializeField]
    private Rigidbody _batRigidBody;
    #endregion

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            gameObject.GetComponent<Animator>().SetBool("Ataque", true);
            player.damage(damagetoplayer);
        }
    }
    #endregion

    void Update()
    {

        Vector2 _target = new Vector2(GameManager.Instance._myPlayer.transform.position.x, GameManager.Instance._myPlayer.transform.position.y);
        if (Vector2.Distance(_batTransform.position, GameManager.Instance._myPlayer.transform.position) < _range && Vector2.Distance(_batTransform.position, GameManager.Instance._myPlayer.transform.position) > _range / 6.0f)
        {
            Vector2 _newPosition = Vector2.MoveTowards(_batRigidBody.position, _target, _speed * Time.deltaTime);
            _batRigidBody.MovePosition(_newPosition);
        }
        else if (Vector2.Distance(_batTransform.position, GameManager.Instance._myPlayer.transform.position) < _range)
        {
            Vector2 _newPosition = Vector2.MoveTowards(_batRigidBody.position, _target, _speed / 1.5f * Time.deltaTime);
            _batRigidBody.MovePosition(_newPosition);
        }

        if (_batTransform.position.x < GameManager.Instance._myPlayer.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        else if (_batTransform.position.x > GameManager.Instance._myPlayer.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Time.time >= change)// cambiar el booleano a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Ataque", false);
            change = Time.time + 0.5f;
        }


    }
}
