using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author : Pierre GuÃ©rineau

/// <summary>
/// Move attached object smoothly to target
/// </summary>
public class FollowTargetSmooth : MonoBehaviour
{
    /// <summary>
    /// Target to follow
    /// </summary>
    public Transform target;
    //public Transform target2;
    
    /// <summary>
    /// Smoothing time for position
    /// </summary>
    public float smoothTimePos = 0.1f;
    
    /// <summary>
    /// Smoothing time for rotation
    /// </summary>
    public float smoothTimeRot = 0.3f;
    
    /// <summary>
    /// Distance offset to the front of the target
    /// </summary>
    public float offset;
    // Velocity and deriv
    private Vector3 velocity = Vector3.zero;
    private Quaternion deriv = Quaternion.identity;

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!target2.gameObject.activeInHierarchy) {
            Vector3 desiredPosition = target.position + target.forward * offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTimePos);
            Quaternion desiredRotation = target.rotation;
            transform.rotation = QuaternionUtil.SmoothDamp(transform.rotation, desiredRotation, ref deriv, smoothTimeRot);
        //} else {
            //this.gameObject.SetActive(false);
        //}
    }
}

