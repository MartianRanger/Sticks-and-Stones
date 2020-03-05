using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPosition;
    public Transform speechBubbleSpawn;
    public GameObject speechBubble;
    public const int maxHealth = 10;

    public Transform player;
    public float speechBubbleSpeed = 0.25f;
    public int currentHealth = maxHealth;
    public Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private Vector3 GetDirection()
    {
        Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        return startingPosition + randomDirection * Random.Range(10f, 70f);
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

    public void ShootEvent()
    {
        Debug.Log("Shooting");
        GameObject temp = new GameObject();
        temp = Instantiate(speechBubble, speechBubbleSpawn.position, speechBubbleSpawn.rotation);

        temp.GetComponent<Rigidbody>().AddForce(speechBubbleSpawn.forward * speechBubbleSpeed, ForceMode.Impulse);

    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        enemyAnimator.SetInteger("distanceFromPlayer", Mathf.RoundToInt(distance));
    }
}
