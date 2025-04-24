using UnityEngine;

public class FoodForward : MonoBehaviour
{
    public float speed = 40.0f; // adjust foods speed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); // move food forward
    }
}
