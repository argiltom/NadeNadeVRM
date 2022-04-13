using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAudioSelector : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<KeyAndAudio> keyAndAudios;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyAndAudio ka in keyAndAudios)
        {
            if (Input.GetKeyDown(ka.keyCode)){
                audioSource.clip = ka.audioClip;
                audioSource.Play();
            }
        }
    }
}
[System.Serializable]
struct KeyAndAudio
{
    public AudioClip audioClip;
    public KeyCode keyCode;
}
