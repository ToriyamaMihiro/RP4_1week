using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDead : MonoBehaviour
{
    public float deadTime = 4;
    public float timer = 0;

    //ここに音入れる④

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //殺タイム
        timer += Time.deltaTime;
        if(timer > deadTime)
        {
            Destroy(gameObject);
        }
    }
}
