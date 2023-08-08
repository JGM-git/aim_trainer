using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public Level getLevel;
    public Gun getGunMode;
    public int lv, gun;
    
    void Start()
    {
        getLevel = FindObjectOfType<Level>();
        getGunMode = FindObjectOfType<Gun>();
    }

    public void easy()
    {
        lv = 0;
        getLevel.level = lv;
        SceneManager.LoadScene("Select");
    }

    public void normal()
    {
        lv = 1;
        getLevel.level = lv;
        SceneManager.LoadScene("Select");
    }
    
    public void hard()
    {
        lv = 2;
        getLevel.level = lv;
        SceneManager.LoadScene("Select");
    }

    public void classic()
    {
        gun = 0;
        getGunMode.GunMode = gun;
        SceneManager.LoadScene("SampleScene");
    }

    public void ghost()
    {
        gun = 1;
        getGunMode.GunMode = gun;
        SceneManager.LoadScene("SampleScene");
    }

    public void sheriff()
    {
        gun = 2;
        getGunMode.GunMode = gun;
        SceneManager.LoadScene("SampleScene");
    }
}
