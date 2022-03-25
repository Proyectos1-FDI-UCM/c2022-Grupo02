using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float speed;
    private float _AuxSpeed;
    [SerializeField]
    private int damagetoplayer = 2;
    [SerializeField]
    private Vector3[] positions;
    private int index = 0;
    private float change;
    #endregion

    #region references
    [SerializeField]
    private AudioSource audioSource;
    private Transform _myTransform;
    private GameObject _Scottie;
    #endregion

    #region methods
    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            if (gameObject.GetComponent<SpriteRenderer>().flipX && _Scottie.transform.position.x > _myTransform.position.x) {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;// girar izquierda 
                index++;
            }
            else if (!gameObject.GetComponent<SpriteRenderer>().flipX && _Scottie.transform.position.x < _myTransform.position.x) {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;// girar a la derecha
                index = 0;
            }
            gameObject.GetComponent<Animator>().SetBool("Ataque", true);
            _AuxSpeed = 0;
            player.damage(damagetoplayer);
            audioSource.Play();
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
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * _AuxSpeed);

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

        if (Time.time >= change)// cambiar el booleano a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Ataque", false);
            _AuxSpeed = speed;
            change = Time.time + 0.5f;
        }
    }


}
