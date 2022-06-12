using UnityEngine;

///<summary>
///
///<summary>

public class PausePanel : MonoBehaviour
{
    private Animator anim;
    public GameObject button;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Retry()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        anim.SetBool("isPause", true);
        button.SetActive(false);

        if (GameManager1.instance.birds.Count > 0)
        {
            if (GameManager1.instance.birds[0].isReleased == false)
            {
                GameManager1.instance.birds[0].canMove = false;
            }

        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        anim.SetBool("isPause", false);

        if (GameManager1.instance.birds.Count > 0)
        {
            if (GameManager1.instance.birds[0].isReleased == false)
            {
                GameManager1.instance.birds[0].canMove = true;
            }

        }
    }

    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
