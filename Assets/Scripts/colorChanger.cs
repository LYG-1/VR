using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    //�����Ӷ�Ӧ�������Щ����
    public ParticleSystem MainVisualParticle;
    public ParticleSystem SplashParticle;
    public ParticleSystem ShootEffectParticle;
    //MainVisualParticleʵ���ϵĽű�
    public ParticlesController Pcolor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����߼�ʵ�ֱ�ɫ
        if (Input.GetKey(KeyCode.A)){
            MainVisualParticle.startColor = Color.blue;
            SplashParticle.startColor = Color.blue;
            ShootEffectParticle.startColor = Color.blue;
            Pcolor.paintColor = Color.blue;
        }
    }
}
