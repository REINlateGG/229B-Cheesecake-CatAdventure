using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        // โหลดซีนเกมหลัก (เปลี่ยนชื่อซีนตามของคุณ)
        SceneManager.LoadScene("PlayScenes");
    }

    public void ExitGame()
    {
        // ออกจากเกม (จะทำงานเมื่อ build เป็น .exe เท่านั้น)
        Application.Quit();

        // สำหรับตอนทดสอบใน Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
