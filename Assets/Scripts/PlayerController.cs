using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;


    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    private Vector3 _movement;
    public Rigidbody player;
    public float rotateSpeed = 30f;
    public float movementSpeed = 10f;
    public Transform speechBubbleSpawn;
    public Transform bombSpawn;
    public GameObject speechPrefab;
    private GameObject temp;
    private bool speechBubble = true;
    private float chargeTimer = 0;
    private SpeechBubble speech;
    Vector3 direction;
    float bulletSpeed = 20f;
    public Slider audioSlider;
    public float rotX;
    public float rotY;
    public Camera cam;
    public GameObject bomb;
    public GameObject bombPrefab;
    private float bombForce = 5000.0f;
    private Vector3 moveDirection;
    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            /*bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
            bomb.GetComponent<Rigidbody>().useGravity = true;
            bomb.GetComponent<Rigidbody>().AddForce(bombSpawn.forward * bombForce);
            Debug.Log(Vector3.forward);
            Debug.Log(bomb.GetComponent<Rigidbody>().velocity);
            speechBubble = true;*/
        }
        if (Input.GetKeyDown(KeyCode.Space) && speechBubble == true)
        {
            temp = Instantiate(speechPrefab, speechBubbleSpawn.position, speechBubbleSpawn.rotation);
            temp.transform.parent = transform;
            audioSlider.direction = Slider.Direction.LeftToRight;
            audioSlider.minValue = 0;
            audioSlider.maxValue = temp.GetComponent<AudioSource>().clip.length;
            audioSlider.value = temp.GetComponent<AudioSource>().time;
            Debug.Log("Why");
        }
        if (Input.GetKeyUp(KeyCode.Space) && temp.GetComponent<AudioSource>().isPlaying)
        {
            audioSlider.value = 0;
            temp.GetComponent<AudioSource>().Stop();
            temp.transform.parent = null;
            Destroy(temp);
            chargeTimer = 0;
            Debug.Log("Temp Destroyed");
        }
        if (Input.GetKeyUp(KeyCode.Space) && !temp.GetComponent<AudioSource>().isPlaying)
        {
            temp.transform.parent = null;
            audioSlider.value = temp.GetComponent<AudioSource>().time;
            Debug.Log("DIDI" + " " + temp.GetComponent<Rigidbody>().velocity);

            temp.GetComponent<AudioSource>().Stop();
            temp.transform.parent = null;
        }
        cam = Camera.main;
        /*rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        if (rotX < -90)
        {
            rotX = -90;
        }
        else if (rotX > 90)
        {
            rotX = 90;
        }
        transform.rotation = Quaternion.Euler(0, rotY, 0);
        speechBubbleSpawn.rotation = Quaternion.Euler(0, rotY, 0);
        direction = Input.mousePosition;
        direction.z = 0.0f;
        direction = Camera.main.ScreenToWorldPoint(direction);
        direction = direction - transform.position;*/
        //transform.rotation = Quaternion.Euler(transform.rotation.x, cam.GetComponent<CamMouseLook>().currentYRotation, transform.rotation.z);
        //Debug.Log(cam.GetComponent<CamMouseLook>().currentYRotation + "    " + speechBubbleSpawn.rotation);
        //speechBubbleSpawn.rotation = Quaternion.Euler(0, cam.GetComponent<CamMouseLook>().currentYRotation, 0);
        //bombSpawn.rotation = Quaternion.Euler(cam.GetComponent<CamMouseLook>().currentXRotation, cam.GetComponent<CamMouseLook>().currentYRotation, 0);
        /*
        float translation = -Input.GetAxis("Vertical") * movementSpeed;
        float straffe = -Input.GetAxis("Horizontal") * movementSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
        */
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0, verticalMovement);

    }
    void fixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 yVelFix = new Vector3(0, player.velocity.y, 0);
        player.velocity += yVelFix;
    }
    IEnumerator StartTalking(GameObject temp)
    {
        temp.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Sohinki");

            temp.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

            //speechBubble = false;
        }
        yield return null;
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "platform")
        {
            transform.parent = collider.transform;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "SpeechBubble")
        {
            speechBubble = false;

        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "platform")
        {
            transform.parent = null;

        }
    }

    // Update is called once per frame
    /*private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        _movement = (vertical * transform.forward) + (horizontal * transform.right);
        _movement = _movement.normalized * speed * Time.deltaTime;
        player.MovePosition(transform.position + _movement);
    }*/
}
