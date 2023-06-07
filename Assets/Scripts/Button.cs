using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject gameObject1;
    public GameObject gameObject2;

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
        gameObject2.SetActive(false);
    }

    public void Scence0()
    {
        SceneManager.LoadScene(0);
    }

    public void Scence1()
    {
        SceneManager.LoadScene(1);
    }

    public void Scence2()
    {
        SceneManager.LoadScene(2);
    }

}
