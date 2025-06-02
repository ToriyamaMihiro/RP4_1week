using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanChangeAction : MonoBehaviour
{
    float speed = 13f;

    Vector2 startPosition = new Vector2(-22.4f, 0);
    Vector2 endPosition = new Vector2(0, 0);


    public bool isStart;

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

        if (isStart)
        {
            //�����l�p���ړ�������
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            Invoke("StartMoveEnd", 1.8f);
        }

        //�S�[��������
        if (player.isGoal)
        {
            //�����l�p���ړ�������
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
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
    void StartMoveEnd()
    {
        isStart = false;
    }
}
