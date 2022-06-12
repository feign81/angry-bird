﻿using System.Collections.Generic;

using UnityEngine;

///<summary>
///
///<summary>

public class BlackBird : Bird
{
    public List<Pig> blocks = new List<Pig>();

    /// <summary>
    /// 进入触发区
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Add(collision.gameObject.GetComponent<Pig>());
        }
    }
    /// <summary>
    /// 离开触发区
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<Pig>());
        }
    }
    public override void Skill()
    {
        base.Skill();
        if (blocks.Count > 0 && blocks != null)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Dead();
            }
        }
        OnClear();
    }
    void OnClear()
    {
        rg.velocity = Vector3.zero;
        Instantiate(boom, transform.position, Quaternion.identity);
        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        myTrail.ClearTrails();
    }
    protected override void Next()
    {
        GameManager1.instance.birds.Remove(this);
        Destroy(gameObject);
        GameManager1.instance.NextBird();

    }
}
