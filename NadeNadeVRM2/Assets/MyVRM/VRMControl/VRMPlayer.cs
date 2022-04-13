using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(VRMAnimControler))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class VRMPlayer : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float walkRotSpeed;
    [SerializeField] float runRotSpeed;
    [SerializeField] float jumpPower;
    VRMAnimControler vrmACon;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        vrmACon = GetComponent<VRMAnimControler>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WAIT00;
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.position += transform.forward * walkSpeed * Time.deltaTime;
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WALK00_F;
            }
            else
            {
                transform.position += transform.forward * runSpeed * Time.deltaTime;
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.RUN00_F;
            }
            
        }
        
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * walkSpeed * Time.deltaTime;
            vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WALK00_B;
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {

            Vector3 rot = transform.rotation.eulerAngles;
            Quaternion qrot = Quaternion.Euler(new Vector3(rot.x, rot.y + 90, rot.z));
            
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qrot, walkRotSpeed * Time.deltaTime);
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WALK00_R;
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qrot, runRotSpeed * Time.deltaTime);
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.RUN00_R;
            }

                
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            Vector3 rot = transform.rotation.eulerAngles;
            Quaternion qrot = Quaternion.Euler(new Vector3(rot.x, rot.y - 90, rot.z));
            
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qrot, walkRotSpeed * Time.deltaTime);
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WALK00_L;
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qrot, runRotSpeed * Time.deltaTime);
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.RUN00_L;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl)&&vrmACon.AdditiveAnimEnum== SingleVRMAnimEnum.None)
        {
            vrmACon.AdditiveAnimEnum = SingleVRMAnimEnum.JUMP00;
            rigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    /// <summary>
    /// 指定の座標に対してゆっくりと向く
    /// </summary>
    /// <param name="targetPos"></param>
    /// <param name="rotArg"></param>
    void LookingTarget(Vector3 targetPos, Vector3 rotSpeed)
    {
        //ターゲット
        Vector3 deviation = targetPos - transform.position;
        //Quaternion rot = Quaternion.LookRotation(deviation, transform.position);
        Quaternion rot = Quaternion.LookRotation(deviation);
        float slerpX = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed.x * Time.deltaTime).eulerAngles.x;
        float slerpY = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed.y * Time.deltaTime).eulerAngles.y;
        float slerpZ = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed.z * Time.deltaTime).eulerAngles.z;
        transform.rotation = Quaternion.Euler(slerpX, slerpY, slerpZ);
    }
}

