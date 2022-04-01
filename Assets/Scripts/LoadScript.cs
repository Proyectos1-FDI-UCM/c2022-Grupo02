using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    private InputManager _myinputmanager;
    private Player_Life_Component _myplayerlivecomponent;
    private CambioNivel _mycambionivel;
    // Start is called before the first frame update
    void Start()
    {
        _mycambionivel = GetComponent<CambioNivel>();
        _myinputmanager = GetComponent<InputManager>();
        _myplayerlivecomponent = GetComponent<Player_Life_Component>();
        
    }
    public void Load()
    {
        SceneManager.LoadScene(_mycambionivel.scene);
    }
}
