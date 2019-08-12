using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public enum GhostState {
        ToggleLight, Chase, Patrol
    }
    private float lightRange = 1.0f;


    public GhostState state = GhostState.Patrol;
    public GameObject[] lights;
    void Start() {
        lights = GameObject.FindGameObjectsWithTag("EnvLight");
    }
    // Update is called once per frame
    void Update() {
        foreach(var light in lights) {
            if(Vector3.Distance(transform.position, light.transform.position) < lightRange && light.GetComponent<EnvironmentLightController>().isEnabled) {
                light.GetComponent<EnvironmentLightController>().toggleLights();
            }
        }
    }
}
