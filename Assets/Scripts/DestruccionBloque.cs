using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionBloque : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        ShotMovementController shoot = collision.gameObject.GetComponent<ShotMovementController>();
        Debug.Log(shoot);
        if (shoot != null)
        {
            Destroy(this.gameObject);
        }
    }
}
