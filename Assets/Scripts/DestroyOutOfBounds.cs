using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Adjust the size of bounds with these
    private float topBound = -30;
    private float bottomBound = -10;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy object if it's out of bounds
        if (transform.position.x < topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound)
        {


            GameManager.Instance.SetGameOver(true);
            
            Debug.Log("Game Over! U SUCC :[");
            Destroy(gameObject);
            

        }
    }
}
