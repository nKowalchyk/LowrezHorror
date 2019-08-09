using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  Written By: Nick Kowalchyk
 *  Character Controller Class
 * 
 * 
 * 
 * 
 */
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;  //movement speed
    public float shiftSpeed = 8.0f; //sprint speed
    public float jumpSpeed = 8.0f;  //jump velocity
    public float gravity = 20.0f;   //gravity acceleration

    public float cameraRotationSpeedX = 2.0f;   //speed to rotate the camera horizontally
    public float cameraRotationSpeedY = 2.0f;   //speed to rotate the camera vertically
    private float yaw = 0.0f;   //camera rotation value horizontally
    private float pitch = 0.0f; //camera rotation value vertically
    private float maxYView = 50.0f;

    private CharacterController characterController;    //Unity CharacterController Asset that moves the Player object
    private Light[] lights;
    private Vector3 moveDirection = Vector3.zero;   //movement direction Vector3 updated every FixedUpdate determined by arrow keys
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        /*
        GameObject lightParent = null;
        for(int i = 0; i < transform.childCount; i++) {
            if(transform.GetChild(i).transform.gameObject.name == "Flashlight") {
                lightParent = transform.GetChild(i).transform.gameObject;
            }
        }
        if(lightParent) {
            lights = lightParent.GetComponents<Light>();

        } */

        lights = transform.gameObject.GetComponentsInChildren<Light>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            foreach (var light in lights) {
                light.enabled = !light.enabled;
            }
        }
    }

    void FixedUpdate()
    {
        if (true)
        {//characterController.isGrounded) {

            yaw += cameraRotationSpeedX * Input.GetAxis("Mouse X");
            pitch -= cameraRotationSpeedY * Input.GetAxis("Mouse Y");

            if ((pitch < -maxYView) || (pitch > maxYView))
            {
                pitch = maxYView * Mathf.Sign(pitch);
            }
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0.0f;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= shiftSpeed;
            }
            else
            {
                moveDirection *= speed;
            }

            if (Input.GetButton("Jump"))
            {
                //moveDirection.y = jumpSpeed;
            }

        }

        //moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
