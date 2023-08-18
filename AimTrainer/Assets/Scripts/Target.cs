using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Level lv;

    // Start is called before the first frame update
    void Start()
    {
        if (lv.level == 0)
        {
            StartCoroutine(easy());
        }
        else if (lv.level == 1)
        {
            StartCoroutine(normal());
        }
        else
        {
            StartCoroutine(hard());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator easy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this);
    }

    IEnumerator normal()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this);
    }

    IEnumerator hard()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this);
    }
}
