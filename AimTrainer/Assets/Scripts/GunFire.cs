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
    public RaycastHit hit;

    public void Shoot()
    {
        transform.localEulerAngles = new Vector3(-15f, 3f, 0f);
        StartCoroutine(ShootAction());
        shootcnt++;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Target")
            {
                Destroy(hit.transform.gameObject);
                gameManager.ScoreUp();
                count++;
            }
        }
        gameManager.AccuracyCheck();
       
    }



    IEnumerator ShootAction()
    {
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(-12f, 3f, 0f);
        yield return new WaitForSeconds(0.03f);
        transform.localEulerAngles = new Vector3(-9f, 3f, 0f);
        yield return new WaitForSeconds(0.03f);
        transform.localEulerAngles = new Vector3(-6f, 3f, 0f);
        yield return new WaitForSeconds(0.03f);
        transform.localEulerAngles = new Vector3(-3f, 3f, 0f);
        yield return new WaitForSeconds(0.03f);
        transform.localEulerAngles = new Vector3(0f, 3f, 0f);

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
