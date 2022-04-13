using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadeNadeHand : MonoBehaviour
{
    public float HandVelocity
    {
        get => Vector3.Distance(beforePos, nowPos);
    }
    Vector3 beforePos;
    Vector3 nowPos;
    DelayTimer delayTimer;
    // Start is called before the first frame update
    void Start()
    {  
        delayTimer = DelayTimer.DelayTimerConstructor(gameObject, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTimer.IsArrival)
        {
            beforePos = nowPos;
            nowPos = transform.position;
            delayTimer.ResetCount();
            Debug.Log("handSpeed:" + HandVelocity);
        }
        
    }
}
