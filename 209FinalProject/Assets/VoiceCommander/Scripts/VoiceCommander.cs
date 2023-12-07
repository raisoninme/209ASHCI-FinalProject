using System.Collections;
using System.Collections.Generic;
using Recognissimo.Components;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Recognissimo.Samples.VoiceControlExample
{
  [AddComponentMenu("")]
  public class VoiceCommander : MonoBehaviour
  {
    [SerializeField]
    private VoiceControl voiceControl;
    public Command[] commands;

    private void Start()
    {
      voiceControl.AsapMode = true;
        foreach(Command c in commands)
            {
                voiceControl.Commands.Add(new VoiceControlCommand(c.commandText, c.Delegate));
            }
      voiceControl.StartProcessing();
    }
    public void Test()
        {
            Debug.Log("Test");
        }
  }
}
[Serializable]
public class Command
{
    public string commandText;
    public UnityEvent Delegate;
}
