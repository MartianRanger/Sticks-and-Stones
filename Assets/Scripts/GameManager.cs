using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public GameObject player;
    public Text gameOverText;
    public Text failText;
    public GameObject enemy;
    public GameObject token;
    public Transform tokenSpawn;
    public Camera failCam;
    public Camera winCam;
    public Canvas failCanvas;
    private bool gameOver;
    public static GameManager instance = null;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //gameOverText.text = "Game Started";

        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //gameOverText.text = " ";
        failCam.enabled = false;
        token = Instantiate(token, tokenSpawn.position, tokenSpawn.rotation);
        gameOver = false;
        //failCanvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            playerLose();
        }

        if (enemy == null)
        {
            playerWin();
        }
        Debug.Log(gameOver);
    }
    private void playerWin()
    {
        Debug.Log("YOU WON!");
        gameOverText.text = "YOU WIN!";
        //SceneManager.LoadScene("Main");
        //failCanvas.gameObject.SetActive(true);
        gameOver = true;
        StartCoroutine("waitAndLoad", 5.0f);
        //Invoke("waitAndLoad", 1);
    }
    private void playerLose()
    {
        //failCanvas.gameObject.SetActive(true);

        Debug.Log("YOU LOSE!");
        failText.text = "YOU LOSE!";
        //GameObject.Destroy(player);
        GameObject.Destroy(enemy);
	    failCam.enabled = true;
        //winCam.enabled = false;
        gameOver = true;
        StartCoroutine("waitAndLoad", 5.0f);
        //Invoke("waitAndLoad", 1);

    }

    IEnumerator waitAndLoad()
    {
        yield return new WaitForSeconds(5f); //wait for load to happen

        SceneManager.LoadScene("VRMain"); //load scene


        //yield return new WaitForSeconds(.02f); //wait for load to happen

        //Get references
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameOverText.text = " ";
        gameOver = false;
        failCam.enabled = false;
        token = Instantiate(token, tokenSpawn.position, tokenSpawn.rotation);

    }
}

