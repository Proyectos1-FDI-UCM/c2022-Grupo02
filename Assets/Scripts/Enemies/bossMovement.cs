using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float speed;
    private float _AuxSpeed;
    [SerializeField]
    private int damagetoplayer = 2;
    [SerializeField]
    private float _range = 2;
    [SerializeField]
    private Vector3[] positions;
    private int index = 0;
    private float change;
    #endregion

    #region references
    private Transform _myTransform;
    private GameObject _Scottie;
    #endregion

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            gameObject.GetComponent<Animator>().SetBool("Ataque", true);
            if (gameObject.GetComponent<SpriteRenderer>().flipX && _Scottie.transform.position.x > _myTransform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;// girar izquierda 
                index = 1;
            }
            else if (!gameObject.GetComponent<SpriteRenderer>().flipX && _Scottie.transform.position.x < _myTransform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;// girar a la derecha
                index = 0;
            }
            _AuxSpeed = 0;
            player.damage(damagetoplayer);
        }
    }
    #endregion

    void Start()
    {
        _Scottie = GameObject.Find("Scottie");
        _AuxSpeed = speed;
        _myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 _target = new Vector2(_Scottie.transform.position.x, _myTransform.position.y);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                index = 0;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                index++;
            }
        }

        //Debug.Log(Vector2.Distance(_myTransform.position, _Scottie.transform.position));
        if (Vector2.Distance(_myTransform.position, _Scottie.transform.position) < _range)
        {
            Vector2 _newPosition = Vector2.MoveTowards(_myTransform.position, _target, speed * Time.deltaTime);
            _myTransform.position = _newPosition;
        }

        else
        {
            _myTransform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * _AuxSpeed);
        }

        if (_myTransform.position.x < _Scottie.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            index = 1;
        }

        else if (_myTransform.position.x > _Scottie.transform.position.x && Vector2.Distance(_myTransform.position, _Scottie.transform.position) < _range)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            index = 0;
        }

        if (Time.time >= change)// cambiar el booleano a false tras un tiempo
        {   
            _AuxSpeed = speed;
            gameObject.GetComponent<Animator>().SetBool("Ataque", false);
            gameObject.GetComponent<Animator>().SetBool("Hit", false);
            change = Time.time + 0.5f;
        }
    }
}
