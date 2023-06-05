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
    [SerializeField] Transform head;
    public float spawDistance = 2;
    [SerializeField] static public bool flag = true;

    //�����Ӷ�Ӧ�������Щ����
    public ParticleSystem MainVisualParticle;
    public ParticleSystem SplashParticle;
    public ParticleSystem ShootEffectParticle;
    //MainVisualParticleʵ���ϵĽű�
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
            if (c < 9)
                c++;
            else
                c = 0;
            MainVisualParticle.startColor = color[c];
            SplashParticle.startColor = color[c];
            ShootEffectParticle.startColor = color[c];
            Pcolor.paintColor = color[c];
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
