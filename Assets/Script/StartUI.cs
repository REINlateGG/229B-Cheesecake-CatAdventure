using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public GameObject tutorial;

    public void StartGame()
    {
        // โหลดซีนเกมหลัก (เปลี่ยนชื่อซีนตามของคุณ)
        SceneManager.LoadScene("PlayScenes");
    }

    public void Exit()
    {
        // ออกจากเกม (จะทำงานเมื่อ build เป็น .exe เท่านั้น)
        Application.Quit();

        // สำหรับตอนทดสอบใน Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void ShowTutorial()
    {
        tutorial.SetActive(true);
    }

    // เรียกเมื่อกดปุ่มปิด Tutorial
    public void HideTutorial()
    {
        tutorial.SetActive(false);
    }
}
