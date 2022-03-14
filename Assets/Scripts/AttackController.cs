using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private GameObject myShot;
    public Transform shoopos;
    #region parameters
    [SerializeField]
    private float firerate = 0.5f;
    [SerializeField]
    private float canfire = 0.0f;
    [SerializeField]
    private float ShotSpeed = 0.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
