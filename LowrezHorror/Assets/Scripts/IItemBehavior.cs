using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItemBehavior : MonoBehaviour {
    public abstract void interact(PlayerController player);
}
