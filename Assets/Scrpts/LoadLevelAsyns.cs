using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///
///<summary>

public class LoadLevelAsyns : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1600, 900, false);
        Invoke("Load", 4);
    }
    void Load()
    {
        SceneManager.LoadScene(1);
    }
}
