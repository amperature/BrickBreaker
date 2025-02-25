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
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play) {
            transform.position += new Vector3 (dir.x * ballSpeed * Time.deltaTime, dir.y * ballSpeed * Time.deltaTime, 0);
            if (transform.position.y < -5f) {
                ResetBall();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("yeah this totally collided");
        float xDistance = transform.position.x - collision.transform.position.x;
        float yDistance = transform.position.y - collision.transform.position.y;

        if (collision.gameObject.CompareTag("leftborder") || collision.gameObject.CompareTag("rightborder") ) {
            dir.x = -(dir.x);
            _source.clip = borderHit;
            _source.Play();        
        }
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
            if (xDistance > yDistance) {
                dir.y = -(dir.y);
            }
            if (yDistance > xDistance) {
                dir.x = (-dir.y);
            }
            _source.clip = brickHit;
            _source.Play(); 

        }

        
    }

    void ResetBall() {
        transform.position = new Vector3(0, 0);
        GameBehavior.Instance.LosePoint();
    }

}
