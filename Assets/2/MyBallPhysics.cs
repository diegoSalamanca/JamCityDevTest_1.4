/*Exercise made by Diego Salamanca for Jam City, on January 3 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/

namespace  Exercise2
{
    using UnityEngine;

    public class MyBallPhysics : MonoBehaviour
    {
        bool activateCollision = true;

        [SerializeField]
        Vector3 speed;

        MyOwnPhysicsSystem myOwnPhysicsSystem;

        Vector3 direction;

        Vector3 move;

        [SerializeField]
        float  ballRadius;

        public void EnableBall() 
        {
            myOwnPhysicsSystem = FindObjectOfType<MyOwnPhysicsSystem>(); 

            if(myOwnPhysicsSystem.RandomSpeed)
            {
                speed = new Vector3(Random.Range(-10,10),Random.Range(-10,10),0);
            }
        
            else
            {
                speed = new Vector3(myOwnPhysicsSystem.XstartSpeed,myOwnPhysicsSystem.YstartSpeed,0);
            }
            
        
        
        gameObject.SetActive(true);
        Invoke("ResetBall",5f);
        }

        private void Start() 
        {
            myOwnPhysicsSystem = FindObjectOfType<MyOwnPhysicsSystem>();       
        
        }
        

        private void FixedUpdate() {

            
            
            speed.y += myOwnPhysicsSystem.Gravity/100;

            move = transform.position + (speed * Time.deltaTime);        

            transform.position = new Vector3(Mathf.Clamp(move.x,-5.1f+ballRadius,5.1f-ballRadius),Mathf.Clamp(move.y,-5.1f+ballRadius,5.1f-ballRadius),0);

            if(activateCollision)
            EvalateCollisions();
            
        }  

        public bool BoxCollisionEvaluate(MyBoxCollider boxCollider)
        {
            var a = transform.position;
            var b = boxCollider.gameObject.transform.position;

            if(boxCollider.colisionAxis.Equals(MyBoxCollider.ColisionAxis.x))
            {           
                var c =  Vector2.Distance(new Vector2(a.x, a.y),new Vector2(a.x, b.y));
                if(c < ballRadius+boxCollider.height/2) 
                return true;
            
            

                
            }
            else if (boxCollider.colisionAxis.Equals(MyBoxCollider.ColisionAxis.y))
            {
                var c =  Vector2.Distance(new Vector2(a.x, a.y),new Vector2(b.x, a.y));
                if(c < ballRadius+boxCollider.widht/2)
                return true;
            }     

            return false;
        }


        public void EvalateCollisions()
        {
            var colliders = FindObjectsOfType<MyBoxCollider>();

            var forceDecrease = 1- (myOwnPhysicsSystem.ForceDecrease/100);

            for (int i = 0; i < colliders.Length; i++)
            {  
                if(BoxCollisionEvaluate(colliders[i]))
                {
                    activateCollision = false;
                    print("colision con "+colliders[i].name  );
                    if(colliders[i].colisionAxis.Equals(MyBoxCollider.ColisionAxis.x))
                    {
                        speed.y = speed.y * forceDecrease;
                        speed.y *=-1f; 
                    }

                    else if(colliders[i].colisionAxis.Equals(MyBoxCollider.ColisionAxis.y))
                    {
                        speed.x = speed.x * forceDecrease;
                        speed.x *=-1f;   
                    }

                        
                                
                    Invoke("EnableColiision",0.05f);
                    
                    return;
                }            
            }

        }

        

        public void EnableColiision()
        {
            activateCollision = true;
        }

        public void ResetBall()
        {
            gameObject.SetActive(false);
            speed = Vector3.zero;
        }

        

    }

    
}
