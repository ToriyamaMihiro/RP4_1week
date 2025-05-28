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


    bool isHave = true;//���������Ă��邩�ǂ���

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
        Throw();  //���𓊂���
    }

    void Move()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);//y�����͍���velicity������
            direction = new Vector2(-1, 0);//�l�I�ɍ��������Ă���
            //this.GetComponent<SpriteRenderer>().flipX = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            direction = new Vector2(1, 0);//�l�I�ɉE�������Ă���
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
            isJump = false;//�W�����v
        }
        else
        {
            isJump = true;
        }
    }

    //���ɂ��邩�̔���
    bool isGround()
    {
        int layerMask = 1 << 6 | 1 << 7;
        //�I�u�W�F�N�g�̃��C���[�ɊY������Layer�����Y��Ȃ��悤��
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, layerMask);
        return hit.collider != null;
    }

    //���𓊂���
    void Throw()
    {
        if (Input.GetKey(KeyCode.Z) && isHave)
        {
            //�v���C���[�ɂ��Ă�q�I�u�W�F�N�g��{����setActive��false�ɂ���
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            isHave = false;

            //������p�̗���V�����I�u�W�F�N�g�Ƃ��ČĂяo��
            GameObject eggBullet = Instantiate(eggPrefab, transform.position, Quaternion.identity);

            eggBullet.GetComponent<Rigidbody2D>().velocity = direction * eggSpeed;
        }
    }

}
