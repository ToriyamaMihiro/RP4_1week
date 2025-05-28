using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAction : MonoBehaviour
{

    bool isBreak;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Break();
    }

    void Break()
    {
        if (isBreak)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isBreak = true;
        }
    }
}
