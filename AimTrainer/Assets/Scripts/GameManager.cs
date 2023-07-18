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

    public GameObject Target;

    StageInfo currentStageInfo;

    [SerializeField]
    private float time = 60f;
    [SerializeField]
    private float accuracy;
    [SerializeField]
    private int hitCount = 0;
    [SerializeField]
    private int shootCount = 0;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int hitScore = 100;

    [SerializeField]
    private bool isStarted = false;

    void Start()
    {
        //currentStageInfo = GameObject.FindObjectOfType<StageInfo>();
        //StartCoroutine(Ready());
    }

    void Update()
    {
        /* 게임 제한시간
        if(!isStarted) return;

        if(time <= 60) isStarted = true;

        time -= Time.deltaTime;
        timeText.text = Mathf.Floor(time / 60) + ":" + Mathf.Floor(time % 60);
        */
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
        isStarted = true;
    }

    void SpawnTarget()
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // 타겟을 랜덤한 위치에 스폰해야 함
        // 스폰 주기를 정해 두고 일정 시간마다 스폰할 건지
        // 타겟이 부서지는 순간 스폰할 건지 둘 중에 하나 구현해 보기
        // 이 메소드를 언제 어디서 실행할 건지도 정하기
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }

    public void ScoreUp()
    {
        score += 100;
        scoreText.text = string.Format("Score : {0}", score);
    }
}