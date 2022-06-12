using UnityEngine;
using UnityEngine.EventSystems;

///<summary>
///小鸟的拖拽
///<summary>

public class Bird : MonoBehaviour
{

    public float minSpeed = 5;
    public float maxDis = 3;
    public bool isClick;
    public Transform rightPos;
    public Transform leftPos;
    public LineRenderer left;
    public LineRenderer right;
    public GameObject boom;
    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public float smooth = 3;

    public AudioClip select;
    public AudioClip fly;

    private bool isFly;
    public bool isReleased;
    public Sprite hurt;

    public SpringJoint2D sp;
    protected Rigidbody2D rg;
    protected TestMyTrail myTrail;
    protected SpriteRenderer render;
    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        myTrail = GetComponent<TestMyTrail>();
        render = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (canMove)
        {
            AudioPlay(select);
            isClick = true;
            rg.isKinematic = true;
        }
    }
    private void OnMouseUp()
    {
        if (canMove)
        {
            isClick = false;
            rg.isKinematic = false;
            Invoke("Fly", 0.1f);
            canMove = false;
        }

    }
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//跟随鼠标移动
            //transform.position += new Vector3(0, 0, 10);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;//单位向量
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }
            Line();
        }
        //相机跟随
        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(
            Mathf.Clamp(posX - 2, 0, 15), Camera.main.transform.position.y, Camera.main.transform.position.z)
            , smooth * Time.deltaTime);

        if (isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Skill();
            }
        }
    }
    private void Fly()
    {
        isReleased = true;
        isFly = true;
        AudioPlay(fly);
        sp.enabled = false;
        Invoke("Next", 5);
        right.enabled = false;
        left.enabled = false;
        myTrail.StartTrailks();
    }

    /// <summary>
    /// 划线
    /// </summary>
    private void Line()
    {
        right.enabled = true;
        left.enabled = true;
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

    //下一只小鸟
    protected virtual void Next()
    {
        GameManager1.instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager1.instance.NextBird();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFly = false;
        myTrail.ClearTrails();
        if (collision.relativeVelocity.magnitude >= minSpeed)
        {
            render.sprite = hurt;
        }

    }
    //音效
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    //小鸟的技能
    public virtual void Skill()
    {
        isFly = false;
    }


}
