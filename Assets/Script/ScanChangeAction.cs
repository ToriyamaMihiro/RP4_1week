using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanChangeAction : MonoBehaviour
{
    float speed = 13f;

    Vector2 startPosition = new Vector2(-22.4f, 0);
    Vector2 endPosition = new Vector2(0, 0);
    Vector2 cameraPos;

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
            //黒い四角を移動させる
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            Invoke("StartMoveEnd", 1.8f);
        }

        //ゴールしたら
        if (player.isGoal)
        {
            cameraPos = transform.parent.position;

            //黒い四角を移動させる
            transform.position = Vector3.MoveTowards(transform.position, endPosition + cameraPos, speed * Time.deltaTime);
            //2秒後にシーン移動
            Invoke("SceanLoad", 1.8f);

        }
    }

    void SceanLoad()
    {
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().name == "Stage5")
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            //シーン遷移
            nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(++nowSceneIndexNumber);
        }

    }
    void StartMoveEnd()
    {
        isStart = false;
    }
}
