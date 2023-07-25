using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Camera camera;
    public AudioSource gunsound;
    public GameManager gameManager;
    public int count = 0;
    public int shootcnt = 0;

    public void Shoot()
    {
        shootcnt++;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Target")
            {
                Destroy(hit.transform.gameObject);
                gameManager.SpawnTarget();
                gameManager.ScoreUp();
                count++;
            } 
        }
        gameManager.AccuracyCheck();
    }

    
    void Start()
    {
        // 씬에서 GameManager 컴포넌트를 가진 오브젝트를 찾는 메소드
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Cursor.lockState = CursorLockMode.Locked;
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
