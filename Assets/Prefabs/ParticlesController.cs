using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController: MonoBehaviour{
    public Color paintColor;
    
    public float minRadius = 0.1f;
    public float maxRadius = 0.2f;
    [SerializeField] static public float m = 1;
    public float m1 = 1;
    public float strength = 1;
    public float hardness = 1;
    [Space]
    ParticleSystem part;
    List<ParticleCollisionEvent> collisionEvents;

    void Start(){
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        //var pr = part.GetComponent<ParticleSystemRenderer>();
        //Color c = new Color(pr.material.color.r, pr.material.color.g, pr.material.color.b, .8f);
        //paintColor = c;
    }

    void OnParticleCollision(GameObject other) {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        m1 = m;
        Paintable p = other.GetComponent<Paintable>();
        if(p != null){
            for  (int i = 0; i< numCollisionEvents; i++){
                Vector3 pos = collisionEvents[i].intersection;
                float radius = Random.Range(minRadius, maxRadius);
                PaintManager.instance.paint(p, pos, radius * m, hardness, strength, paintColor);
            }
        }
    }
}