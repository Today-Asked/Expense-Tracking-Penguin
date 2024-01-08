using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class Year_Save : MonoBehaviour {
    public Text Date;
    public InputField Year;
    public Button Save;
    //public Button Cancel;
    public Button year_btn;
    public Button month_btn;
    public Button day_btn;
    public Button Close;

    public newDatabaseScript ndbs;
    // Start is called before the first frame update
    void Start() {
        Date.text = "";
        DateTime currtime = DateTime.Now;
        string year = currtime.Year.ToString();
        Year.text = year;
        year_btn.enabled = false;
        month_btn.enabled = false;
        day_btn.enabled = false;
        Close.enabled = false;
        Save.onClick.AddListener(Create);
    }
    public void OnButtonPress() {
        ndbs.read(int.Parse(Year.text), -1, -1);
    }

    // Update is called once per frame
    public void Create() {
        Date.text = Year.text;
        PlayerPrefs.SetString("", Date.text);
        PlayerPrefs.Save();
        //Year.text = "";
        year_btn.enabled = true;
        month_btn.enabled = true;
        day_btn.enabled = true;
        Close.enabled = true;
    }

    public void Up() {
        int year = int.Parse(Year.text);
        year++;
        Year.text = year.ToString();
    }

    public void Down() {
        int year = int.Parse(Year.text);
        year--;
        Year.text = year.ToString();
    }
}