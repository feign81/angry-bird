using UnityEngine;

///<summary>
///
///<summary>

public class GreenBird : Bird
{
    public override void Skill()
    {
        base.Skill();
        Vector3 speed = rg.velocity;
        speed.x *= -1;
        rg.velocity = speed;
    }
}
