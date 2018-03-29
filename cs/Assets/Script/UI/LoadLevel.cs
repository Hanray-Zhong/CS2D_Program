using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    public void loadLevel(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}
