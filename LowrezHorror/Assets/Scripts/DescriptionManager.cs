using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public Text MyText;
    private bool ShowText = false;
    private RaycastHit GrabDescription;
    public LineofSight LineofSight;

    // Start is called before the first frame update
    void Start()
    {
        
     
    }

    // Update is called once per frame
    public void SetShowText(bool change)
    {
        ShowText = change;
    }

    void Update()
    {
        if (ShowText) {
            Debug.Log("Update If Statement");
            
            ShowText = false;
            RevealText();
        }
       
    }

    void RevealText()
    {
        Debug.Log("RevealText");
        MyText.text = "Description";
        Invoke("HideText", 3);
    }

    void HideText()
    {
        Debug.Log("HideText");
        MyText.text = "";
        LineofSight.SetTextboxOpen(false);
        
    }
}
