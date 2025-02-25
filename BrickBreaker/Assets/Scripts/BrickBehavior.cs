using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("yeah this collided");
        if (collision.gameObject.CompareTag("ball")) {
            Destroy(gameObject);
        }
    }
    
}
