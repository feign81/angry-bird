using UnityEngine;

///<summary>
///
///<summary>

public class Loadlevel : MonoBehaviour
{
    private void Awake()
    {
        Instantiate(Resources.Load(PlayerPrefs.GetString("nowLevel")));
    }
}
