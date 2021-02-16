using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int healthCount;
    public int coinCount;

    private Rigidbody2D rb;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vVelocity = jumpForce;
        }

        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);

        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);
    }



        





    public float moveSpeed;
    public float jumpForce;


    public int healthCount;
    public int coinCount;

    public AudioClip[] AudioClipArr;
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource aS;
    public Text HeathTxt;
    public Text CoinTxt;
    [6:16 PM]
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    [6:16 PM]
    void Movement()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
            aS.PlayOneShot(AudioClipArr[1]);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
            aS.PlayOneShot(AudioClipArr[1]);
        }
        else
        {
            animator.SetFloat("xVelocity", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            aS.PlayOneShot(AudioClipArr[3]);
            vVelocity = jumpForce;
            animator.SetTrigger("JumpTrigger");
        }


        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);
        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);
    }
    [6:16 PM]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mace")
        {
            aS.PlayOneShot(AudioClipArr[2]);
            healthCount -= 10;
            HeathTxt.text = "Health: " + healthCount;
        }
        if (collision.gameObject.tag == "Coin")
        {
            aS.PlayOneShot(AudioClipArr[0]);
            coinCount += 1;
            CoinTxt.text = "Coin: " + coinCount;
            Destroy(collision.gameObject);
        }
    }
}
