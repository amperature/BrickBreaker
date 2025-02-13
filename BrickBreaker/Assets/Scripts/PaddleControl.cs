using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float movementSpeed = 10f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
    
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0);

        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0);
        }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), -4.0f);        
    }
}
