using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Camera camera;
    public AudioSource gunsound;
    GameManager gameManager;

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Target")
            {
                Destroy(hit.transform.gameObject);
            } 
        }
    }

    void Start()
    {
        // 씬에서 GameManager 컴포넌트를 가진 오브젝트를 찾는 메소드
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // GameManager 의 ScoreUp() 메소드를 실행해야 함
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}
