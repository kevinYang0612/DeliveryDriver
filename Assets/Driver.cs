using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // rotation at z axis. 
    // fps * speed = the displacement in one second
    // 500 fps * 1 = 500 means every frame drawing on screen, it moves 1 unit.
    // 500 fps * 0.1 = 50 means every frame drawing on screen, it moves 0.1 unit. 
    // in result, under 1 sec, speed = 1 moves 500 units vs speed = 0.1 moves 50 units.
    [SerializeField] float steerSpeed  = 150f;
    // SeralizeField allows a private field to be visible and editable in unity inspector.
    // displacement in y axis, for each frame, it moves 0.01 units to postive position
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 3f; // when bump to something, slower
    [SerializeField] float boostSpeed = 30f;
    float speedAdjustToNormal = 0.1f; 
    void Start()
    {
        transform.position = new Vector3(0, 10, 0);
    }

    // FYI, the car does not shift left and right, it only goes forward and backward
    // there is no x axis chaning at all, just y axis, when turning direction,
    // it brings the entire coordinate orienting to itself
    void Update() // every frame our computer calculates per second. 
    {
        // how much steering every single frame
        // horizontal is left and right turning, from -1 to +1
        // -1 * 200 * 0.001 = -0.2, moving -0.2 unit per frame.  
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if (moveAmount < 0) // moving backwards
        {
            steerAmount = -steerAmount;
        }
        // calling transform rotate in Unity, args: x, y, z
        // left key is negative, -- = +, it is turning to counter clockwise
        // (which is the direct unity drawing)
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        if (moveSpeed > 15)
        {
            moveSpeed -= speedAdjustToNormal;
        }
        else if (moveSpeed < 15)
        {
            moveSpeed += speedAdjustToNormal;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Booster")
        {
            this.moveSpeed = this.boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        this.moveSpeed = this.slowSpeed;
    }
}
