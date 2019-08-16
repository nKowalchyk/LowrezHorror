using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public enum GhostState {
        ToggleLight, Chase, Wait
    }
    private float lightRange = 1.0f;
    private float relightRange = 2.5f;
    private float blinkTimerMax = 15.0f;
    private float blinkTimer;

    public float speed = 4.0f;

    private System.Random random = new System.Random();
    private GameObject playerObject;
    private CharacterController ghostController;
    private Renderer renderer;


    public GhostState state = GhostState.Wait;
    public GameObject[] lights;
    void Start() {
        lights = GameObject.FindGameObjectsWithTag("EnvLight");
        renderer = GetComponentInChildren<Renderer>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        ghostController = GetComponentInChildren<CharacterController>();
        blinkTimer = blinkTimerMax;
        disappear();
    }
    // Update is called once per frame
    void FixedUpdate() {
        toggleLightBehavior();

        switch(state) {
            case GhostState.ToggleLight:

                break;
            case GhostState.Chase:
                chaseBehavior();
                break;
            case GhostState.Wait:
                blinkTimer -= Time.deltaTime;
                if(blinkTimer <= 0.0f) {
                    blinkTimer = blinkTimerMax;
                    state = GhostState.Chase;
                    blink();
                }
                break;
        }
    }

    void patrolBehavior() {

    }

    void chaseBehavior() {
        var heading = playerObject.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        direction.y = 0;
        ghostController.Move(direction * Time.deltaTime * speed);
    }

    void toggleLightBehavior() {
        foreach (var light in lights) {
            if (Vector3.Distance(transform.position, light.transform.position) < lightRange && light.GetComponent<EnvironmentLightController>().isEnabled) {
                light.GetComponent<EnvironmentLightController>().toggleLights();
            //   state = GhostState.ToggleLight;
            }
            else if (Vector3.Distance(transform.position, light.transform.position) > relightRange && !light.GetComponent<EnvironmentLightController>().isEnabled) {
                light.GetComponent<EnvironmentLightController>().toggleLights();
            }
        }
    }

    void blink() {
        var x = random.Next(1, 2);
        var z = random.Next(1, 2);
        transform.position.Set(x, transform.position.y, z);
        renderer.enabled = true;
        state = GhostState.Chase;
    }

    void disappear() {
        renderer.enabled = false;
        state = GhostState.Wait;
    }
}
