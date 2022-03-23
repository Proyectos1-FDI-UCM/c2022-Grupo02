using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject Hearth;
    #endregion

    public void TryToDrop(Vector3 Position)
    {
        int prob = Random.Range(0, 10);
        if (prob < 3) // Probabilidad de soltar un corazón 
        {
            Instantiate(Hearth, Position, Quaternion.identity);
        }
    }
}
