using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    public Slider healthSlider; // ลาก UI Slider มาผูก
    // หรือจะใช้ Text ก็ได้ เช่น public Text healthText;

    void Start()
    {
        currentHP = maxHP;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHP / maxHP;
        }
    }

    void Die()
    {
        Debug.Log("Player Died");
        // เพิ่มการตาย เช่น จบเกม โหลดซีนใหม่ ฯลฯ
    }
}
