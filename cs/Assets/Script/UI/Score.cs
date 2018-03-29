using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int C_number;                                 //记录C的剩余人数
    private int CT_number;                                //记录CT的剩余人数
    private AudioSource[] audioSource;                    //音效
    private bool readyReload = false;                     //是否可以加载新场景
    private int time = 0;                                 //加载新场景缓冲时间

    /**********分数记录**********/
    private Recorder recorder;
    private Text CT_text;
    private Text T_text;
    private int T_Score;
    private int CT_Score;

    private void Start()
    {
        audioSource = gameObject.GetComponents<AudioSource>();
        recorder = gameObject.GetComponent<Recorder>();
        CT_text = GameObject.Find("CT Score").GetComponent<Text>();
        T_text = GameObject.Find("T Score").GetComponent<Text>();

        if (recorder.GetTScore().Equals(null) || recorder.GetCTScore().Equals(null))
        {
            T_Score = 0;
            CT_Score = 0;
        }
        else
        {
            T_Score = int.Parse(recorder.GetTScore());
            CT_Score = int.Parse(recorder.GetCTScore());
            T_text.text = T_Score.ToString();
            CT_text.text = CT_Score.ToString();
        }
        Time.timeScale = 1;
    }


    private void Update()
    {
        recorder.SetScore();
        Reload(readyReload);
    }

    private void FixedUpdate()
    {
        SearchPeople();
        WhoWin();
    }

    private void WhoWin()                                 //判断谁获胜
    {
        if (C_number == 0 && CT_number != 0)
        {
            CT_Score++;
            audioSource[0].Play();
            CT_text.text = CT_Score.ToString();
            readyReload = true;
            Time.timeScale = 0;
        }
        else if (C_number != 0 && CT_number == 0)
        {
            T_Score++;
            audioSource[1].Play();
            T_text.text = T_Score.ToString();
            readyReload = true;
            Time.timeScale = 0;
        }
        else if (C_number == 0 && CT_number == 0)
        {
            readyReload = true;
            Time.timeScale = 0;
        }
        else;

    }

    private void SearchPeople()                                        //看看还有多少人
    {
        Collider[] C = Physics.OverlapSphere(transform.position, 9999, 1 << 8);
        Collider[] CT = Physics.OverlapSphere(transform.position, 9999, 1 << 9);

        C_number = C.Length;
        CT_number = CT.Length;
    }


    public void Reload(bool readyReload)                              //游戏重新开始
    {
        if (readyReload)
        {
            time++;
            if (time >= 200)
            {
                time = 0;
                Application.LoadLevel(SceneManager.GetActiveScene().name);
            }
        }
    }
}