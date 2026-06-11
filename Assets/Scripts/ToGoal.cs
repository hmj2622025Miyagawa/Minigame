using UnityEngine;
using UnityEngine.InputSystem;

public class ToGoal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 画面をクリックしたらゲーム画面
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
        }
    }
}
