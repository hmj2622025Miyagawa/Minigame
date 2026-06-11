using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public GameObject WallPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("CreateWall", 1f, 3f);

    }

    // •Ç¶¬‚ÌŠÖ”
    void CreateWall()
    {
        // ˆÊ’u‚ğŒˆ‚ß‚é
        float randomY = Random.Range(-3f, 3f);
        Vector3 wallpos = new Vector3(5f, randomY, 0f);

        // ƒ‰ƒ“ƒ_ƒ€‚È‚‚³‚Å¶¬
        Instantiate(WallPrefab, wallpos, Quaternion.identity);
    }

}
