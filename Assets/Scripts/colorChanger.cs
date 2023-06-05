using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    //把粒子对应赋予给这些变量
    public ParticleSystem MainVisualParticle;
    public ParticleSystem SplashParticle;
    public ParticleSystem ShootEffectParticle;
    //MainVisualParticle实例上的脚本
    public ParticlesController Pcolor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //完成逻辑实现变色
        if (Input.GetKey(KeyCode.A)){
            MainVisualParticle.startColor = Color.blue;
            SplashParticle.startColor = Color.blue;
            ShootEffectParticle.startColor = Color.blue;
            Pcolor.paintColor = Color.blue;
        }
    }
}
