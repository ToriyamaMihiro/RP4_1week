using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject eggPrefab;

    Vector2 direction = new Vector2(1, 0);


    float moveSpeed = 5f;
    float jumpPower = 7;
    float eggSpeed = 10;


    public bool isHave = true;//卵を持っているかどうか

    bool isJump;
    bool isRight = true;//右を向いているか
    bool isUp;//上を向いてる


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Throw();  //卵を投げる
        Status(); //卵を持ってるときと持ってないときのステータス変化
    }

    void Move()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);

        if (!isUp)
        {

            if (isRight)
            {
                direction = new Vector2(1, 0);//値的に右を向いている
            }
            else
            {
                direction = new Vector2(-1, 0);//値的に左を向いている
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);//y方向は今のvelicityを入れる
            isRight = false;
            //this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            isRight = true;
            //this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new Vector2(0, 1);//値的に右を向いている
            //this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (isGround())
        {
            isJump = false;//ジャンプ
        }
        else
        {
            isJump = true;
        }
    }

    //床にいるかの判定
    bool isGround()
    {
        int layerMask = 1 << 6 | 1 << 7;
        //オブジェクトのレイヤーに該当するLayerをつけ忘れないように
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, layerMask);
        return hit.collider != null;
    }

    //卵を投げる
    //もしプレイヤーの大きさを変えることがあればここのeggBulletのInstantiateを変更する
    void Throw()
    {
        if (Input.GetKey(KeyCode.Z) && isHave)
        {
            //プレイヤーについてる子オブジェクトを捜してsetActiveをfalseにする
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            isHave = false;
            GameObject eggBullet;
            //投げる用の卵を新しいオブジェクトとして呼び出す
            if (isRight)
            {
                //呼び出した位置がプレイヤーの中心だと困るので、ずらしてる
                eggBullet = Instantiate(eggPrefab, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
            }
            else
            {
                eggBullet = Instantiate(eggPrefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
            }
            eggBullet.GetComponent<Rigidbody2D>().velocity = direction * eggSpeed;
        }
    }

    //卵を取り返す
    void Catch()
    {

    }

    //卵を持ってるときと持ってないときのステータス変化
    void Status()
    {
        if (isHave)//持ってるとき
        {
            moveSpeed = 2.5f;
            jumpPower = 3;
            //eggSpeed = 10;
        }
        else//持ってないとき
        {
            moveSpeed = 5f;
            jumpPower = 7;
            //eggSpeed = 10;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyEggCatchAction eggCatch;
        GameObject obj = GameObject.Find("EggCatchCollider");
        eggCatch = obj.GetComponent<EnemyEggCatchAction>();

        if (collision.gameObject.tag == "EggCatch")
        {
            //敵の卵を奪う
            if (!isHave&& eggCatch.isHave)
            {
                //プレイヤーについてる子オブジェクトを捜してsetActiveをfalseにする
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                isHave = true;
            }
            else //持ってるときに敵の下通ったら取られる
            {
                //プレイヤーについてる子オブジェクトを捜してsetActiveをfalseにする
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                isHave = false;
            }
        }
    }

}
