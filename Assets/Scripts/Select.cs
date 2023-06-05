using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject Text1;
    public GameObject Text2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select1()
    {
        StartCoroutine(Select2());
    }

    IEnumerator Select2()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject2.SetActive(true);
        gameObject1.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(true);
        GameManager.flag = true;
        yield return 0;
    }
}
