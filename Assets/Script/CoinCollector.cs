using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0;
    public int coinGoal = 10;

    public TextMeshProUGUI coinText; // ผูกกับ Text UI

    void Start()
    {
        UpdateCoinUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
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
