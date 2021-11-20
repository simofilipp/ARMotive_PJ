using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum Marce
{
    PrimaMarcia,
    SecondaMarcia,
    TerzaMarcia,
    QuartaMarcia,
    QuintaMarcia
}

public class MyCineDollyScript : MonoBehaviour
{
    [SerializeField] Image contagiri;
    float acc;

    ImageTrackingSettings its;
    CinemachineDollyCart cdc;
    GameObject pista;
    Marce marciaCorrente=Marce.PrimaMarcia;
    float speed;
    Dictionary<Marce, float> maxMarce;
    Coroutine myCor;

    private void Start()
    {
        maxMarce = new Dictionary<Marce, float>();
        maxMarce.Add(Marce.PrimaMarcia, 0.01f);
        maxMarce.Add(Marce.SecondaMarcia, 0.03f);
        maxMarce.Add(Marce.TerzaMarcia, 0.05f);
        maxMarce.Add(Marce.QuartaMarcia, 0.07f);
        maxMarce.Add(Marce.QuintaMarcia, 0.09f);

        its = GetComponent<ImageTrackingSettings>();
    }

    public void Accelera()
    {
        if (its.pistaInScena != null)
        {
            cdc = its.pistaInScena.transform.GetChild(0).transform.GetChild(1).GetComponent<CinemachineDollyCart>();
            myCor = StartCoroutine(AumentaVelocita());
        }
    }

    public void CambiaMarcia()
    {
        if (marciaCorrente != Marce.QuintaMarcia)
        {
            StopCoroutine(myCor);
            marciaCorrente++;
        }
        contagiri.fillAmount = speed / maxMarce[marciaCorrente];
        Debug.Log(marciaCorrente.ToString());
    }

    private  IEnumerator AumentaVelocita()
    {
        //for (float f = 0; f < maxMarce[marciaCorrente]; f += 0.001f)
        //{
        //    float speedTemp;
        //    if(speed >= maxMarce[marciaCorrente])
        //    {
        //        speed = maxMarce[marciaCorrente];
        //    }
        //    else speedTemp = f;
        //    //cdc.m_Speed = speed;
        //    Debug.Log("Speed priv: " + speed);
        //    yield return new WaitForSeconds(0.5f);
        //}

        while (speed <= maxMarce[marciaCorrente])
        {
            contagiri.fillAmount = speed / maxMarce[marciaCorrente];

            speed += 0.001f;
            cdc.m_Speed = speed;
            Debug.Log("Speed priv: " + speed);
            yield return new WaitForSeconds(0.3f);
        }
    }
    private void Update()
    {
        switch (contagiri.fillAmount)
        {
            case 0.5f:
                contagiri.material.color = Color.yellow;
                break;
            case 0.85f:
                contagiri.material.color = Color.red;
                break;
        }
    }
}
