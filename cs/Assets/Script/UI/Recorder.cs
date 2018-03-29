using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recorder : MonoBehaviour {
    private Text CT_text;
    private Text T_text;

    public void SetScore()
    {
        CT_text = GameObject.Find("CT Score").GetComponent<Text>();
        T_text = GameObject.Find("T Score").GetComponent<Text>();
        PlayerPrefs.SetString("CT Score", CT_text.text);
        PlayerPrefs.SetString("T Score", T_text.text);
    }

    public string GetCTScore()
    {
        return PlayerPrefs.GetString("CT Score", "DefaultValue");
    }

    public string GetTScore()
    {
        return PlayerPrefs.GetString("T Score", "DefaultValue");
    }

    public void ClearAllPrefs()
    {
        PlayerPrefs.DeleteAll();
        CT_text.text = "0";
        T_text.text = "0";
    }
}
