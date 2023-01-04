
/*Exercise made by Diego Salamanca for Jam City, on January 3 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/

namespace  Exercise2
{
    using UnityEngine;

    public class BallsController : MonoBehaviour
    {

        [SerializeField]
        BallsPulling ballsPulling;
        

        public int ballIndex = 0;
        

        
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                var pos =  Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x,Input.mousePosition.y, 0) );
                
                PutBall(pos);
            }
        }

        void PutBall(Vector3 clickPos )
        {
            var ballPhysics = ballsPulling.balls[ballIndex].GetComponent<MyBallPhysics>();
            ballPhysics.ResetBall();
            ballPhysics.EnableBall();
            ballsPulling.balls[ballIndex].transform.position = clickPos;
            ballIndex++;
            if(ballIndex>=ballsPulling.balls.Count)
            {
                ballIndex = 0;
            }
        }
    }
}


