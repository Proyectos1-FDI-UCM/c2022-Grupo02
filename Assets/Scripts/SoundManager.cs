using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region methods
    public class PlayAudio : MonoBehaviour
    {
        public AudioSource audioSource;
        void Start()
        {
            audioSource.Play();
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
