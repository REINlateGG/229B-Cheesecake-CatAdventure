using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;
    public AudioClip gameOverSound;
    public Image fadeImage;
    public float fadeDuration = 1.5f;
    public AudioClip damageSound;
    private AudioSource audioSource;

    public Slider healthSlider; // ลาก UI Slider มาผูก
    // หรือจะใช้ Text ก็ได้ เช่น public Text healthText;
    

    void Start()
    {
        currentHP = maxHP;
        UpdateUI();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        audioSource.PlayOneShot(damageSound);
        if (currentHP <= 0)
        {
            currentHP = 0;
            audioSource.PlayOneShot(gameOverSound);
            Debug.Log("Player Died");
            StartCoroutine(GameOver());
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


    IEnumerator GameOver()
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            fadeImage.color = new Color(color.r, color.g, color.b, Mathf.Lerp(0f, 1f, t));
            time += Time.deltaTime;
            yield return null;
        }

        // fully faded to black
        fadeImage.color = new Color(color.r, color.g, color.b, 1f);

        // โหลด scene ถัดไป
        SceneManager.LoadScene("GameOver");
    }
}
