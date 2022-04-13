using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadeNadeChacker : MonoBehaviour
{
    [SerializeField] VRMFaceController vrmFaceController;
    [SerializeField] float thresholdOfNade;
    bool isNadeNade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        NadeNadeHand nd= other.gameObject.GetComponent<NadeNadeHand>();
        if (nd == null) return;
        if (nd.HandVelocity > thresholdOfNade)
        {
            vrmFaceController.Blink = 1;
            //Debug.LogWarning("‚È‚Å‚È‚Å");
        }
    }
}
