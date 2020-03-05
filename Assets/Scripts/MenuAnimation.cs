using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public GameObject speechBubble;
    public Vector3 spawnValues;
    public GameObject[] speechBubbles;
    public int spawnCounter;
    // Start is called before the first frame update
    void Start()
    {
        for (int spawn = 0;spawn< spawnCounter; spawn++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 1);
            Instantiate(speechBubble, spawnPosition, gameObject.transform.rotation);
            //speechBubbles.Add(bubbleTemp);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
