using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttackController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float firerate = 0.5f;
    [SerializeField]
    private float canfire = 0.0f;
    [SerializeField]
    private float ShotSpeed = 0.0f;
    #endregion

    #region references
    [SerializeField]
    private GameObject myShot;
    public Transform shoopos;
    #endregion

    #region methods
    public void Shoot(int dir)
    {
        if (Time.time > canfire)
        {
            GameObject newshoot = Instantiate(myShot, shoopos.position, Quaternion.identity); //disparar
            newshoot.GetComponent<Rigidbody>().velocity = new Vector3(ShotSpeed * dir * Time.fixedDeltaTime, 0f);
            if (dir < 0)
            {
                newshoot.GetComponent<SpriteRenderer>().flipX = true;// rotacion de sprite del disparo
            }
            canfire = Time.time + firerate;//indica la cadencia del tiro
        }
    }
    #endregion
}
