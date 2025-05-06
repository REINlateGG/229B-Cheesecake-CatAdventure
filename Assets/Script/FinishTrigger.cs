using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FinishTrigger : MonoBehaviour
{
    public GameObject notEnoughCoinText;
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollector coinCollector = other.GetComponent<CoinCollector>();
            if (coinCollector != null && coinCollector.HasEnoughCoins())
            {
                Debug.Log("You Win!");
                StartCoroutine(WinSequence());
            }
            else
            {
                Debug.Log("Not enough coins!");
                StartCoroutine(ShowNotEnoughCoins());
            }
        }
    }

    IEnumerator ShowNotEnoughCoins()
    {
        notEnoughCoinText.SetActive(true);
        yield return new WaitForSeconds(5f);
        notEnoughCoinText.SetActive(false);
    }

    IEnumerator WinSequence()
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
        SceneManager.LoadScene("WinandCredit");
    }
}
