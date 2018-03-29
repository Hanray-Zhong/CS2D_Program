using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabsClearer : MonoBehaviour {
    Recorder recorder;

    private void Start()
    {
        recorder = gameObject.GetComponent<Recorder>();
    }

    public void ClearPrefabs()
    {
        recorder.ClearAllPrefs();
    }

}
