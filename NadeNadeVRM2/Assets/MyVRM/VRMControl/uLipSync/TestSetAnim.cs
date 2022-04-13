using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSetAnim : MonoBehaviour
{
    [SerializeField] VRMAnimControler vrmAnimCon;
    [SerializeField] BaseVRMAnimEnum anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vrmAnimCon.BaseAnimEnum = anim;
    }
}
