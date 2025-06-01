using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private Rigidbody2D rb;

    bool isEggHit;
    bool isHave;

    [SerializeField] EnemyEggCatchAction eggCatch;
    //アニメーション用
    bool isCatch;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Catch();//卵をキャッチする

        animator.SetBool("isCatch", isCatch);//持ってるアニメ
        if (eggCatch.isHave)
        {
            isCatch = true;
        }
        else
        {
            isCatch= false;
        }

    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
      
    }

}
