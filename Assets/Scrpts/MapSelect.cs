using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///<summary>

public class MapSelect : MonoBehaviour
{
    public int starNum = 0;
    private bool isSelect;

    public GameObject locks;
    public GameObject stars;
    public GameObject panel;
    public GameObject map;


    public Text starsText;
    public int startNum = 1;
    public int endNum = 5;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("totalNum", 0) >= starNum)
        {
            isSelect = true;
        }
        if (isSelect)
        {
            locks.SetActive(false);
            stars.SetActive(true);

            int counts = 0;
            for (int i = startNum; i <= endNum; i++)
            {
                counts += PlayerPrefs.GetInt("level" + i.ToString(), 0);
            }
            starsText.text = counts.ToString() + "/" + ((endNum - startNum + 1) * 3).ToString();
        }
    }
    public void Selected()
    {
        if (isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }
    public void panelSelected()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
    public void clear()
    {
        PlayerPrefs.DeleteAll();
    }

}
