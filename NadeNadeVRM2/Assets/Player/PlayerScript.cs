using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject CenterEyeAnchor;
    
    [SerializeField] GameObject leftOVAControllerPrefab;
    [SerializeField] GameObject rightOVAControllerPrefab;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    OVRInput.Controller rightController;
    OVRInput.Controller leftController;
    Rigidbody rigidbody;
    
    
    /// <summary>
    /// レバガチャ左
    /// </summary>
    [System.NonSerialized]public Vector2 controllerRotationOfLeft;
    /// <summary>
    /// レバガチャ右
    /// </summary>
    [System.NonSerialized] public Vector2 controllerRotationOfRight;

    [System.NonSerialized] public float leftPrimaryIndexTrigger;
    [System.NonSerialized] public float rightPrimaryIndexTrigger;
    [System.NonSerialized] public float leftPrimaryHandTrigger;
    [System.NonSerialized] public float rightPrimaryHandTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rightController = rightOVAControllerPrefab.GetComponent<OVRControllerHelper>().m_controller;
        leftController = leftOVAControllerPrefab.GetComponent<OVRControllerHelper>().m_controller;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.One, rightController))
        {
            rigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

        }


        //押した瞬間OVRInput.GetDown(OVRInput.Button.Two, controller)
        controllerRotationOfLeft =OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, leftController);
        controllerRotationOfRight = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController);
        leftPrimaryIndexTrigger=OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, leftController);
        rightPrimaryIndexTrigger=OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, rightController);
        leftPrimaryHandTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, leftController);
        rightPrimaryHandTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, rightController);


        Vector3 tempPos = CenterEyeAnchor.transform.forward * speed * controllerRotationOfLeft.y * Time.deltaTime;
        transform.position += new Vector3(tempPos.x, 0, tempPos.z); //y軸の運動を無効化
        Vector3 tempPos2 = CenterEyeAnchor.transform.right * speed * controllerRotationOfLeft.x * Time.deltaTime;
        transform.position += new Vector3(tempPos2.x, 0, tempPos2.z);
      

    }


}
