using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEggCatchAction : MonoBehaviour
{
    // Start is called before the first frame update
    bool isEggHit;
    public bool isHave;

    
    [SerializeField] GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //判定が別なので、スクリプトをEnemyと分ける
        EggHave();//卵をキャッチする
    }

    void EggHave()
    {
        

        if (isHave)
        {
            //見かけ上の卵のsetActiveをtrueにする
            egg.SetActive(true);
           
        }

        else
        {
            egg.SetActive(false);
           
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        //もし飛ばされた卵かつ卵を持っていなかったら
        //飛ばされた卵を消して卵を持つ
        if (collision.gameObject.name == "Egg(Clone)" && !isHave)
        {
            Destroy(collision.gameObject);
            isHave = true;

            //敵が卵をキャッチしたSE再生
            //敵が卵を持ってるリソースに変更
        }
    }
}
