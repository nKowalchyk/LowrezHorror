using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineofSight : MonoBehaviour
{
    public RaycastHit ObjectHit; //used to identify objects
    public float ReachLength; //Length of Raycast
    public bool TextboxOpen = false; //checks if a textbox is already open

    public DescriptionManager Description; //Rename if works
    public GameObject player;
    private PlayerController character; //store reference of player


    // Start is called before the first frame update
    void Start()
    {
        ReachLength = 4.0f;
        TextboxOpen = false;
        character = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*ReachLength, Color.red, 0.5f);
        //Casts a Ray in the forward direction of the player 
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ObjectHit, ReachLength))
        {
         
            //Sends information to DescriptionManager to display text
            if (ObjectHit.collider.tag == "InteractiveItem" || ObjectHit.collider.tag =="CollectableItem") //&& Input.GetKeyDown(KeyCode.E) && !TextboxOpen)
            {

                TextboxOpen = true;

                //displays textbox with the describtion of the object
                //Put a timer on
                Description.SetShowText(TextboxOpen);
                Description.SetGrabDescription(ObjectHit);
                //picks up the item if able

            }
            else
            {
                Description.HideText();

            }
        }
        else
        {
            Description.HideText();

        }
    }
    //Set TextboxOpen to False
    public void SetTextboxOpen(bool NewValue)
    {
        TextboxOpen = NewValue;
    }

    public void grabImage()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ObjectHit, ReachLength)) {

            //Sends information to DescriptionManager to display text
            if (ObjectHit.collider.tag == "InteractiveItem") //&& Input.GetKeyDown(KeyCode.E) && !TextboxOpen)
            {
                ObjectHit.collider.gameObject.GetComponent<IItemBehavior>().interact(character);
                character.state = PlayerController.PlayerState.Interacting;
            }
        }
    }
}
