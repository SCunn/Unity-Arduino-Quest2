// This script was altered to fix the null reference exception error that was occurring when the SetHandPose movement functions were invoked from the OVRPlayerControllerWithHandPoses.cs.
// Github Copilot was used to help fix the null reference exception error caused in this script.
using System.Linq;
using DilmerGames.Core.Singletons;
using TMPro;
using UnityEngine;
using System;

public class Logger : Singleton<Logger>
{
    [SerializeField]
    private TextMeshProUGUI debugAreaText = null;

    [SerializeField]
    private bool enableDebug = false;

    [SerializeField]
    private int maxLines = 15;

    void Awake()
    {
        if (debugAreaText == null)
        {
            debugAreaText = GetComponent<TextMeshProUGUI>();
        }
        //debugAreaText.text = string.Empty;        // original code, commented out to try to fix the null reference exception error
        if (debugAreaText != null) 
        {
            debugAreaText.text = string.Empty;
        }
    }

    void OnEnable()
    {
        if (debugAreaText != null)
        {//// Original code inside of if statement ////////////
            debugAreaText.enabled = enableDebug;
            enabled = enableDebug;

            if (enabled)
            {
                debugAreaText.text += $"<color=\"white\">{DateTime.Now.ToString("HH:mm:ss.fff")} {this.GetType().Name} enabled</color>\n";
            }
        //////////////////////////////////////////////////////
        }
    }

    //public void Clear() => debugAreaText.text = string.Empty; // original code, commented out to try to fix the null reference exception error
    public void Clear() 
    {
        if (debugAreaText != null)
        {
            debugAreaText.text = string.Empty;
        }
    }

    public void LogInfo(string message)
    {
        ClearLines();
        //debugAreaText.text += $"<color=\"green\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";  // original code, commented out to try to fix the null reference exception error
        // new code to check if debug area is not null
        if (debugAreaText != null)
        {
            debugAreaText.text += $"<color=\"green\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";
        }
    }

    public void LogError(string message)
    {
        ClearLines();
        debugAreaText.text += $"<color=\"red\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";
    }

    public void LogWarning(string message)
    {
        ClearLines();
        debugAreaText.text += $"<color=\"yellow\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";
    }

    private void ClearLines()
    {   // original code, commented out to try to fix the null reference exception error
        //if (debugAreaText.text.Split('\n').Count() >= maxLines)
        //{
        //    debugAreaText.text = string.Empty;
        //}
        // new code to check if debug area is not null, adding this removed the null reference exception error
        if (debugAreaText != null && debugAreaText.text.Split('\n').Count() >= maxLines) 
        {
            debugAreaText.text = string.Empty;
        }
    }
}