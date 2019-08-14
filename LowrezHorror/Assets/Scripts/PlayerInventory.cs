using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{   
    public CanvasGroup InventoryCanvas;
    private GameObject[,] InventoryArray;
    
    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas.alpha = 0f;
        InventoryCanvas.blocksRaycasts = false;
        InventoryArray = new GameObject[3, 3];
    }

    // Update is called once per frame
    void Update()
    {
       
        



    }

    public void InsertInventory(GameObject Insert)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (InventoryArray[i,j] == null)
                {
                    InventoryArray[i, j] = Insert;
                    i = 3;
                    j = 3;
                }
            }
        }
    }

    public void ShowInventory()
    {
        InventoryCanvas.alpha = 1f;
        InventoryCanvas.blocksRaycasts = true;
        /*for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(InventoryArray[i,j] == null)
                {
                    //display no image
                    
                }
                else
                {
                    //display image in Inventory Slot [i,j]

                }
            
            }
        }*/
    }

    public void HideInventory()
    {
        InventoryCanvas.alpha = 0f;
        InventoryCanvas.blocksRaycasts = false;
    }
}
