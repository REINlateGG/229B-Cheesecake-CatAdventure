using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP player = collision.gameObject.GetComponent<PlayerHP>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
