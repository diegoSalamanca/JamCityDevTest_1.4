/*Exercise made by Diego Salamanca for Jam City, on January 3 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/

using UnityEngine;

public class MyOwnPhysicsSystem : MonoBehaviour
{
    [SerializeField]
    private float gravity;

    public float Gravity { get => gravity;  }
    

    [SerializeField ,Range(0,100), Header("% decrease force on collision ")]
    private float forceDecrease;

    public float ForceDecrease { get => forceDecrease;  }
    [SerializeField, Range(-10, 10), Header("X initial Speed")]
    private int xstartSpeed;
    public int XstartSpeed { get => xstartSpeed; }

    [SerializeField, Range(-10, 10), Header("Y initial Speed")]
    private int ystartSpeed;
    public int YstartSpeed { get => ystartSpeed; }

    [SerializeField, Header("set random Speed")]
    bool randomSpeed;
    public bool RandomSpeed { get => randomSpeed; set => randomSpeed = value; }

   



    

    






}
