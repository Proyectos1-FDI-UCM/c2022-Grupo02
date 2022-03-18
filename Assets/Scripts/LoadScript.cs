using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Magia",/*variable magia*/1);
        PlayerPrefs.GetInt("Salto",/*variable Salto doble*/1);
        PlayerPrefs.GetInt("Vida",/*variable Vida maxima*/1);
        PlayerPrefs.GetInt("Scena",/*variable Vida nivel*/0);
    }

}
