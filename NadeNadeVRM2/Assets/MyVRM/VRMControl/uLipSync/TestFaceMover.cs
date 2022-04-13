using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFaceMover : MonoBehaviour
{
    [SerializeField] VRMFaceController m_FaceController;
    [SerializeField] float blinkSpan;
    DelayTimer blinkDelayTimer;
    // Start is called before the first frame update
    void Start()
    {
        blinkDelayTimer = DelayTimer.DelayTimerConstructor(gameObject, blinkSpan);
    }

    // Update is called once per frame
    void Update()
    {
        if (blinkDelayTimer.IsArrival)
        {
            StartCoroutine(Blink(0.1f));
            blinkDelayTimer.ResetCount();
        }
        
    }
    IEnumerator Blink(float rate)
    {
        float i;
        for (i = 0; i <= 1; i += rate)
        {
            m_FaceController.Blink = i;
            yield return new WaitForSeconds(0.001f);
        }
        for (i = 1; i >= 0; i -= rate)
        {
            m_FaceController.Blink = i;
            yield return new WaitForSeconds(0.001f);
        }
        yield return null;
    }
}
