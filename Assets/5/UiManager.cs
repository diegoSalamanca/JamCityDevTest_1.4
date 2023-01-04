/*Exercise made by Diego Salamanca for Jam City, on January 2 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/

using UnityEngine;
using UnityEngine.UI;


namespace Exersice5

{
  public class UiManager : MonoBehaviour
{

    [SerializeField]
    GameObject windowA,windowB,toogleElement;    

    [SerializeField]
    Button toogle, toogleA, toogleB;    

    [SerializeField]
    Text toggletext;


    
    void Start()
    {
        toogle.onClick.AddListener(ToogleBehaviour);
        toogleA.onClick.AddListener(ToogleABehaviour);
        toogleB.onClick.AddListener(ToogleBBehaviour);
        windowA.SetActive(false);
        windowB.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ToogleBehaviour();
        }
        
    }

    void ToogleBehaviour()
    {
        if(windowA.activeInHierarchy || windowB.activeInHierarchy )
        {
            windowA.SetActive(false);
            windowB.SetActive(false);
            toggletext.text = "Show";
        }
        else 
        {
            windowA.SetActive(true);            
            toggletext.text = "Hide";
        }


    }

    void ToogleABehaviour()
    {
       windowA.SetActive(false);
       windowB.SetActive(true);
    }

    void ToogleBBehaviour()
    {
        windowA.SetActive(true);
        windowB.SetActive(false);
    }

   
}

}

