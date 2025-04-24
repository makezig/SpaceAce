using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput; // variable for player control
    public float speed = 10.0f; // variable for player speed
    public float xRange = 20; //Allows customizing the size of the boundaries with only one variable
    public GameObject projectilePrefab;
    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false)
        {
            //Leftboundary for the player
            if (transform.position.x <= xRange) // if player position >= xRange
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z); // move player on the x-axis to the value of xRange
            }

            if (transform.position.x >= -xRange) // if player position <= -xRange
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); // move player on the x-axis to the value of -xRange
            }

            horizontalInput = Input.GetAxis("Horizontal"); // Allows changing variables value on unity
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); // moves the player around on x-axis

            if (Input.GetKeyDown(KeyCode.S))
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); // Launch a projectile from the player
            }
        }
    }
}
