using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
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
            transform.Translate(Vector3.back * Time.deltaTime * speed);  //Move object left
        }

        //Destroy object when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
    }
}
