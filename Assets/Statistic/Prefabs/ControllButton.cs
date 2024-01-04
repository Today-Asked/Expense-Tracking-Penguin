using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllButton : MonoBehaviour
{
    public GameObject PopUpWindow;
    public Button Close;
    public Button year_btn;
    public Button month_btn;
    public Button day_btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool Open = PopUpWindow.activeSelf;
        if (Open)
        {
            Close.enabled = false;
            year_btn.enabled = false;
            month_btn.enabled = false;
            day_btn.enabled = false;
        }
        else
        {
            Close.enabled = true;
            year_btn.enabled = true;
            month_btn.enabled = true;
            day_btn.enabled = true;
        }
    }
}
