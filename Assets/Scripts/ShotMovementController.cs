using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovementController : MonoBehaviour
{
    [SerializeField]
    private float LifeTime = 6;
    private float live = 0;
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
}

