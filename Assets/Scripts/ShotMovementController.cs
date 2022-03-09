using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovementController : MonoBehaviour
{
    [SerializeField]
    private float LifeTime = 6;
    private float live = 0;
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        live = live +(1*Time.fixedDeltaTime);
        if(live>= LifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider hitinfo)
    {

        Debug.Log(hitinfo.tag);
        if(hitinfo.tag != "Player")//Se que esto esta feisimo pero he tardado 3 dias en hacerlo
        {                          //cambiarlo es problema del jose del futuro ahora funciona
            if(hitinfo.tag == "EnemyE")
            {
                EnemyDamageManager enemy = hitinfo.GetComponent<EnemyDamageManager>();
                enemy.Damage(damage);
            }
            else if (hitinfo.tag == "EnemyF")
            {
                FlyingEnemy_Controller enemy = hitinfo.GetComponent<FlyingEnemy_Controller>();
                enemy.Damage(damage);
            }
            else if (hitinfo.tag == "EnemyG")
            {
                GroundEnemy_Controller enemy = hitinfo.GetComponent<GroundEnemy_Controller>();
                enemy.Damage(damage);
            }
            else if (hitinfo.tag == "Bloque Destructible")
            {
                EnemyDamageManager enemy = hitinfo.GetComponent<EnemyDamageManager>();
                enemy.Damage(damage);
            }
            Destroy(this.gameObject);
        }
        
    }
}

