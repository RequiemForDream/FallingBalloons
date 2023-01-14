using UnityEngine;

namespace BalloonStaff 
{ 
    public class BalloonMotion : MonoBehaviour
    {      
        public void Move(Rigidbody2D rigidbody2D, float velocity) 
        {
            rigidbody2D.MovePosition(new Vector2(transform.position.x, 
                transform.position.y - velocity));   
        }
    }
}


