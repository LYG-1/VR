using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Shoot : MonoBehaviour
{

    [SerializeField] ParticleSystem inkParticle;
    [SerializeField] Transform splatGunNozzle;

    XRNode leftControllerNode = XRNode.LeftHand;
    XRNode rightControllerNode = XRNode.RightHand;

    InputDevice leftController;
    InputDevice rightController;

    Vector2 primary2DAxisLeft;
    bool primary2DButtonLeft;
    Vector2 primary2DAxisRight;
    bool primary2DButtonRight;

    // Start is called before the first frame update
    void Start()
    {
        leftController = InputDevices.GetDeviceAtXRNode(leftControllerNode);
        rightController = InputDevices.GetDeviceAtXRNode(rightControllerNode);
        inkParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
        if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            inkParticle.Play();
            Debug.Log("Play");
        }
        else
        {
            inkParticle.Stop();
            Debug.Log("Stop");
        }
    }
}
