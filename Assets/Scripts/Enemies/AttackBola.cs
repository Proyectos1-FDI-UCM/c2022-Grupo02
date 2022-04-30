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
    [SerializeField]
    private Transform shoopos;
    private Transform _myTransform;
    #endregion

    void Start()
    {
        _myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(_myTransform.position, GameManager.Instance._myPlayer.transform.position) < _range && GameManager.Instance._myPlayer.transform.position.y > _myTransform.position.y)
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
