using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(VRMAnimControler))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(VRMPlayerCamera))]
public class VRMPlayerVer2 : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpPower;
    VRMAnimControler vrmACon;
    Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        vrmACon = GetComponent<VRMAnimControler>();
        rd = GetComponent<Rigidbody>();
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
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.position += transform.right * walkSpeed * Time.deltaTime;
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WALK00_R;
            }
            else
            {
                transform.position += transform.right * runSpeed * Time.deltaTime;
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.RUN00_R;
            }


        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.position -= transform.right * walkSpeed * Time.deltaTime;
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.WALK00_L;
            }
            else
            {
                transform.position -= transform.right * runSpeed * Time.deltaTime;
                vrmACon.BaseAnimEnum = BaseVRMAnimEnum.RUN00_L;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && vrmACon.AdditiveAnimEnum == SingleVRMAnimEnum.None)
        {
            vrmACon.AdditiveAnimEnum = SingleVRMAnimEnum.JUMP00;
            rd.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
}
