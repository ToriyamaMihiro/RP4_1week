using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanChangeAction : MonoBehaviour
{
    float speed = 12f;
    Vector2 target = new Vector2(0,0);

    bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {

        GoalManager player;
        GameObject obj = GameObject.Find("Goal");
        player = obj.GetComponent<GoalManager>();



        //�S�[��������
        if (player.isGoal)
        {
            //�����l�p���ړ�������
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //2�b��ɃV�[���ړ�
            Invoke("SceanLoad", 1.8f);

        }
    }

    void SceanLoad()
    {
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        //�V�[���J��
        nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }
}
