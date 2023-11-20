using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // the car starts off white and no tint. 
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        // instantiate spriteRender by getComponent
        // getComponent is a function <T> is the type
        // car starts off with
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!!!");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package is picked up!");
            spriteRenderer.color = other.gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, destroyDelay); // delete package after pick up
            hasPackage = true;
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package is delivered.");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
