using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingSettings : MonoBehaviour
{
    ARTrackedImageManager _trackedImageManager;
    public GameObject pistaInScena;
    public Dictionary<string, GameObject> tracciati = new Dictionary<string, GameObject>();

    ARTrackedImage genericImage;

    public GameObject imolaTrackPrefab;
    public GameObject monzaTrackPrefab;
    public GameObject qatarTrackPrefab;


    private void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        tracciati.Add("Imola", imolaTrackPrefab);
        tracciati.Add("Monza", monzaTrackPrefab);
        tracciati.Add("Qatar", qatarTrackPrefab);

        //pistaInScena = Instantiate(imolaTrackPrefab);
    }

    private void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += ChangePrefabOnImage;//quando attivo il gameobject dico che se viene riconosciuta un immagine, esegue quel metodo

    }
    private void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= ChangePrefabOnImage;
    }

    private void ChangePrefabOnImage(ARTrackedImagesChangedEventArgs images)
    {
        foreach (ARTrackedImage image in images.added)
        {

            if (tracciati.ContainsKey(image.referenceImage.name))
            {
                pistaInScena=Instantiate(tracciati[image.referenceImage.name], image.transform);
                genericImage = image;
            }
            //if (image.referenceImage.name == "Imola")
            //{
            //    var obj = Instantiate(imolaTrackPrefab, image.transform);


            //    imolaImage = image;
            //}
        }
    }

    private void Update()
    {
        if (genericImage != null)
        {
            if(genericImage.trackingState==TrackingState.Limited)//immagine già riconosciuta, ma non visualizzata al momento
            {
                genericImage.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (genericImage.trackingState == TrackingState.Tracking)
            {
                genericImage.transform.GetChild(0).gameObject.SetActive(true);
            }

        }
    }

}
