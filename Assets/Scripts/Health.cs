using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public Slider healthBar;
    void Start()
    {
        healthBar.value = currentHealth;
    }
    void Update()
    {
        healthBar.value = currentHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Current Health:" + currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            Debug.Log("Dead!");
        }
    }
}
