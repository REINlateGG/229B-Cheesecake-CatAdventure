using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 3;
    public int damage = 1;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Enemy HP: " + HP);

        if (HP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy defeated!");
        }
    }

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
