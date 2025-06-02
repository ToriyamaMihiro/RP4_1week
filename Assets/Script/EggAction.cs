using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EggAction : MonoBehaviour
{

    bool isBreak;
    public GameObject particleA;
    public GameObject particleB;

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
            isBreak = false;
            Instantiate(particleA, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            Instantiate(particleB, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
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
