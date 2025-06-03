using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDead : MonoBehaviour
{
    public float deadTime = 4;
    public float timer = 0;

    //ここに音入れる④
    private AudioSource audioSource;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //音なるよ
        audioSource.PlayOneShot(sound);
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
