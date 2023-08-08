using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnz1 = 10f, spawnz2 = 20f, spawnx1 = -20f, spawnx2 = 20f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomPosition = new Vector3(Random.Range(spawnx1, spawnx2), Random.Range(1f, 20f), Random.Range(spawnz1, spawnz2));
        GameObject target = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}