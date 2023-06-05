using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] ParticleSystem inkParticle;
    [SerializeField] Transform splatGunNozzle;

    [SerializeField] GameObject menu;
    [SerializeField] Transform head;
    public float spawDistance = 2;
    [SerializeField] static public bool flag = false;


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

        if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z) * spawDistance;
            menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
            menu.transform.forward *= -1;
            menu.SetActive(!menu.activeSelf);
        }


        if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            SceneManager.LoadScene(0);
        }


        if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            SceneManager.LoadScene(1);
        }
        if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            SceneManager.LoadScene(2); 
        }

        if (flag && rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            inkParticle.Play();
        }
        else
        {
            inkParticle.Stop();
        }
    }
}
