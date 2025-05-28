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
        Catch();//�����L���b�`����
    }

    void Catch()
    {
        if (isEggHit)
        {
            //�G�ɂ��Ă�q�I�u�W�F�N�g��{����setActive��true�ɂ���
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            isHave = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg" && !isHave)
        {
            isEggHit = true;
            isHave = true;

            //������΂��ꂽ���Ȃ����
            if (collision.gameObject.name == "Egg(Clone)")
            {
                Destroy(collision.gameObject);
            }
        }

    }

}
