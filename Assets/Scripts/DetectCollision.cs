using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int scoreValue = 10; // How many points this object gives
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) // Destroying gameobjects when they collide
    {

        Debug.Log("heh");
        GameManager.Instance.AddPoints(scoreValue); // Add points to score
        Destroy(gameObject);
        Destroy(other.gameObject);
        
        


    }
}
