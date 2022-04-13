using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomWaitAnim : MonoBehaviour
{
    [SerializeField] VRMAnimControler vrmAnimCon;
    [SerializeField] List<BaseVRMAnimEnum> anims;
    [SerializeField] float animChangeSpan;
    DelayTimer animChangeDelayTimer;
    // Start is called before the first frame update
    void Start()
    {
        animChangeDelayTimer = DelayTimer.DelayTimerConstructor(gameObject,animChangeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        if (animChangeDelayTimer.IsArrival)
        {
            int rand = Random.Range(0, anims.Count);
            vrmAnimCon.BaseAnimEnum = anims[rand];
            animChangeDelayTimer.ResetCount();
        }
    }
}
