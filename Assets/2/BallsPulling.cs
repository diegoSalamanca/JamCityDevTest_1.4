/*Exercise made by Diego Salamanca for Jam City, on January 3 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/

using System.Collections.Generic;
using UnityEngine;

public class BallsPulling : MonoBehaviour
{
    [SerializeField]
    GameObject modelBall;

    public List<GameObject> balls = new List<GameObject>();
    
    private void Start() {
        
        for (int i = 0; i < 20; i++)
        {
            var ball = Instantiate(modelBall );
            ball.SetActive(false);
            balls.Add(ball);
        }
    }
}
