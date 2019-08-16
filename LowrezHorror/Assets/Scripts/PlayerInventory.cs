using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{   
    public CanvasGroup InventoryCanvas;
    public string[] InventoryArray;
    public InventorySlots test;
    public DescriptionManager Description;

    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas.alpha = 0f;
        InventoryCanvas.blocksRaycasts = false;
        InventoryArray = new string[5];
    }

    // Update is called once per frame
    void Update()
    {
       
        



    }

    public void insertInventory(string Insert)
    {
        
        for (int i = 0; i < 5; i++)
        { 
            if (InventoryArray[i] == null)
            {
                InventoryArray[i] = Insert;
                Description.addText(Insert);
                break;                   
            }
        }
    }

    public void ShowInventory()
    {
        InventoryCanvas.alpha = 1f;
        InventoryCanvas.blocksRaycasts = true;
        
        for (int i = 0; i < 5; i++)
        {
            if(InventoryArray[i] == null)
            {
                Debug.Log("Empty");
                    
            }
            else
            {
                //display image in Inventory Slot [i,j]
                Debug.Log(InventoryArray[i]);
            }
            
            
        }
        
    }

    public void HideInventory()
    {
        InventoryCanvas.alpha = 0f;
        InventoryCanvas.blocksRaycasts = false;
    }
}
