using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollector coinCollector = other.GetComponent<CoinCollector>();
            if (coinCollector != null && coinCollector.HasEnoughCoins())
            {
                Debug.Log("You Win!");
                // แสดง UI ชนะ หรือไปฉากถัดไป
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
    }
}
