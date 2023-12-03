
using System.Collections;
using System.Collections.Generic;
using Recognissimo.Components;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Recognissimo.Samples.VoiceControlExample
{
    [AddComponentMenu("")]
    public class VoiceControlExample : MonoBehaviour
    {
        [SerializeField]
        private VoiceControl voiceControl;

        [SerializeField]
        private Text status;
        
        [SerializeField]
        private List<string> phrases;

        [SerializeField]
        private Transform textParent;

        [SerializeField]
        private GameObject textPrefab;
        
        private static readonly Color Active = Color.green;
        private static readonly Color Inactive = Color.black;

        private void Start()
        {
      DontDestroyOnLoad(this);
            voiceControl.AsapMode = true;
            
            foreach (var phrase in phrases)
            {
                var textGo = Instantiate(textPrefab, textParent);
                textGo.SetActive(true);
                var textComp = textGo.GetComponent<Text>();
                textComp.text = phrase;
                textComp.color = Inactive;
                
                if(phrase != "next") voiceControl.Commands.Add(new VoiceControlCommand(phrase, () => Highlight(textComp)));
                else voiceControl.Commands.Add(new VoiceControlCommand(phrase, () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);}));
      }
            voiceControl.InitializationFailed.AddListener(e => ShowError(e.Message));
            
            voiceControl.StartProcessing();
        }
        
        private void Highlight(Graphic text)
        {
            if (text.color == Active)
            {
                return;
            }
            
            StartCoroutine(HighlightCoroutine(text));
        }
        
        private static IEnumerator HighlightCoroutine(Graphic text)
        {
            text.color = Active;     
            yield return new WaitForSeconds(1);

            text.color = Inactive;
        }

        private void ShowError(string text)
        {
            status.gameObject.SetActive(true);
            status.color = Color.red;
            status.text = text;
        }
    }
}
