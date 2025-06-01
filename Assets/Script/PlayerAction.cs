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

    int eggMoveTimer;

    public bool isHave = true;//卵を持っているかどうか

    bool isJump;
    bool isRight = true;//右を向いているか
    bool isUp;//上を向いてる
    public bool isEggMove;

    //アニメーション切り替え用
    public float nowSpeed;//判定用のスピード
    public bool isJumpAnime;//ジャンプ
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
        Move();
        Jump();
        Throw();  //卵を投げる
        Status(); //卵を持ってるときと持ってないときのステータス変化
        EggHaveManager();
        EggMoveManager();
    }

    void Move()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);

        //アニメーターセット
        animator.SetFloat("Speed", nowSpeed);//移動アニメ
        nowSpeed = 0;//ボタン押してないとき止まる

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
            nowSpeed = moveSpeed;//アニメのスピードに今のスピードを入れる
            transform.rotation = Quaternion.Euler(0, 180, 0);//見た目を左向かせる
        }
       

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            isRight = true;
            //this.GetComponent<SpriteRenderer>().flipX = false;
            nowSpeed = moveSpeed;//アニメのスピードに今のスピードを入れる
            transform.rotation = Quaternion.Euler(0, 0, 0);//見た目を右向かせる
        }
        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new Vector2(0, 1);//値的に右を向いている
            //this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Jump()
    {
        animator.SetBool("isJump", isJumpAnime);//ジャンプアニメに変更

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (isGround())
        {
            isJump = false;//ジャンプ
            isJumpAnime = false;
        }
        else
        {
            isJump = true;
            isJumpAnime=true;
        }
    }

    //床にいるかの判定
    bool isGround()
    {
        //左右真ん中からrayを飛ばしてジャンプできるかの判定をとる
        int layerMask = 1 << 6 | 1 << 7;
        float rayLength = 0.6f;
        float offset = 0.5f; // 横にずらす距離

        Vector2 center = transform.position;
        Vector2 left = center + Vector2.left * offset;
        Vector2 right = center + Vector2.right * offset;

        RaycastHit2D hitCenter = Physics2D.Raycast(center, Vector2.down, rayLength, layerMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(left, Vector2.down, rayLength, layerMask);
        RaycastHit2D hitRight = Physics2D.Raycast(right, Vector2.down, rayLength, layerMask);

        Debug.DrawRay(center, Vector2.down * rayLength, Color.red);
        Debug.DrawRay(left, Vector2.down * rayLength, Color.green);
        Debug.DrawRay(right, Vector2.down * rayLength, Color.blue);

        return hitCenter.collider != null || hitLeft.collider != null || hitRight.collider != null;
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

            //卵を投げるSE再生


        }
    }

    //卵移動のクールタイム
    void EggMoveManager()
    {
        //もし卵が移動したら
        if (isEggMove)
        {
            //卵が次に移動できるまでのクールタイムを溜める
            eggMoveTimer++;
            if (eggMoveTimer >= 5)
            {
                isEggMove = false;
                eggMoveTimer = 0;
            }
        }
    }

    //見かけ上(SetActive)卵を持っているか
    void EggHaveManager()
    {
        //卵を持っている
        if (isHave)
        {
            //プレイヤーについてる子オブジェクトを捜してsetActiveをfalseにする
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else //持ってない
        {
            //プレイヤーについてる子オブジェクトを捜してsetActiveをfalseにする
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
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
        //敵のキャッチ範囲かつ、卵を持っているかつ卵の移動が可能なら
        //敵に卵を取られる
        if (collision.gameObject.tag == "EggCatch" && isHave && !isEggMove)
        {
            isHave = false;
            collision.gameObject.GetComponent<EnemyEggCatchAction>().isHave = true;
            isEggMove = true;

            //卵を取られたSE再生
            //プレイヤーが卵を持ってないリソースに変更
            //敵が卵を持ってるリソースに変更
        }

        //飛ばした卵が敵にキャッチされる処理はEnemyEggCatchAction.csにあるので
        //敵が卵をキャッチしたときに何かするときはEnemyEggCatchAction.csにも書く

        //敵の下にある卵を取る処理はEnemyEggTakeAction.csにある
    }

}
