using UnityEngine;

public class WallController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // ¶‚ÉˆÚ“®
        transform.position += Vector3.left * 2f * Time.deltaTime;

        // ‰æ–ÊŠO‚Éo‚½‚çíœ
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
