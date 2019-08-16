using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  Written By: Nick Kowalchyk
 *  Character Controller Class
 * 
 * 
 * 
 * 
 */
public class PlayerController : MonoBehaviour
{
    public enum PlayerState {
        Interacting, Free, Inventory
    }

    public PlayerState state = PlayerState.Free;
    public float speed = 5.0f;  //movement speed
    public float shiftSpeed = 8.0f; //sprint speed
    public float jumpSpeed = 8.0f;  //jump velocity
    public float gravity = 20.0f;   //gravity acceleration

    public float cameraRotationSpeedX = 2.0f;   //speed to rotate the camera horizontally
    public float cameraRotationSpeedY = 2.0f;   //speed to rotate the camera vertically
    private float yaw = 0.0f;   //camera rotation value horizontally
    private float pitch = 0.0f; //camera rotation value vertically
    private float maxYView = 50.0f;
    private bool openInventory = false;

    private CharacterController characterController;    //Unity CharacterController Asset that moves the Player object
    private Light[] lights;
    private Vector3 moveDirection = Vector3.zero;   //movement direction Vector3 updated every FixedUpdate determined by arrow keys
    private RawImage playerImage;

    public GameObject lineOfSightParent;
    private LineofSight lineOfSight;

    public PlayerInventory Inventory;
    
    
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerImage = GetComponentInChildren<RawImage>();
        playerImage.enabled = false;
        lineOfSight = lineOfSightParent.GetComponentInChildren<LineofSight>();

        lights = transform.gameObject.GetComponentsInChildren<Light>();

        
    }

    // Update is called once per frame
    void Update() {

        if(state == PlayerState.Free) {
            if (Input.GetKeyDown(KeyCode.F)) {
                foreach (var light in lights) {
                    light.enabled = !light.enabled;
                }
            }

            if(Input.GetKeyDown(KeyCode.E)) {
                lineOfSight.grabImage();
                lineOfSight.collectItem();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {

                Inventory.ShowInventory();
                state = PlayerState.Inventory;
            }
        }
        else if(state == PlayerState.Interacting) {
            if (Input.GetKeyDown(KeyCode.E)) {
               freePlayer();
            }
        }
        else if (state == PlayerState.Inventory)
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Inventory.HideInventory();
                freePlayer();
            }
            
        }

    }

    void FixedUpdate()
    {
        if (state == PlayerState.Free) {

            yaw += cameraRotationSpeedX * Input.GetAxis("Mouse X");
            pitch -= cameraRotationSpeedY * Input.GetAxis("Mouse Y");

            if ((pitch < -maxYView) || (pitch > maxYView)) {
                pitch = maxYView * Mathf.Sign(pitch);
            }
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0.0f;

            if (Input.GetKey(KeyCode.LeftShift)) {
                moveDirection *= shiftSpeed;
            }
            else {
                moveDirection *= speed;
            }

            if (Input.GetButton("Jump")) {
                //moveDirection.y = jumpSpeed;
            }

            //moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
        
    }

    public void displayImage(Texture text)
    {
        
        if (playerImage.enabled == false) {
            playerImage.texture = text;
            playerImage.enabled = true;
        }
        else {
            playerImage.enabled = false;
        }
    }

    public void freePlayer() {
        playerImage.enabled = false;
        playerImage.texture = null;
        state = PlayerState.Free;
    }
}
