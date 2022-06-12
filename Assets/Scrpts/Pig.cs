using UnityEngine;

///<summary>
///
///<summary>

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;
    public bool isPig;

    public AudioClip hurtCollision;
    public AudioClip dead;
    public AudioClip birdCollision;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.relativeVelocity.magnitude);
        if (collision.gameObject.tag == "player")
        {
            AudioPlay(birdCollision);

        }
        if (collision.relativeVelocity.magnitude >= maxSpeed)
        {
            render.sprite = hurt;
            Invoke("Dead", 2);
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            AudioPlay(hurtCollision);
            render.sprite = hurt;
        }
    }
    public void Dead()
    {
        if (isPig)
        {
            GameManager1.instance.pigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
        Destroy(go, 1.5f);
        AudioPlay(dead);
    }
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
