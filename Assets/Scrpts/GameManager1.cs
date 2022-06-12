using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///
///<summary>

public class GameManager1 : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManager1 instance;
    private Vector3 originPos;

    public GameObject lose;
    public GameObject win;

    public GameObject[] stars;
    private int starsNum = 0;
    private int totalNum = 10;
    public GameObject hide;
    private void Awake()
    {
        instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
    }
    private void Start()
    {
        Initialized();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
                birds[i].canMove = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
                birds[i].canMove = false;
            }
        }
    }
    public void NextBird()
    {

        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只鸟
                Initialized();
            }
            else
            {
                //输了
                lose.SetActive(true);
            }
        }
        else
        {
            //赢了
            win.SetActive(true);
        }
    }


    public void ShowStarts()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for (; starsNum < birds.Count + 1; starsNum++)
        {
            if (starsNum >= stars.Length) { break; }
            yield return new WaitForSeconds(0.2f);
            stars[starsNum].SetActive(true);

        }
        print(starsNum);
    }
    /// <summary>
    /// 重新开始游戏
    /// </summary>
    public void Replay()
    {
        SaveData();
        SceneManager.LoadScene(2);
    }
    public void Home()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        if (starsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starsNum);
        }
        int sum = 0;
        for (int i = 0; i < totalNum; i++)
        {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalNum", sum);
    }
    public void Hide()
    {
        hide.SetActive(true);
    }
}
