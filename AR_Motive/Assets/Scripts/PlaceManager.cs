using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager arrm;
    [SerializeField] ARPlaneManager arpm;
    GameObject prefabToPlace;
    Pose position;
    List<ARRaycastHit> piani = new List<ARRaycastHit>();

    bool prefabPosizionato=false;

    private void Awake()
    {
        Debug.Log(OggettoDaPassare.oggettoDaPassare);
        prefabToPlace = GameObject.Find(OggettoDaPassare.oggettoDaPassare);
    }

    // Start is called before the first frame update
    void Start()
    {
        //prefabToPlace.SetActive(true);
        arrm = GetComponent<ARRaycastManager>();
        arpm = GetComponent<ARPlaneManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !prefabPosizionato)
        {
            var tocco = Input.GetTouch(0);
            if (tocco.phase == TouchPhase.Began)
            {
                Vector2 puntoToccato = Input.GetTouch(0).position;
                if (arrm.Raycast(puntoToccato, piani, TrackableType.AllTypes))
                {
                    position = piani[0].pose;
                    var copiaPrefab = Instantiate(prefabToPlace, position.position, Quaternion.identity);
                    for (int i = 0; i < copiaPrefab.GetComponentsInChildren<MeshRenderer>().Length; i++)
                        copiaPrefab.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
                    prefabPosizionato = true;
                    arpm.enabled = false;
                }
            }
        }
    }

    public void BackHomeScene()
    {
        SceneManager.LoadScene(0);
    }
}
