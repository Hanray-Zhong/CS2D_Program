using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int C_number;                                 //记录C的剩余人数
    private int CT_number;                                //记录CT的剩余人数
    private AudioSource[] audioSource;
    private Text CT_text;
    private Text T_text;

    public int C_Score = 0;
    public int CT_Score = 0;

    private void Start()
    {
        audioSource = gameObject.GetComponents<AudioSource>();
        CT_text = GameObject.Find("CT Score").GetComponent<Text>();
        T_text = GameObject.Find("T Score").GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        WhoWin();
        SearchPeople();
    }

    private void WhoWin()
    {
        if (C_number == 0 && CT_number != 0)
        {
            CT_Score++;
            Debug.Log("CT win!");
            audioSource[0].Play();
            CT_text.text = CT_Score.ToString();
            Time.timeScale = 0;
        }
        else if (C_number != 0 && CT_number == 0)
        {
            C_Score++;
            Debug.Log("T win!");
            audioSource[1].Play();
            T_text.text = C_Score.ToString();
            Time.timeScale = 0;
        }
        else ;

        
    }

    private void SearchPeople()
    {
        Collider[] C = Physics.OverlapSphere(transform.position, 9999, 1 << 8);
        Collider[] CT = Physics.OverlapSphere(transform.position, 9999, 1 << 9);

        C_number = C.Length;
        CT_number = CT.Length;
    }

}
