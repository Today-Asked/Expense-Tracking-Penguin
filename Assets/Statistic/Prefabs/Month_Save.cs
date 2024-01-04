using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Month_Save : MonoBehaviour
{
    public Text Date;
    public InputField Year;
    public InputField Month;
    public Button Save;
    public Button year_btn;
    public Button month_btn;
    public Button day_btn;
    public Button Close;
    public Dropdown ddMMonth;
    List<string> months = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
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
    public void Create()
    {
        string month = months[ddMMonth.value];
        Date.text = Year.text + "-" + month;
        //Date.text = Year.text + "/" + Month.text;
        //PlayerPrefs.SetString("", Date.text);
        //PlayerPrefs.Save();
        //Year.text = "";
        //Month.text = "";
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
