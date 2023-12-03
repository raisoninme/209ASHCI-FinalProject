using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class VoiceGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] clips;
    public AudioSource audios;
    public string Apiurl;
    public int VoiceIndex;
    public float interval;
    public string test;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate(test);
        }   
    }
    public void Generate(string content)
    {
        StartCoroutine(CreateVoiceFromAPI(content));
    }
    public void Stop()
    {
        StopAllCoroutines();
        audios.Stop();
    }
    public IEnumerator CreateVoiceFromAPI(string text)
    {
        string[] texts = text.Split(new char[] { '？', '！', '。', '!', '?', '.' });
        clips = new AudioClip[texts.Length];
        for (int i = 0; i < texts.Length; i++)
        {
            UnityEngine.Debug.Log("生成開始 " + i);
            if (texts[i].Length > 0) StartCoroutine(CreateVoiceClipFromAPI(texts[i], i));
        }
        for (int i = 0; i < texts.Length; i++)
        {
            yield return new WaitUntil(() => clips[i] != null || texts[i].Length == 0);
            UnityEngine.Debug.Log("生成完成");
            audios.clip = clips[i];
            audios.Play();
            if (texts[i].Length > 0) yield return new WaitForSeconds(audios.clip.length);
        }
        yield return new WaitForSeconds(2f);
        clips = null;
    }
    public IEnumerator CreateVoiceClipFromAPI(string text, int index)
    {
        string url = Apiurl + "/voice/vits";
        text = text.Replace(" ", "");
        url += "?text=" + text + "&id=" + VoiceIndex + "&lang=" + "en" + "&format=wav";
        Debug.Log(url);
        using (var request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return request.SendWebRequest();
            if (request.responseCode == 200)
            {
                AudioClip audioclip = DownloadHandlerAudioClip.GetContent(request);
                UnityEngine.Debug.Log("獲取音頻");
                clips[index] = audioclip;
            }
            else
            {
                UnityEngine.Debug.Log(request.error);
            }
        }
    }
}
