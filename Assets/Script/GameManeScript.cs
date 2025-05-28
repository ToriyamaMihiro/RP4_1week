using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // FPSを設定(1秒 = 60fps)
        Application.targetFrameRate = 60;
        //ウィンドウサイズ
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
