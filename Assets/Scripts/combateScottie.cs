using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateScottie : MonoBehaviour
{
    #region references
    public Transform rangoAtaque;
    private LayerMask enemyLayers;
    private EnemyLifeComponent enemy;
    #endregion

    #region parameters
    private float distanciaAtaque = 1f;
    int damage = 1;
    bool ataque = false;
    float crono;
    bool rango = false;
    #endregion

    #region methods
    private void OnDrawGizmosSelected()
    {
        if (rangoAtaque != null)
        {
            Gizmos.DrawWireSphere(rangoAtaque.position, distanciaAtaque);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        rango = true;
        enemy = collision.gameObject.GetComponent<EnemyLifeComponent>();

    }

    public void cambiabooleano()
    {
        ataque = true;
        Mele();
    }

    private void Mele()
    {
        if (ataque && rango && (enemy != null))
        {
            Debug.Log(enemy);
            enemy.Damage(damage);
        }
    }
    #endregion

    void Start()
    {
        rangoAtaque = GetComponent<Transform>();
    }

    void Update()
    {
        crono += Time.deltaTime;
        if(crono > 2f)
        {
            ataque = false;
            crono = 0;
        }
    }
    

}
