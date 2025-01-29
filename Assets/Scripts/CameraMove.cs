using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private Rigidbody PlayerBody;

    private Vector3 initialOffset;
    private float xRotation;
    private float desiredX;
    private Transform playerCam;// = GetComponent<MainCamera>().transform;
    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        initialOffset = this.transform.position - targetObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = targetObject.position + initialOffset;

    }

    public void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity;
        
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        
        playerCam = this.transform;
        
        //Find current look rotation
        Vector3 rot = playerCam.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        xRotation = xRotation - mouseY;

        playerCam.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        PlayerBody.transform.Rotate(-Vector3.up * mouseX);
        orientation.transform.localRotation = Quaternion.Euler(0, desiredX, 0);


    }
}
