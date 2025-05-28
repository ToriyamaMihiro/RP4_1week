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


    bool isHave = true;//卵を持っているかどうか

    bool isJump;

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
    }

    void Move()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);//y方向は今のvelicityを入れる
            direction = new Vector2(-1, 0);//値的に左を向いている
            //this.GetComponent<SpriteRenderer>().flipX = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            direction = new Vector2(1, 0);//値的に右を向いている
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

            //投げる用の卵を新しいオブジェクトとして呼び出す
            GameObject eggBullet = Instantiate(eggPrefab, transform.position, Quaternion.identity);

            eggBullet.GetComponent<Rigidbody2D>().velocity = direction * eggSpeed;
        }
    }

}
