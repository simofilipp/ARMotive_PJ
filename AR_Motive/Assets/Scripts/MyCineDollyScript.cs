using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class MyCineDollyScript : MonoBehaviour
{
    CinemachineDollyCart cdc;

    private void Start()
    {
        cdc.m_Speed = 10;
    }

}
