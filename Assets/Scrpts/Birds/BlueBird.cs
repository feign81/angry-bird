using UnityEngine;

///<summary>
///
///<summary>

public class BlueBird : Bird
{
    public GameObject blueBird;
    public override void Skill()
    {
        base.Skill();
        GameObject blue1 = Instantiate(blueBird, transform.position, Quaternion.Euler(new Vector3(0, 30, 0)));
        GameObject blue2 = Instantiate(blueBird, transform.position, Quaternion.Euler(new Vector3(0, -30, 0)));


        Destroy(blue1, 5);
        Destroy(blue2, 5);

    }
}
