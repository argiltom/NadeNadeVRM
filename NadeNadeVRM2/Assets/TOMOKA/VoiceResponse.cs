using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceResponse : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<VoiceCorresponcer> voiceCorresponceres;
    bool isResponce;
    string stackedString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stackedString != VoiceGetter.latestVoiceStr)
        {
            isResponce = true;
            stackedString = VoiceGetter.latestVoiceStr;
        } 

        if (isResponce)
        {
            //上から順に優先度が高い、一度に複数音声を話すことはない
            foreach(VoiceCorresponcer vc in voiceCorresponceres)
            {
                if (vc.IsIncludeTriggerStr(stackedString))
                {
                    audioSource.clip = vc.responseVoice;
                    audioSource.Play();
                    isResponce =false;
                    break;
                }
            }
            isResponce = false;
        }
        
    }
}
[System.Serializable]
public struct VoiceCorresponcer
{
    public AudioClip responseVoice;
    public List<string> triggerStrings;
    public bool IsIncludeTriggerStr(string inputStr)
    {
        //bool ret = false;
        foreach(string str in triggerStrings)
        {
            if (inputStr.Contains(str)) return true;
        }
        return false;
    }
}