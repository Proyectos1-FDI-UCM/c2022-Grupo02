using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateScottie : MonoBehaviour
{
    public Transform rangoAtaque;
    private LayerMask enemyLayers;


    private float distanciaAtaque = 0.8f;
    int damage = 1;
    bool ataque = false;
    float cronoVox ;


    void Update()
    {
       /* cronoVox += Time.deltaTime;
        if(cronoVox > 0.5f && ataque)
        {
            ataque = false;
        }*/
    }
    /*void Ataca()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(rangoAtaque.position, distanciaAtaque, enemyLayers);

       if(rangoAtaque == null)
        {
           enemy.GetComponent<EnemyLifeComponent>().Damage(damage);
        }
    }*/

    void OnDrawGizmosSelected()
    {
        if (rangoAtaque == null)
            return;

        Gizmos.DrawWireSphere(rangoAtaque.position, distanciaAtaque);

    }

    private void OnTriggerEnter(Collider collision)
    {
       if(ataque)
        {
            Debug.Log("coño");
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(rangoAtaque.position, distanciaAtaque, enemyLayers);
            EnemyLifeComponent enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();
            enemy.Damage(damage);
        }
        Debug.Log(ataque);

        Debug.Log("polla");
    }

    public void cambiabooleano()
    {
        ataque = true;

    }
}
