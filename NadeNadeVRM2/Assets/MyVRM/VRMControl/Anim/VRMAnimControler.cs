using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// VRMAnimControlerのうち,ループするアニメーションを設定する
/// </summary>
public enum BaseVRMAnimEnum { WAIT00, WAIT01, WAIT02, WAIT03, WAIT04, WALK00_F, WALK00_B, WALK00_L, WALK00_R, RUN00_F, RUN00_L, RUN00_R };
public enum SingleVRMAnimEnum {None,JUMP00, JUMP00B, JUMP01, JUMP01B,SLIDE00 }
/// <summary>
/// UnityChanのアニメーションをimportしている事
/// </summary>
public class VRMAnimControler : MonoBehaviour
{
    [SerializeField] Animator animator;
    private BaseVRMAnimEnum bae;
    public BaseVRMAnimEnum BaseAnimEnum
    {
        get => bae;
        set
        {
            if (value != bae)
            {
                bae = value; //代入値が違う時だけ更新
            }
        }
    }

    public SingleVRMAnimEnum AdditiveAnimEnum
    {
        get => (SingleVRMAnimEnum)animator.GetInteger("SingleActionAnimID");
        set
        {
            
            animator.SetInteger("SingleActionAnimID", (int)value);//値を更新 →後で0に戻す

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("BaseAnimID",(int)bae);
        
        //animator.SetInteger("AdditiveActionAnimID", 0);
    }
    
}
