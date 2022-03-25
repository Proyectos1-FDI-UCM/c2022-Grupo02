using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLimitController : MonoBehaviour
{
    [SerializeField]
    GameObject _Scottie;
    private JumpController _jumpController;

    void Start()
    {
        _jumpController = _Scottie.GetComponent<JumpController>();
    }

    private void OnTriggerEnter()
    {
        Debug.Log("He chocado con el techo");
        _jumpController.TouchCeiling();
    }
}
