using UnityEngine;

public class RepeateBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeateWidth;

    
    void Start()
    {
        startPos = transform.position;
        repeateWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    
    void Update()
    {
        //Makes the background repeat
        if (transform.position.z < startPos.z - repeateWidth)
        { transform.position= startPos; }
    }
}
