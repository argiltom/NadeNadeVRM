using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;
using System;

public class VRMFaceController : MonoBehaviour
{
    [SerializeField] VRMBlendShapeProxy shapeProxy;
    [Range(0, 1)] public float Neutral;
    [Range(0, 1)] public float A;
    [Range(0, 1)] public float I;
    [Range(0, 1)] public float U;
    [Range(0, 1)] public float E;
    [Range(0, 1)] public float O;
    [Range(0, 1)] public float Blink;
    [Range(0, 1)] public float Joy;
    [Range(0, 1)] public float Angry;
    [Range(0, 1)] public float Sorrow;
    [Range(0, 1)] public float Fun;
    [Range(0, 1)] public float LookUp;
    [Range(0, 1)] public float LookDown;
    [Range(0, 1)] public float LookLeft;
    [Range(0, 1)] public float LookRight;
    [Range(0, 1)] public float Blink_L;
    [Range(0, 1)] public float Blink_R;
    IEnumerable blendShapePresets
    {
        get
        {
            return Enum.GetValues(typeof(BlendShapePreset));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string temp="";
        //Debug.Log(blendShapePresets);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BlendShapePreset bp in blendShapePresets)
        {
            shapeProxy.SetValue(bp,GetBlendShapeParameter(bp));
        }
    }
    float GetBlendShapeParameter(BlendShapePreset bsp)
    {
        switch (bsp)
        {
            case BlendShapePreset.Neutral:
                return Neutral;
            case BlendShapePreset.A:
                return A;
            case BlendShapePreset.I:
                return I;
            case BlendShapePreset.U:
                return U;
            case BlendShapePreset.E:
                return E;
            case BlendShapePreset.O:
                return O;
            case BlendShapePreset.Blink:
                return Blink;
            case BlendShapePreset.Joy:
                return Joy;
            case BlendShapePreset.Angry:
                return Angry;
            case BlendShapePreset.Sorrow:
                return Sorrow;
            case BlendShapePreset.Fun:
                return Fun;
            case BlendShapePreset.LookUp:
                return LookUp;
            case BlendShapePreset.LookDown:
                return LookDown;
            case BlendShapePreset.LookLeft:
                return LookRight;
            case BlendShapePreset.Blink_L:
                return Blink_L;
            case BlendShapePreset.Blink_R:
                return Blink_R;
            default:
                return 0;

        }
    }
    ////Unknown,Neutral,A,I,U,E,O,Blink,Joy,Angry,Sorrow,Fun,LookUp,LookDown,LookLeft,LookRight,Blink_L,Blink_R,
}
