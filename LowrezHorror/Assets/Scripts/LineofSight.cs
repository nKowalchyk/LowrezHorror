using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineofSight : MonoBehaviour
{
    public RaycastHit ObjectHit; //used to identify objects
    public float ReachLength; //Length of Raycast
    public bool TextboxOpen = false; //checks if a textbox is already open

    public DescriptionManager Description; //Rename if works


    // Start is called before the first frame update
    void Start()
    {
        ReachLength = 4.0f;
        TextboxOpen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * ReachLength, Color.red, 0.5f);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ObjectHit, ReachLength))
        {
            if (ObjectHit.collider.tag == "InteractiveItem" && Input.GetKeyDown(KeyCode.E) && !TextboxOpen)
            {
                Debug.Log(ObjectHit.collider.name);


                TextboxOpen = true;

                //displays textbox with the describtion of the object
                //Put a timer on
                Description.SetShowText(TextboxOpen);

                //picks up the item if able



            }      
        }
    }

    public void SetTextboxOpen(bool NewValue)
    {
        TextboxOpen = NewValue;
    }
}
