/*Exercise made by Diego Salamanca for Jam City, on January 2 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/



using UnityEngine;

public class DeadBehaviour : MonoBehaviour
{
    private bool alive = true;

    [SerializeField]   
    DeadBehaviourType deadBehaviourType;

    enum DeadBehaviourType
    {
        immediate,
        scaled, 
        vfx
    }

    public void Dead()
    {
        if(!alive)
         return;
        
        

        switch(deadBehaviourType)
        {
            default:
                DestroyNow();
            break;

            case DeadBehaviourType.immediate:
                DestroyNow();
            break;

            case DeadBehaviourType.scaled:
                transform.localScale = Vector3.one*2;
                Invoke("DestroyNow",5);
            break;

            case DeadBehaviourType.vfx:
                gameObject.AddComponent<ParticleSystem>();
                Invoke("DestroyNow",5);
                
            break;
        }

        alive = false;
    }

    void DestroyNow()
    {
        Destroy(gameObject);
    }
}
