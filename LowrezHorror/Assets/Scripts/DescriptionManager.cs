using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public Text MyText;
    public Text inventoryText;
    private bool ShowText = false;
    private string collectiveInventory;
    private RaycastHit GrabDescription;
    public LineofSight LineofSight;

    // Start is called before the first frame update
    void Start()
    {
        collectiveInventory = "";


    }

    // Update is called once per frame
    public void SetShowText(bool change)
    {
        ShowText = change;
    }

    public void SetGrabDescription(RaycastHit ObjectHit)
    {
        GrabDescription = ObjectHit;
    }

    void Update()
    {
        //Checks if descriptions need to be displayed
        if (ShowText) {
                      
            ShowText = false;
            RevealText();
        }
       
    }

    //Called to Reveal the Description of object
    public void RevealText()
    {
        
        MyText.text = GrabDescription.collider.name;
        //Invoke("HideText", 3);
    }
    
    //Called to erase the text being displayed
    public void HideText()
    {
        
        MyText.text = "";
        LineofSight.SetTextboxOpen(false);
        
    }

    public void addText(string adding)
    {
        collectiveInventory = collectiveInventory + adding + "\n";
        inventoryText.text = collectiveInventory;
    }

}
