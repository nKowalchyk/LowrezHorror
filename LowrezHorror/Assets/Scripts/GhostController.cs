using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public enum GhostState {
        ToggleLight, Chase, Patrol
    }
    private float lightRange = 1.0f;
    private float relightRange = 2.5f;
    private float lightTimer = 5.0f;


    public GhostState state = GhostState.Patrol;
    public GameObject[] lights;
    void Start() {
        lights = GameObject.FindGameObjectsWithTag("EnvLight");
    }
    // Update is called once per frame
    void Update() {
        toggleLightBehavior();

        switch(state) {
            case GhostState.ToggleLight:

                break;
            case GhostState.Chase:
                break;
            case GhostState.Patrol:
                break;
        }
    }

    void patrolBehavior() {

    }

    void chaseBehavior() {

    }

    void toggleLightBehavior() {
        foreach (var light in lights) {
            if (Vector3.Distance(transform.position, light.transform.position) < lightRange && light.GetComponent<EnvironmentLightController>().isEnabled) {
                light.GetComponent<EnvironmentLightController>().toggleLights();
                state = GhostState.ToggleLight;
            }
            else if (Vector3.Distance(transform.position, light.transform.position) > relightRange && !light.GetComponent<EnvironmentLightController>().isEnabled) {
                light.GetComponent<EnvironmentLightController>().toggleLights();
            }
        }
    }
}
