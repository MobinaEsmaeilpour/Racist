using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //[SerializeField]
    //WheelCollider frontRight;
    //[SerializeField]
    //WheelCollider frontLeft;
    //[SerializeField]
    //WheelCollider backRight;
    //[SerializeField]
    //WheelCollider backLeft;

    //public float acceleration = 10f;
    //public float brakingForce = 300f;

    //private float currentAcceleration = 0f;
    //private float currentBrakeForce = 0f;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}
    //private void FixedUpdate()
    //{
    //    currentAcceleration = 10 * Input.GetAxis("Vertical");


    //    if (Input.GetKey(KeyCode.Space))
    //        currentBrakeForce = brakingForce;
    //    else
    //        currentBrakeForce = 0;



    //}
    //// Update is called once per frame
    //void Update()
    //{

    //    frontRight.motorTorque = 10 * Input.GetAxis("Vertical"); 
    //    frontLeft.motorTorque = 10 * Input.GetAxis("Vertical"); 
    //    backRight.motorTorque = 10 * Input.GetAxis("Vertical");
    //    backLeft.motorTorque = 10 * Input.GetAxis("Vertical");

    //    //frontRight.brakeTorque = currentBrakeForce;
    //    //frontLeft.brakeTorque = currentBrakeForce;
    //}


    public float speed = 20f;
    public Rigidbody rb;
    public AudioSource audioSource;

    public GameObject FrontCamera, BackCamera, TCamera;
    public int idxCamera;

    public Light spotLightLeft, spotLightRight;
    // Start is called before the first frame update

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        idxCamera = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, Time.deltaTime * speed);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            idxCamera += 1;
            changeCamera();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            audioSource.Stop();
        }



        if ((transform.position.x>-200 && transform.position.x<150) && (transform.position.z > -200 && transform.position.z < 200))
        {
            spotLightLeft.intensity = 8f;
            spotLightRight.intensity = 8f;
        }
        else
        { 
            spotLightLeft.intensity = 0f;
            spotLightRight.intensity = 0f;
        }
    }

    public void changeCamera()
    {
       switch(idxCamera)
        {
            case 0:
                FrontCamera.SetActive(true);
                TCamera.SetActive(false);
                break;
            case 1:
                BackCamera.SetActive(true);
                FrontCamera.SetActive(false);
                break;
            case 2:
                TCamera.SetActive(true);
                BackCamera.SetActive(false);
                idxCamera = -1;
                break;
            default:
                FrontCamera.SetActive(true);
                break;
        }
    }

}
