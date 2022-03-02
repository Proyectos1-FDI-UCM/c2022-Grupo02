using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaticEnemy_Controller : MonoBehaviour
{
    #region parameters
    private float change;
    #endregion

    #region methods
    public void EatLeft()
    {
        gameObject.GetComponent<Animator>().SetBool("EatLeft", true);
    }

    public void EatRight()
    {
        gameObject.GetComponent<Animator>().SetBool("EatRight", true);
    }
    #endregion

    void Update()
    {
        if(Time.time >= change)
        {
            gameObject.GetComponent<Animator>().SetBool("EatRight", false);
            gameObject.GetComponent<Animator>().SetBool("EatLeft", false);
            change = Time.time + 0.5f;
        }
    }
}
