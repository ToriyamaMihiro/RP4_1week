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


    public bool isHave = true;//���������Ă��邩�ǂ���

    bool isJump;
    bool isRight = true;//�E�������Ă��邩
    bool isUp;//��������Ă�


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
        Status(); //���������Ă�Ƃ��Ǝ����ĂȂ��Ƃ��̃X�e�[�^�X�ω�
    }

    void Move()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);

        if (!isUp)
        {

            if (isRight)
            {
                direction = new Vector2(1, 0);//�l�I�ɉE�������Ă���
            }
            else
            {
                direction = new Vector2(-1, 0);//�l�I�ɍ��������Ă���
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);//y�����͍���velicity������
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
            direction = new Vector2(0, 1);//�l�I�ɉE�������Ă���
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
    //�����v���C���[�̑傫����ς��邱�Ƃ�����΂�����eggBullet��Instantiate��ύX����
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
            GameObject eggBullet;
            //������p�̗���V�����I�u�W�F�N�g�Ƃ��ČĂяo��
            if (isRight)
            {
                //�Ăяo�����ʒu���v���C���[�̒��S���ƍ���̂ŁA���炵�Ă�
                eggBullet = Instantiate(eggPrefab, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
            }
            else
            {
                eggBullet = Instantiate(eggPrefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
            }
            eggBullet.GetComponent<Rigidbody2D>().velocity = direction * eggSpeed;
        }
    }

    //�������Ԃ�
    void Catch()
    {

    }

    //���������Ă�Ƃ��Ǝ����ĂȂ��Ƃ��̃X�e�[�^�X�ω�
    void Status()
    {
        if (isHave)//�����Ă�Ƃ�
        {
            moveSpeed = 2.5f;
            jumpPower = 3;
            //eggSpeed = 10;
        }
        else//�����ĂȂ��Ƃ�
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
            //�G�̗���D��
            if (!isHave&& eggCatch.isHave)
            {
                //�v���C���[�ɂ��Ă�q�I�u�W�F�N�g��{����setActive��false�ɂ���
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                isHave = true;
            }
            else //�����Ă�Ƃ��ɓG�̉��ʂ���������
            {
                //�v���C���[�ɂ��Ă�q�I�u�W�F�N�g��{����setActive��false�ɂ���
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                isHave = false;
            }
        }
    }

}
