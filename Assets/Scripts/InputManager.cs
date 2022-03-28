using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    #region references
    private Character_MovementController _myCharacterMovementController;
    private CharacterController _myCharacterController;
    private Transform _myTransform;
    private JumpController _jumpController;
    private AttackController _AttackController;
    [SerializeField]
    private GameObject _myAttackL;
    [SerializeField]
    private GameObject _myAttackR;
    [SerializeField]
    private GameObject _myAttackU;
    private MeleAttack _myMeleAttackL;
    private MeleAttack _myMeleAttackR;
    private MeleAttack _myMeleAttackU;
    #endregion

    #region parameters
    public int dir;
    private float change = 6;
    private int magia = 0;
    private int vida = 1;
    private int up = 0;
    private int salto = 0;
    #endregion

    #region methods
    private void LlamaMele()
    {
        if (up == 1) 
        {
            _myMeleAttackU.Attack();
        }
        else
        {
            if (dir == 1)
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
        _myCharacterMovementController = GetComponent<Character_MovementController>();
        _myCharacterController = GetComponent<CharacterController>();
        _myTransform = GetComponent<Transform>();
        _jumpController = GetComponent<JumpController>();
        _AttackController = GetComponent<AttackController>();
        _myMeleAttackL = _myAttackL.GetComponent<MeleAttack>();
        _myMeleAttackR = _myAttackR.GetComponent<MeleAttack>();
        _myMeleAttackU = _myAttackU.GetComponent<MeleAttack>();

        dir = +1;
    }

    void Update()
    {
        change += Time.deltaTime;
        Vector3 movementDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
           
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            movementDirection.x = -1.0f;
            dir = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
           
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            movementDirection.x = 1.0f;
            dir = +1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            up = 1;
            gameObject.GetComponent<Animator>().SetBool("MeleUp", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            up = 0;
            gameObject.GetComponent<Animator>().SetBool("Melé", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(salto);
            _jumpController.Jump(salto);
        }

        if (Input.GetMouseButton(1) && magia == 1)
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", true);
            _AttackController.Shoot(dir);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetPause();
        }

        if (change >= 0.3f)// cambiar los booleanos a false tras un tiempo
        {
            gameObject.GetComponent<Animator>().SetBool("Adistancia", false);
            gameObject.GetComponent<Animator>().SetBool("Melé", false);
            gameObject.GetComponent<Animator>().SetBool("MeleUp", false);
            change = 0; 
        } 
        _myCharacterMovementController.SetDirection(movementDirection);
    }
    public void DesSalto()
    {
        salto = 1;
    }
    public void DesMagia()
    {
        magia = 1;
    }
}
