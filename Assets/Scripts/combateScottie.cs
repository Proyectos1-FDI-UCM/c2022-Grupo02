using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateScottie : MonoBehaviour
{
    public Transform rangoAtaque;
    private LayerMask enemyLayers;


    private float distanciaAtaque = 1f;
    int damage = 1;
    bool ataque = false;
    float cronoVox;


    void Update()
    {
        cronoVox += Time.deltaTime;
        if(cronoVox > 2f)
        {
            ataque = false;
            cronoVox = 0;
        }
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
