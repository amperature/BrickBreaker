using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Start is called once before the first execution of Update after the MonoBehaviour is created

    GameObject Paddle;
    private float ballSpeed = 5f;
    private Vector2 dir;
    private Vector3 reset;        
    public AudioSource _source;
    [SerializeField] private AudioClip paddleHit;
    [SerializeField] private AudioClip brickHit;
    [SerializeField] private AudioClip borderHit;
    
    void Start()
    {
        dir = new Vector2(Random.value, Random.value);
        Debug.Log(dir);
        Paddle = GameObject.Find("Paddle");
        //reset = new Vector3(0f, 0f);
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    
    {
        transform.position += new Vector3 (dir.x * ballSpeed * Time.deltaTime, dir.y * ballSpeed * Time.deltaTime, 0);
        /*
        if (transform.position.x > 10.4f && Mathf.Sign(dir.x) == 1) {
            dir.x = -(dir.x);           
        }

        if (transform.position.x < -10.4f && Mathf.Sign(dir.x) == -1) {
            dir.x = -(dir.x);
        }
        
        if (transform.position.y > 4.2f && Mathf.Sign(dir.y) == 1) {
            dir.y = -(dir.y);
        }
        
        if (transform.position.x == Paddle.transform.position.x) {
            dir.x = -(dir.x);
        }
        if (transform.position.y == Paddle.transform.position.y) {
            dir.y = -(dir.y);
        }

        */

        // condition a: is it between the edges of the ball
        if (transform.position.y < -5f) {
            transform.position = new Vector3(0, 0);
        }
        //if (transform.position.x >= Paddle.transform.position.x - 1 && transform.position.x <= Paddle.transform.position.x + 1 && transform.position.y - 0.2f <= Paddle.transform.position.y + 0.25f) {
        //    dir.y = -(dir.y);

        //}
    }
    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("yeah this totally collided");
        if (collision.gameObject.CompareTag("leftborder") || collision.gameObject.CompareTag("rightborder") ) {
            dir.x = -(dir.x);
            _source.clip = borderHit;
            _source.Play();        
        }
        //if (collision.gameObject.CompareTag("rightborder")) {
        //    dir.x = -(dir.x);
        //}
        if (collision.gameObject.CompareTag("topborder")) {
            dir.y = -(dir.y);
            _source.clip = borderHit;
            _source.Play();
        }
        if (collision.gameObject.CompareTag("paddle")) {
            dir.y = -(dir.y);
            _source.clip = paddleHit;
            _source.Play();        
        }
        if (collision.gameObject.CompareTag("brick")) {
            _source.clip = brickHit;
            _source.Play();        
        }

        
    }

}
