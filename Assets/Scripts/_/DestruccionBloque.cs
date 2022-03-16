using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionBloque : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        ShotCollisionController shoot = collision.gameObject.GetComponent<ShotCollisionController>();
        //Debug.Log(shoot);
        if (shoot != null)
        {
            Destroy(this.gameObject);
        }
    }
}
