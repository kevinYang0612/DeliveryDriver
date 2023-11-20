using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // accessing the car object, seralizing in camera field. 
    // in Unity, it allows you to reference the car 
    [SerializeField] GameObject carToFollow;
    // The camera should be the same as the car's position
    // It follows the car as the first person view. 

    void LateUpdate()
    {
        // it is accessing the camera (this script is added in component)
        // transform.position is accessing camera (x, y, z)
        transform.position = carToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
