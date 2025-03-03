using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController PlayerCharController;
    Transform TransformComp;
    public Transform CameraTransform;
    private float _speed = 1000.0f;
    public float MouseSensitivity = 30.0f;
    private float _pitch = 0.0f;
    private float _yaw = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCharController = this.GetComponent<CharacterController>();
        TransformComp = this.GetComponent<Transform>();
        //CameraObj = this.GetComponent<Camera>();
        _pitch = CameraTransform.localEulerAngles.x;
        _yaw = TransformComp.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for buttons pressed for movement.
        MovePlayer();
        LookUpdate();
    }

    void MovePlayer()
    {
        // We need to know L/R and F/B buttons pressed.
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Normalizing clamps to magnitude of 1.
        //move = Vector3.ClampMagnitude(move, 1.0f);
        move = Vector3.Normalize(move);

        move = transform.TransformDirection(move);
        
        PlayerCharController.SimpleMove(move * _speed * Time.deltaTime);
    }

    float minMaxRot = 45.0f;
    void LookUpdate()
    {
        //Quaternion.Euler()
        _pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        _pitch = Mathf.Clamp(_pitch, -minMaxRot, minMaxRot);

        CameraTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);
        //         Debug.Log("euler angles: " + CameraTransform.localEulerAngles.x);
        //         float localX = CameraTransform.localEulerAngles.x + (-Input.GetAxis("Mouse Y") * SensitivityY * Time.deltaTime);
        //         if (localX >= -minMaxRot && localX <= minMaxRot)
        //         {
        //             CameraTransform. .Rotate(localX, 0, 0);
        //         }
        _yaw += (Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime) % 360.0f;

        TransformComp.rotation = Quaternion.Euler(TransformComp.rotation.x, _yaw, TransformComp.rotation.z);
        // Stop undesired roll around Z axis by using world space.
        //TransformComp.Rotate(0, (Input.GetAxis("Mouse X") * SensitivityX * Time.deltaTime), 0, Space.World);
       // float YRotation = -Input.GetAxis("Mouse Y");
       
        //CameraTransform.eulerAngles = 

    }
}
