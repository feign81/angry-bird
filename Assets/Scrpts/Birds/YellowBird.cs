///<summary>
///重写方法
///<summary>

public class YellowBird : Bird
{
    public override void Skill()
    {
        base.Skill();
        rg.velocity *= 2;
    }

}
