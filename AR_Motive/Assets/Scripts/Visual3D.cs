using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Visual3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load3DScene(string nomeOggetto)
    {
        SceneManager.LoadScene(1);
        OggettoDaPassare.oggettoDaPassare = nomeOggetto;
    }
}
