using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleScottie : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _myAttackL;
    [SerializeField]
    private GameObject _myAttackR;
    [SerializeField]
    private GameObject _myAttackU;
    private MeleAttack _myMeleAttackL;
    private MeleAttack _myMeleAttackR;
    private MeleAttack _myMeleAttackU;
    private InputManager _myInput;
    #endregion

    #region methods
    private void LlamaMele()
    {
        if (_myInput.up == 1)
        {
            _myMeleAttackU.Attack();
        }
        else
        {
            if (_myInput.dir == 1)
            {
                _myMeleAttackR.Attack();
            }
            else
            {
                _myMeleAttackL.Attack();
            }
        }

    }
    #endregion

    void Start()
    {
        _myMeleAttackL = _myAttackL.GetComponent<MeleAttack>();
        _myMeleAttackR = _myAttackR.GetComponent<MeleAttack>();
        _myMeleAttackU = _myAttackU.GetComponent<MeleAttack>();
        _myInput = GetComponent<InputManager>();
    }
}
