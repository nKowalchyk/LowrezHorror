using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLightController : ILightBehaviorController {
    // Start is called before the first frame update
    private Light[] lights;
    public bool isEnabled;
    void Start() {
        lights = transform.gameObject.GetComponentsInChildren<Light>();
        Debug.Log(lights.Length);
        if(lights.Length > 0) {
            isEnabled = lights[0].enabled;
            Debug.Log(lights[0].enabled);
        }
    }

    // Update is called once per frame
    void Update() {
    }

    public override void toggleLights() {
        foreach(var light in lights) {
            light.enabled = !light.enabled;
        }
        isEnabled = !isEnabled;
    }
}
