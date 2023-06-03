using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject gameObject1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
        gameObject1.SetActive(true);
    }

}
