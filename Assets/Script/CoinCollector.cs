using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0;
    public int coinGoal = 10;

    public AudioClip CoinSound;
    private AudioSource audioSource;

    public TextMeshProUGUI coinText;

    void Start()
    {
        UpdateCoinUI();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            audioSource.PlayOneShot(CoinSound);
            Destroy(other.gameObject);
            UpdateCoinUI();
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount + "/" + coinGoal;
    }

    public bool HasEnoughCoins()
    {
        return coinCount >= coinGoal;
    }
}
