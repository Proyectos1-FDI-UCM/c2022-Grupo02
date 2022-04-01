using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaticEnemy_Controller : MonoBehaviour
{
    #region parameters
    private float change;
    [SerializeField]
    private int damagetoplayer = 0;
    #endregion

    #region references
    GameObject _Scottie;
    Transform _myTransform;
    #endregion

    #region methods
    public void Choose()
    {
        if (_Scottie.transform.position.x > _myTransform.position.x) { gameObject.GetComponent<Animator>().SetBool("EatLeft", true); }// animación de comer izquierda
        else if (_Scottie.transform.position.x < _myTransform.position.x) { gameObject.GetComponent<Animator>().SetBool("EatRight", true); }// animación de comer derecha
    }
    #endregion

    void Update()
    {
        if(Time.time >= change)// cambiar los booleanos a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("EatRight", false);
            gameObject.GetComponent<Animator>().SetBool("EatLeft", false);
            change = Time.time + 0.5f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Player_Life_Component player = collision.gameObject.GetComponent<Player_Life_Component>();

        if (player != null)
        {
            Choose();
            player.damage(damagetoplayer);
        }
    }

    void Start()
    {
        _myTransform = GetComponent<Transform>();
        _Scottie = GameObject.Find("Scottie");
    }
}
