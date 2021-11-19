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
    Marce marciaCorrente=Marce.PrimaMarcia;
    float speed;
    Dictionary<Marce, float> maxMarce;
    Coroutine myCor;

    private void Start()
    {
        maxMarce = new Dictionary<Marce, float>();
        maxMarce.Add(Marce.PrimaMarcia, 0.01f);
        maxMarce.Add(Marce.SecondaMarcia, 0.02f);
        maxMarce.Add(Marce.TerzaMarcia, 0.03f);
        maxMarce.Add(Marce.QuartaMarcia, 0.04f);
        maxMarce.Add(Marce.QuintaMarcia, 0.05f);

        its = GetComponent<ImageTrackingSettings>();
        cdc = its.pistaInScena.transform.GetChild(0).transform.GetChild(1).GetComponent<CinemachineDollyCart>();
    }

    public void Accelera()
    {
        myCor=StartCoroutine(AumentaVelocita());
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
            switch (contagiri.fillAmount)
            {
                case 0.5f:
                    contagiri.color = Color.yellow;
                    break;
                case 0.85f:
                    contagiri.color = Color.red;
                    break;
            }
            speed += 0.001f;
            cdc.m_Speed = speed;
            Debug.Log("Speed priv: " + speed);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
