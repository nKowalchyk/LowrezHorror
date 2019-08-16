using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItemBehavior : IItemBehavior
{
    public RawImage itemDisplay;
    void Start()
    {
        itemDisplay = GetComponentInChildren<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void interact(PlayerController player)
    {
        //player.Inventory.insertInventory(itemDisplay.texture);  //displayImage(itemDisplay.texture);
    }
}