using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ParticleSystem inkParticle;
    [SerializeField] Transform splatGunNozzle;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject player;
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform head;
    public float spawDistance = 2;
    [SerializeField] static public bool flag = true;
    public int tm = 30;
    public int t = 0;

    //把粒子对应赋予给这些变量
    public ParticleSystem MainVisualParticle;
    public ParticleSystem SplashParticle;
    public ParticleSystem SubEmitter0;
    public ParticleSystem ShootEffectParticle;
    //MainVisualParticle实例上的脚本
    public ParticlesController Pcolor;
    public int c = 0;
    public Color[] color;    

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
        characterController = player.GetComponent<CharacterController>();
        inkParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;

        if (t > 0)
        {
            t--;
        }

        if (t <= 0 && leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue) 
        {
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z) * spawDistance;
            menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
            menu.transform.forward *= -1;
            menu.SetActive(!menu.activeSelf);
            t = tm;
        }


        if (t <= 0 && leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            if (c < 9)
                c++;
            else
                c = 0;
            MainVisualParticle.startColor = color[c];
            SplashParticle.startColor = color[c];
            ShootEffectParticle.startColor = color[c];
            SubEmitter0.startColor = color[c];
            Pcolor.paintColor = color[c];
            t = tm;
        }

        if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            if (ParticlesController.m > 0.2)
            {
                ParticlesController.m -= 0.02f;
            }
        }

        if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            if (ParticlesController.m < 5)
            {
                ParticlesController.m += 0.02f;
            }
        }

        if (flag && leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            characterController.Move(transform.up * 0.05f);
        }
/*        else
        {
            characterController.Move(transform.up * -0.1f);
        }*/

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
