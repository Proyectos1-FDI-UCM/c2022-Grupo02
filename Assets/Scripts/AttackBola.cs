using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBola : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _range = 10;
    [SerializeField]
    private float firerate = 2f;
    [SerializeField]
    private float canfire = 0.0f;
    [SerializeField]
    private float ShotSpeed = 1000f;
    #endregion

    #region references
    [SerializeField]
    private GameObject myShot;
    private GameObject _Scottie;
    [SerializeField]
    private Transform shoopos;
    private Transform _myTransform;
    #endregion

    void Start()
    {
        _Scottie = GameObject.Find("Scottie");
        _myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(_myTransform.position, _Scottie.transform.position) < _range && _Scottie.transform.position.y > _myTransform.position.y)
        {
            if (Time.time > canfire)
            {
                GameObject newshoot = Instantiate(myShot, shoopos.position, Quaternion.identity); //disparar
                newshoot.GetComponent<Rigidbody>().velocity = new Vector3(0f, ShotSpeed * Time.fixedDeltaTime);
                canfire = Time.time + firerate;//indica la cadencia del tiro
            }
        }
    }
}
