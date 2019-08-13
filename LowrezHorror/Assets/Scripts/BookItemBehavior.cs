using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookItemBehavior : IItemBehavior {
    private RawImage bookDisplay;
    void Start() {
        bookDisplay = GetComponentInChildren<RawImage>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public override void interact(PlayerController player) {
        player.displayImage(bookDisplay.texture);
    }
}
