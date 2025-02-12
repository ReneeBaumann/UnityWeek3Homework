using UnityEngine;
using UnityEngine.UIElements;

public class BallBehaviour : MonoBehaviour
{
    public float XSpeed = 3.0f;
    public float YSpeed = 3.0f;

    public float Ylimit = 4.74f;
    public float Xlimit = 8.93f;

    private int _xDir;
    private int _yDir;

    void Start()
    {
        _xDir = Random.value > 0.5f ? 1 : -1; // Assign only once
        _yDir = Random.value > 0.5f ? 1 : -1; // Assign only once
    }

    void Update()
    {
        // Bounce off top/bottom walls
        if (Mathf.Abs(transform.position.y) >= Ylimit)
        {
            _yDir *= -1;
        }

        // Bounce off left/right walls (fixed from checking `y` instead of `x`)
        if (Mathf.Abs(transform.position.x) >= Xlimit)
        {
            _xDir *= -1;
        }

        // Move the ball
        transform.position += new Vector3(XSpeed * _xDir, YSpeed * _yDir, 0) * Time.deltaTime;
    }
}
