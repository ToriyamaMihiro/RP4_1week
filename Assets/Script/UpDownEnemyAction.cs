using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownEnemyAction : MonoBehaviour
{
    private Rigidbody2D rb;
    float moveSpeed = 2;

    int direction = 1;
    int judgeCoolTime;//�A���Ŕ�����Ƃ�Ȃ��悤�ɂ��邽�߂̃^�C�}�[

    bool isDirectionChange;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpDownJudge();
    }

    void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed * direction);
    }

    void UpDownJudge()
    {
        //�ǂɓ��������������]������
        if (isWallHit() && !isDirectionChange)
        {
            direction *= -1;
            isDirectionChange = true;
        }

        //���ɕ����]�����ł���܂ł̃N�[���^�C��
        if (isDirectionChange)
        {
            judgeCoolTime++;
            if (judgeCoolTime == 30)
            {
                isDirectionChange = false;
                judgeCoolTime = 0;
            }
        }
    }

    //�ǂɓ���������
    bool isWallHit()
    {
        //�㉺����ray���΂��ĕ����]�����邩�̔�����Ƃ�
        int layerMask = 1 << 6;
        float rayLength = 0.6f;

        Vector2 up = transform.position;
        Vector2 down = transform.position;

        RaycastHit2D hitUp = Physics2D.Raycast(up, Vector2.up, rayLength, layerMask);
        RaycastHit2D hitDown = Physics2D.Raycast(down, Vector2.down, rayLength, layerMask);

        Debug.DrawRay(up, Vector2.up * rayLength, Color.red);
        Debug.DrawRay(down, Vector2.down * rayLength, Color.red);


        return hitUp.collider != null || hitDown.collider != null;
    }
}
