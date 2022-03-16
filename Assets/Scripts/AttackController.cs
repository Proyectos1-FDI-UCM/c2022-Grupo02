using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform rangoAtaque;
    private LayerMask enemyLayers;


    private float distanciaAtaque = 0.8f;
    int damage = 1;
    bool ataque = false;
    float cronoVox;


    void Update()
    {
        Debug.Log(ataque);
        cronoVox += Time.deltaTime;
        if(cronoVox > 0.5f)
        {
            ataque = false;
            cronoVox = 0;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (rangoAtaque == null)
            return;

        Gizmos.DrawWireSphere(rangoAtaque.position, distanciaAtaque);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (ataque)
        {
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(rangoAtaque.position, distanciaAtaque, enemyLayers);
            EnemyLifeComponent enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();
            if (enemy != null)enemy.Damage(damage);
        }
    }

    public void cambiabooleano()
    {
        ataque = true;
    }
}
