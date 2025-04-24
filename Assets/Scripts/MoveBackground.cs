using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 30;
    
    private float leftBound = -15;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector3.back * Time.deltaTime * speed);  //Move object left

        //Destroy object when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
    }
}
