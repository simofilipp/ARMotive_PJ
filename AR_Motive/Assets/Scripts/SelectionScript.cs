using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject selectionBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        dialogBox.SetActive(true);
        dialogBox.transform.LeanScale(Vector2.one, 0.6f).delay = 0.1f;
        Invoke("ResetSeelectionBox", 0.01f);
    }

    private void ResetSeelectionBox()
    {
        selectionBox.transform.localPosition = new Vector2(0, -119.5f);
    }

    public void Clicked()
    {
        dialogBox.transform.LeanScale(Vector2.zero, 0.6f).setEaseInBack().setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        this.gameObject.SetActive(false);
    }
}
