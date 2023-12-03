using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public int minute;
    public float second;
    public AudioSource audio;
    public AudioClip clip;
    public TMP_Text btn,M,S;
    public bool isPlay,isFinish;
    void Start()
    {
        canvas.worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (isPlay && !isFinish)
        {
            second -= Time.deltaTime;
            if(second < 0)
            {
                if(minute > 0)
                {
                    minute--;
                    second = 60;
                }
                else
                {                   
                    btn.text = "Reset";
                    audio.Play();
                    second = 0;
                    minute = 0;
                    isFinish = true;
                }
            }
        }
    }
    public void UpdateUI()
    {
        M.text = minute + "";
        S.text = (int)second + "";
    }
    public void SetMinute(bool flag)
    {
        if (isPlay) return;
        if (flag) 
        {
            minute++;
            if (minute > 59) minute = 0;
        } 
        else
        {
            minute--;
            if (minute < 0) minute = 60;
        }
    }
    public void SetSecond(bool flag)
    {
        if (isPlay) return;
        if (flag)
        {
            second++;
            if (second > 59) second = 0;
        }
        else
        {
            second--;
            if (second < 0) second = 60;
        }
    }
    public void Play()
    {
        if (isFinish)
        {
            isPlay = false;
            isFinish = false;
            audio.Stop();
            btn.text = "Play";
        }
        else
        {
            if (isPlay)
            {
                isPlay = false;
                btn.text = "Play";
            }
            else if(second > 0 || minute > 0)
            {
                isPlay = true;
                btn.text = "Pause";
            }
        }       
    }
    public void Close()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
