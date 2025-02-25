using UnityEngine;

public class SideToSideMovement_Ledge : MonoBehaviour
{   
    public float speed = 5f;
    public float xLimit = 3f;

    public KeyCode LeftArrow;
    public KeyCode RightArrow;
    
    void Start()
    {
        
    }

    void Update() 
    {   
        if (GameBehaviour.Instance.State == Utilities.GamePlayState.Play)
        { 
            
            float movement = 0;
            
            if (Input.GetKey(LeftArrow) && transform.position.x > -xLimit)
            {    
                movement = -speed * Time.deltaTime;
            }
            if (Input.GetKey(RightArrow) && transform.position.x < xLimit)
            {
                movement = speed * Time.deltaTime;
            }
             
            transform.position += new Vector3(movement, 0, 0);
        }
    }
}
