using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;

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
        yield return new WaitForSeconds(0.4f);
        gameObject2.SetActive(true);
        gameObject1.SetActive(false);
        GameManager.flag = true;
        yield return 0;
    }
}
