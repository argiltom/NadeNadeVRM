using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ボイス入力を請け負うMonoBehavior
/// </summary>
public class VoiceGetter : MonoBehaviour
{
    //このパッケージをインポート:https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/quickstarts/setup-platform?pivots=programming-language-csharp&tabs=unity%2Cwindows%2Cjre%2Cbrowser
    //Azureのサービスを利用
    private static string key = "43519da934764c64991805042e031cd6";
    private static string location = "japaneast";
    public static string latestVoiceStr;
    public static float elapsedTimeOfInput;
    public static VoiceGetter instance=null;
    SpeechConfig speechConfig;
    AudioConfig audioConfig;
    SpeechRecognizer speechRecognizer;
    bool isActive;
    [SerializeField] bool isReporting;
    [SerializeField] Text feedBackTo;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        speechConfig = SpeechConfig.FromSubscription(key, location);
        speechConfig.SpeechRecognitionLanguage = "ja-JP";//日本語に変更
        audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);
    }

    // Update is called once per frame
    async void Update()
    {
        if (isReporting)
        {
            Debug.Log("latestVoice:"+latestVoiceStr+"\nelapsedTimeOfInput=" + elapsedTimeOfInput);
            if(feedBackTo != null) feedBackTo.text = latestVoiceStr;
        }
        elapsedTimeOfInput += Time.deltaTime;
        await VoiceGetFunc();
        
    }
    Task VoiceGetFunc()
    {
        return Task.Run(async () =>
        {
            if (isActive)
            {
                
            }
            else
            {
                isActive = true;
                Task<SpeechRecognitionResult> srrTask = speechRecognizer.RecognizeOnceAsync();
                SpeechRecognitionResult result = await srrTask;
                elapsedTimeOfInput = 0;
                latestVoiceStr = result.Text;
                Debug.Log(latestVoiceStr);
                isActive = false;
            }
            
        });
    }
}
