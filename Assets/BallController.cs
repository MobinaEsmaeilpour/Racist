using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Object")
        {
            transform.Translate(-Input.GetAxis("Vertical") * Time.deltaTime, 0f, Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
