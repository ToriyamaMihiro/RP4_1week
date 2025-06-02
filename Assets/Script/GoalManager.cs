using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    bool isEggGoal;//������ɃS�[�����Ă��邩

    bool isCloneEggBreak;//�e�̗�����������

    public bool isGoal;//�S�[��������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        //�v���C���[�Ɨ��������ɃS�[��������
        if (collision.gameObject.tag == "Player" && player.isHave)
        {
            isGoal = true;

        }

        //������ɃS�[�����ăv���C���[���ォ��S�[��������
        if (collision.gameObject.name == "Egg(Clone)" && !player.isHave || isEggGoal)
        {
            if (!isCloneEggBreak)
            {
                Destroy(collision.gameObject);
                isCloneEggBreak = true;
            }
            isEggGoal = true;
            //������ɓ����Ă��郊�\�[�X�ɐ؂�ւ���

            if (collision.gameObject.tag == "Player")
            {
                isGoal = true;
            }
        }
    }

}
