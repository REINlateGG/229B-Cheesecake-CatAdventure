using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

     private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy"))
        {
            Enemy enemy = collider2D.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }


}
