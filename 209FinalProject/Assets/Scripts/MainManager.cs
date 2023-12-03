using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int curStage, curStep;
    int preStage = -1,preStep = -1;
    public int curRecipe;
    public AudioClip main,recipe;
    public GameObject control;
    public GameObject[] Stages;
    public GameObject back_Btn,next_Btn;
    public GameObject TimerPrefab;
    public Recipe[] recipes;
    public TMP_Text subtitle,time;
    public float offset;
    public VoiceGenerator voice;
    public Toggle[] toggles;
    public GameObject RecipesRoot, CookersRoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) Next();
        if (Input.GetKeyDown(KeyCode.C)) Back();
        if (Input.GetKeyDown(KeyCode.M)) Main();
        Refresh();
    }
    public void ChooseCooker(int index)
    {
        Debug.Log("Choose Cooker " + index);
        for (int i = 0; i < CookersRoot.transform.childCount; i++)
        {
            if(i == index) CookersRoot.transform.GetChild(i).GetComponent<Toggle>().isOn = !CookersRoot.transform.GetChild(i).GetComponent<Toggle>().isOn;
        }
    }
    public void ChooseRecipe()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            if(toggles[i].isOn)
            {
                curRecipe = i;
                curStage = 2;
                curStep = 0;
                break;
            }
        }
    }
    public void ResetChoice()
    {
        for(int i = 0; i < RecipesRoot.transform.childCount; i++)
        {
            RecipesRoot.transform.GetChild(i).GetComponent<Toggle>().isOn = false;
        }
        for (int i = 0; i < CookersRoot.transform.childCount; i++)
        {
            CookersRoot.transform.GetChild(i).GetComponent<Toggle>().isOn = false;
        }
    }
    public void Refresh()
    {       
        time.text = DateTime.Now + "";
        if (preStage != curStage)
        {
            ResetChoice();
            voice.Stop();
            preStage = curStage;
            if(curStage == 0)
            {
                back_Btn.SetActive(false);
                voice.audios.PlayOneShot(main);
            }
            else if(curStage == 1)
            {
                voice.audios.PlayOneShot(recipe);
            }
            else
            {
                back_Btn.SetActive(true);
            }
            if(curStage == 1)
            {
                next_Btn.SetActive(false);
            }
            else
            {
                next_Btn.SetActive(true);
            }
            for(int i = 0; i < Stages.Length; i++)
            {
                if (i == curStage) Stages[i].SetActive(true);
                else Stages[i].SetActive(false);
            }
        }
        if(preStep != curStep)
        {
            voice.Stop();
            preStep = curStep;
            if (curStep != -1)
            {
                subtitle.text = (curStep+1) + ".\n" + recipes[curRecipe].steps[curStep].subtitleText;
                voice.Generate(recipes[curRecipe].steps[curStep].subtitleText);
            }
        }
    }
    public void Next()
    {
        if (curStage == 1) return;
        Debug.Log("Next");
        if(curStage < 2)
        {
            curStage++;
        }
        else
        {
            curStep++;
            if(curStep >= recipes[curRecipe].steps.Length)
            {
                Main();
            }
        }
    }
    public void Back()
    {
        if (curStage == 0) return;
        if(curStep > 0)
        {
            curStep--;
        }
        else
        {
            if(curStep != -1)
            {
                curStep = -1;
            }
            curStage--;
        }
    }
    public void Main()
    {
        curStep = -1;
        curStage = 0;
    }
    public void SpawnTimer()
    {
        GameObject t = Instantiate(TimerPrefab);
        t.transform.position = control.transform.position + control.transform.TransformDirection(Vector3.back * offset);
    }
}
[Serializable]
public class Recipe
{
    public Step[] steps;
}
[Serializable]
public class Step
{
    [TextArea]
    public string subtitleText;
}
