using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text accuracyText;
    public TMP_Text timeText;
    public TMP_Text readyText;
    public GameObject targetPrefab;
    public GunFire gf;
    public FirstPersonMouseMove fpmm;
    public Level lev;
    public Gun gnm;
    public GameObject classic;
    public GameObject ghost;
    public GameObject sheriff;
    private int t = 60;
    public GameObject targetClone;


    StageInfo currentStageInfo;

    [SerializeField]
    private float time = 60f;
    [SerializeField]
    private float accuracy;
    [SerializeField]
    private int hitCount = 0;
    [SerializeField]
    private int shootCount = 0;
    public int score = 0;

    [SerializeField]
    private bool isStarted = false;

   

    void Start()
    {
        lev = FindObjectOfType<Level>();
        gnm = FindObjectOfType<Gun>();
        
        fpmm = FindObjectOfType<FirstPersonMouseMove>();
        //currentStageInfo = GameObject.FindObjectOfType<StageInfo>();
        
        StartCoroutine(Ready());
        if (gnm.GunMode == 0)
        {
            classic.SetActive(true);
        }

        if (gnm.GunMode == 1)
        {
            ghost.SetActive(true);
        }

        if (gnm.GunMode == 2)
        {
            sheriff.SetActive(true);
        }
        gf = FindObjectOfType<GunFire>();
    }

    void Update()
    {
 
        if(!isStarted) return;

        if(time <= 60) isStarted = true;

        time -= Time.deltaTime;
        timeText.text = Mathf.Floor(time / 60) + ":" + Mathf.Floor(time % 60);
        
        if (Mathf.Floor(time / 60) == 0 && Mathf.Floor(time % 60) == 0)
        {
            isStarted = false;
            gf.enabled = false;
            fpmm.enabled = false;
        }
        

    }

    IEnumerator Ready()
    {
        yield return new WaitForSeconds(1f);
        readyText.text = "3";
        yield return new WaitForSeconds(1f);
        readyText.text = "2";
        yield return new WaitForSeconds(1f);
        readyText.text = "1";
        yield return new WaitForSeconds(1f);
        readyText.gameObject.SetActive(false);
        gf.enabled = true;
        fpmm.enabled = true;
        isStarted = true;
        SpawnTarget();
    }


    IEnumerator Easy()
    {
        while (t > 0)
        {
            yield return new WaitForSeconds(5f);
            if (targetClone == true)
            {
                Destroy(targetClone);
                SpawnTarget();
            }
            else 
            {
                SpawnTarget();
            }
            t -= 2;
        }
    }

    IEnumerator Normal()
    {
        while (t > 0)
        {
            yield return new WaitForSeconds(3f);
            if (targetClone == true)
            {
                Destroy(targetClone);
                SpawnTarget();
            }
            else 
            {
                SpawnTarget();
            }
        }
    }

    IEnumerator Hard()
    {
        while (t > 0)
        {
            yield return new WaitForSeconds(1f);
            if (targetClone == true)
            {
                Destroy(targetClone);
                
            }
            Vector3 targetTrans = new Vector3(Random.Range(-20f, 20f), Random.Range(2f, 10f), Random.Range(-5f, 20f));
            Quaternion targetRot = Quaternion.Euler(0f, 0f, 0f);
            targetClone = Instantiate(targetPrefab, targetTrans, targetRot);
        }
    }

    public void SpawnTarget()
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // 타겟을 랜덤한 위치에 스폰해야 함
        // 스폰 주기를 정해 두고 일정 시간마다 스폰할 건지
        // 타겟이 부서지는 순간 스폰할 건지 둘 중에 하나 구현해 보기
        // 이 메소드를 언제 어디서 실행할 건지도 정하기
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Vector3 targetTrans = new Vector3(Random.Range(-20f, 20f), Random.Range(2f, 10f), Random.Range(-5f, 20f));
        Quaternion targetRot = Quaternion.Euler(0f, 0f, 0f);
        targetClone = Instantiate(targetPrefab, targetTrans, targetRot);

        if (lev.level == 0)
        {
            StartCoroutine(Easy());
        }
        else if (lev.level == 1)
        {
            StartCoroutine(Normal());
        }
        else
        {
            StartCoroutine(Hard());
        }
    }

    public void ScoreUp()
    {
        score += 100;
        scoreText.text = string.Format("Score : {0}", score);
    }

    public void AccuracyCheck()
    {
        accuracy = gf.count * 100 / gf.shootcnt;
        accuracyText.text = "Accuarcy : " + accuracy + "%";
    }
}