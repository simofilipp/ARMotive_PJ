using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCarController : MonoBehaviour
{
    static int pos = 0;
    Vector2 initialPos;
    Vector2 altroBottoneinitialPos;

    public GameObject altroBottone;
    static public GameObject panelSelezione;
    // Start is called before the first frame update
    void Start()
    {
        panelSelezione = GameObject.Find("PanelSelezione");
        panelSelezione.transform.localPosition = new Vector2(0, -870);
        initialPos=this.transform.localPosition;
        altroBottoneinitialPos = altroBottone.transform.localPosition;
        Debug.Log(initialPos.x + ", " + initialPos.y);
        Debug.Log(altroBottoneinitialPos.x + ", " + altroBottoneinitialPos.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CarTrackButton()
    {
        if (this.gameObject.name == "ButtonCar")
        {
            switch (pos)
            {
                case 0:
                    transform.LeanMoveLocal(new Vector2(0,400), 1).setEaseOutQuart();
                    altroBottone.transform.LeanMoveLocal(new Vector2(altroBottoneinitialPos.x, 400), 1).setEaseOutQuart();
                    panelSelezione.transform.LeanMoveLocalY(-119.5f, 1).setEaseOutQuart();
                    pos = 1;
                    break;
                case 1:
                    transform.LeanMoveLocal(initialPos, 1).setEaseOutQuart();
                    altroBottone.transform.LeanMoveLocal(altroBottoneinitialPos, 1).setEaseOutQuart();
                    panelSelezione.transform.LeanMoveLocalY(-870, 1f).setEaseOutQuart();
                    pos = 0;
                    break;
                case 2:
                    transform.LeanMoveLocal(new Vector2(0, 400), 1).setEaseOutQuart();
                    altroBottone.transform.LeanMoveLocal(new Vector2(altroBottoneinitialPos.x, 400), 1).setEaseOutQuart();
                    pos = 1;
                    break;


            }
        }
        if (this.gameObject.name == "ButtonTrack")
        {
            switch (pos)
            {
                case 0:
                    transform.LeanMoveLocal(new Vector2(0, 400), 1).setEaseOutQuart();
                    altroBottone.transform.LeanMoveLocal(new Vector2(altroBottoneinitialPos.x, 400), 1).setEaseOutQuart();
                    panelSelezione.transform.LeanMoveLocalY(-119.5f, 1).setEaseOutQuart();
                    pos = 2;
                    break;
                case 1:
                    transform.LeanMoveLocal(new Vector2(0, 400), 1).setEaseOutQuart();
                    altroBottone.transform.LeanMoveLocal(new Vector2(altroBottoneinitialPos.x, 400), 1).setEaseOutQuart();
                    pos = 2;
                    break;
                case 2:
                    transform.LeanMoveLocal(initialPos, 1).setEaseOutQuart();
                    altroBottone.transform.LeanMoveLocal(altroBottoneinitialPos, 1).setEaseOutQuart();
                    panelSelezione.transform.LeanMoveLocalY(-870, 1).setEaseOutQuart();
                    pos = 0;
                    break;
            }
        }
    }
}
