using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public ParticleSystem particle1, particle2;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "TriggerVFX")
        {
            counter++;
            Debug.Log("sono passato");
            if (counter >= 3)
            {
                particle1.Play();
                particle2.Play();
            }
        }
    }
}
