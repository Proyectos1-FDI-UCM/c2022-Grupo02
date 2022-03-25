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

    // Update is called once per frame
    void Update()
    {
        
    }
}
