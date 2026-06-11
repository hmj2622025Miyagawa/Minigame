using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField]float jumpForce = 600f;
    [SerializeField]float walkForce = 30f;
    [SerializeField]float maxWalkSpeed = 2.0f;

    public Transform startPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        if (this.rigid2D.linearVelocityX < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * walkForce);
        }

        // âÊñ äOÇ…èoÇΩèÍçáÇÕç≈èâÇ©ÇÁ

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
            Debug.Log("ÉSÅ[Éã");
            SceneManager.LoadScene("ClearScene");
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
