using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objectToFollow;
    public Vector3 offset;

    public float lookSpeed = 10;
    public float followSpeed = 10;

    public void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }
    public void MoveToTarget()
    {
        Vector3 targetPostition = objectToFollow.position + 
            objectToFollow.forward * offset.z + 
            objectToFollow.right * offset.x +
            objectToFollow.up * offset.y;

        transform.position = Vector3.Lerp(transform.position, targetPostition, followSpeed * Time.deltaTime);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
