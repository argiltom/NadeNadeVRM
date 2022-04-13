using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// VRM�̍����̃I�u�W�F�N�g�ɃA�^�b�`���A�J������R�Â��邱�ƂŎg�����Ƃ��o����D
/// </summary>
public class VRMPlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject _cameraObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraRot();
    }

    void UpdateCameraRot()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        transform.Rotate(0, X_Rotation, 0);
        _cameraObject.transform.Rotate(-Y_Rotation, 0, 0);
    }
}
