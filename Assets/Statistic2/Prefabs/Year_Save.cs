using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Year_Save : MonoBehaviour
{
    public Text Date;
    public InputField Year;
    public Button Save;
    //public Button Cancel;
    public Button year_btn;
    public Button month_btn;
    public Button day_btn;
    public Button Close;
    // Start is called before the first frame update
    void Start()
    {
        Date.text = "";
        Year.text = "2023";
        year_btn.enabled = false;
        month_btn.enabled = false;
        day_btn.enabled = false;
        Close.enabled = false;
        Save.onClick.AddListener(Create);
    }

    // Update is called once per frame
    public void  Create()
    {
        Date.text = Year.text;
        PlayerPrefs.SetString("", Date.text);
        PlayerPrefs.Save();
        //Year.text = "";
        year_btn.enabled = true;
        month_btn.enabled = true;
        day_btn.enabled = true;
        Close.enabled = true;
    }

    public void Up()
    {
        int year = int.Parse(Year.text);
        year++;
        Year.text = year.ToString();
    }

    public void Down()
    {
        int year = int.Parse(Year.text);
        year--;
        Year.text = year.ToString();
    }
}
