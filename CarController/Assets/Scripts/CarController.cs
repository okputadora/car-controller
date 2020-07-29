using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider frontDriverWheel, frontPassengerWheel;
    public WheelCollider rearDriverWheel, rearPassengerWheel;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;

    public float maxSteeringAngle = 45;
    public float motorForce = 50;

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontDriverWheel.steerAngle = steeringAngle;
        frontPassengerWheel.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        frontDriverWheel.motorTorque = verticalInput * motorForce;
        frontPassengerWheel.motorTorque = verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(rearDriverWheel, rearDriverT);
        UpdateWheelPose(frontPassengerWheel, frontPassengerT);
        UpdateWheelPose(frontDriverWheel, frontDriverT);
        UpdateWheelPose(rearPassengerWheel, rearPassengerT);
    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 pos = _transform.position;
        Quaternion quat = _transform.rotation;

        _collider.GetWorldPose(out pos, out quat);

        _transform.position = pos;
        _transform.rotation = quat;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
