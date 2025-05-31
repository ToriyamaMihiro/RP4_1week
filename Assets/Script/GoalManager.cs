using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    bool isEggGoal;//������ɃS�[�����Ă��邩

    bool isCloneEggBreak;//�e�̗�����������

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

        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        //�v���C���[�Ɨ��������ɃS�[��������
        if (collision.gameObject.tag == "Player" && player.isHave)
        {
            //�V�[���J��
            nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene("TestPlayer");

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
                //�V�[���J��
                nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

                SceneManager.LoadScene("GameScene");
            }
        }
    }

}
