using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;

public class VoiceGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] clips;
    public AudioSource audios;
    public string Apiurl;
    public string Apikey;

    void Start()
    {
        
    }
    void Update()
    {

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
            if (texts[i].Length > 0) StartCoroutine(CreateVoiceClipFromAPI(texts[i], i));
        }
        for (int i = 0; i < texts.Length; i++)
        {
            yield return new WaitUntil(() => clips[i] != null || texts[i].Length == 0);
            audios.clip = clips[i];
            audios.Play();
            if (texts[i].Length > 0) yield return new WaitForSeconds(audios.clip.length);
        }
        yield return new WaitForSeconds(2f);
        clips = null;
    }
    

    public IEnumerator CreateVoiceClipFromAPI(string text, int index)
    {
        // Note: 'model' and 'voice' are parameters specific to OpenAI's TTS API
        string requestData = $"{{\"model\":\"tts-1\",\"input\":\"{text}\",\"voice\":\"alloy\"}}";

        using (var request = new UnityWebRequest(Apiurl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(requestData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            // request.downloadHandler = new DownloadHandlerBuffer();
            request.downloadHandler = new DownloadHandlerAudioClip("MyAudioClip", AudioType.MPEG);
            request.SetRequestHeader("Authorization", "Bearer " + Apikey);
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.responseCode == 200)
            {
                // Assuming the response contains the audio data, you need to handle it accordingly
                AudioClip audioclip = DownloadHandlerAudioClip.GetContent(request);
                Debug.Log("Received audio");
                clips[index] = audioclip;
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }


}
