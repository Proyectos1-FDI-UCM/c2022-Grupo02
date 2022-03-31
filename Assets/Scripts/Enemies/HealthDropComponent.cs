using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    int probDivBy10 = 3;
    #endregion

    #region references
    [SerializeField]
    private GameObject Hearth;
    #endregion

    public void TryToDrop(Vector3 Position)
    {
        int est = Random.Range(0, 10);
        if (est < probDivBy10) // Probabilidad de soltar un corazón 
        {
            Instantiate(Hearth, Position, Quaternion.identity);
        }
    }
}
