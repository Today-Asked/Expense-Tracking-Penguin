using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigControlButton : MonoBehaviour
{
    public GameObject PopUpWindow;
    public Button Statistic;
    public Button Book;
    public Button Add;
    //public Button day_btn;
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
            Statistic.enabled = false;
            Book.enabled = false;
            Add.enabled = false;
            //day_btn.enabled = false;
        }
        else
        {
            Statistic.enabled = true;
            Book.enabled = true;
            Add.enabled = true;
            //day_btn.enabled = true;
        }
    }

    public void SetActive()
    {
        Statistic.enabled = true;
        Book.enabled = true;
        Add.enabled = true;
    }
}
