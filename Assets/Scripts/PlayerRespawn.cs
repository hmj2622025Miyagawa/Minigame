using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    private Vector3 respawnPoint;
    private PlayerController playerController;
    private Rigidbody2D rb2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ゲーム開始地点をリス地として記憶
        respawnPoint = transform.position;

        playerController = GetComponent<PlayerController>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        transform.position = respawnPoint;

        if (rb2D != null)
        {
            rb2D.linearVelocity = Vector3.zero;
            rb2D.angularVelocity = 0f;
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
}
