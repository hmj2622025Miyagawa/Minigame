using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController3 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField] float jumpForce = 600f;
    [SerializeField] float walkForce = 30f;
    [SerializeField] float maxWalkSpeed = 2.0f;
    [SerializeField] AudioClip birdSE;
    [SerializeField] Sprite[] jumpSprites1;
    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;

    public Transform startPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<AudioSource>().clip = birdSE;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (this.rigid2D.linearVelocityX < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * walkForce);
        }

        // アニメーション
        this.time += Time.deltaTime;
        if (this.time > 0.1)
        {
            this.time = 0;
            this.spriteRenderer.sprite = this.jumpSprites1[this.idx];
            this.idx = 1 - this.idx;
        }

        // 画面外に出た場合は最初から

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        if (transform.position.y > 5)
        {
            SceneManager.LoadScene("GameScene");
        }
        if (transform.position.x > 10)
        {
            SceneManager.LoadScene("GameScene");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Debug.Log("ゴール");
            SceneManager.LoadScene("ClearScene");
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        SceneManager.LoadScene("TitleScene");
    }
}
