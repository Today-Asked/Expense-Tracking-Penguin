using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Closed_Set : MonoBehaviour
{
    public Button Cancel;
    public Button year_btn;
    public Button month_btn;
    public Button day_btn;
    public Button Close;
    // Start is called before the first frame update
    void Start()
    {
        year_btn.enabled = false;
        month_btn.enabled = false;
        day_btn.enabled = false;
        Close.enabled = false;
        Cancel.onClick.AddListener(Closed);
    }

    private void Closed()
    {
        year_btn.enabled = true;
        month_btn.enabled = true;
        day_btn.enabled = true;
        Close.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
