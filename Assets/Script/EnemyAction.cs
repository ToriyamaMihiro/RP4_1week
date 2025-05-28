using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private Rigidbody2D rb;

    bool isEggHit;
    bool isHave;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Catch();//—‘‚ðƒLƒƒƒbƒ`‚·‚é
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
      
    }

}
