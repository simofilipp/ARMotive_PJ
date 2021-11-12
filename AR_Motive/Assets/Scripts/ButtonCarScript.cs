using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCarScript : MonoBehaviour
{
    public GameObject pista;
    public GameObject car;
    ImageTrackingSettings iTS;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        iTS = GameObject.Find("AR Session Origin").GetComponent<ImageTrackingSettings>();
        //pista = iTS.pistaInScena;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCar()
    {
        pista = iTS.pistaInScena;
        //if (pista != null)
        //{
        for (int i = 0; i < pista.transform.GetChild(0).transform.GetChild(1).transform.childCount; i++)
        {
            if (pista.transform.GetChild(0).transform.GetChild(1).transform.GetChild(i).name == car.name )
            {
                pista.transform.GetChild(0).transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(true);
                
            }
            else if (pista.transform.GetChild(0).transform.GetChild(1).transform.GetChild(i).name == "VFXParent")
            {
                pista.transform.GetChild(0).transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                pista.transform.GetChild(0).transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        //Debug.Log(car.name);
        //}
    }
}
