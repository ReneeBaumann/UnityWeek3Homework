using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private float _speed = 5.0f;

    public float Ylimit = 4.74f;  
    public float Xlimit = 9.43f;  
    public float BottomBoundary = -5f;  

    private int _xDir;
    private int _yDir;
    
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _score;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        ResetBall();  
    }

    void Update()
    {
        if (GameBehaviour.Instance.State == Utilities.GamePlayState.Play)
        {
            //Up and down walls 
            if (transform.position.y >= Ylimit)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    Mathf.Sign(transform.position.y) * Ylimit,
                    transform.position.z 
                );

                _yDir *= -1;
                
                _audioSource.clip = _wallHit;
                _audioSource.Play();
            }
            
            //Right and Left wall
            if (Mathf.Abs(transform.position.x) >= Xlimit)
            {
                // Ensure the ball stays inside the X limit
                transform.position = new Vector3(
                    Mathf.Sign(transform.position.x) * Xlimit,
                    transform.position.y,
                    transform.position.z
                );

                // Reverse the direction along the X-axis to avoid it getting stuck
                _xDir *= -1;
                
                _audioSource.clip = _wallHit;
                _audioSource.Play();
            }


            if (BottomBoundary >= transform.position.y)
            {
                ResetBall();  
            }

            transform.position += new Vector3(_speed * _xDir, _speed * _yDir, 0) * Time.deltaTime;
        }
    }
    
     void ResetBall()
    {
        transform.position = Vector3.zero; 
        _xDir = Random.value > 0.5f ? 1 : -1; 
        _yDir = Random.value > 0.5f ? 1 : -1; 

        _speed = GameBehaviour.Instance.InitBallSpeed; 
        
        GameBehaviour.Instance.Score = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ledge"))  
        {
            //_speed *= GameBehaviour.Instance.BallSpeedIncrement;  
            _yDir *= -1;  
        }

        if (other.gameObject.CompareTag("Brick"))  
        {
            float xDistance = Mathf.Abs(transform.position.x - other.gameObject.transform.position.x);
            float yDistance = Mathf.Abs(transform.position.y - other.gameObject.transform.position.y);
            
            if (xDistance > yDistance)
            {
                _xDir *= -1;
            }   
            
            if (yDistance > xDistance)
            {
                _yDir *= 1;
            }  
            
            _yDir *= -1;  
            
            Destroy(other.gameObject);  
            //_speed *= GameBehaviour.Instance.BallSpeedIncrement;
            
            _audioSource.clip = _paddleHit; 
            _audioSource.PlayOneShot(_score);

            GameBehaviour.Instance.Score += 1;
            
        }
    }
}
