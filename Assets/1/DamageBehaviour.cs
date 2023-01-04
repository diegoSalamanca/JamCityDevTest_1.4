/*Exercise made by Diego Salamanca for Jam City, on January 2 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/
using UnityEngine;

namespace Exercise1
{
    public class DamageBehaviour : UnitHealth
    {
        [SerializeField]  
        int health;
        public int Health { get => health; set => health = value; }

        [SerializeField]   
        DamageBehaviourType damageBehaviourType;

        enum DamageBehaviourType
        {
            standard,
            reduced, 
            inmortal
        }

        

        public override void Damage(int damage)
        {
            switch(damageBehaviourType)
            {
                default:
                    Health-=damage;                
                break;

                case DamageBehaviourType.standard:
                    Health-=damage;
                break;     

                case DamageBehaviourType.reduced:
                    var reducedDamage = damage*0.6f;
                    Health-= (int)reducedDamage;
                break; 

                case DamageBehaviourType.inmortal:
                    if(Health-damage>0)
                        Health-=damage;
                    else
                        Health = 1;                
                break;        

            }

            EvaluateIfDead();
        }

        public override int GetCurrentHealth()
        {
            return Health;
        }
        

        void EvaluateIfDead()
        {
            if(Health<=0)
            {
                GetComponent<DeadBehaviour>().Dead();
            }
        }
    }
}


