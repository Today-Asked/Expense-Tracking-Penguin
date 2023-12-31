using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetDate : MonoBehaviour
{
    public TextMeshProUGUI choseDate;
    public Text Date;
    public Button Save;
    public Button year_btn;
    public Button month_btn;
    public Button day_btn;
    public Button Close;

    public newDatabaseScript ndbs;
    public TMPro.TMP_Text inputDate;

    // Start is called before the first frame update
    void Start()
    {
        year_btn.enabled = false;
        month_btn.enabled = false;
        day_btn.enabled = false;
        Close.enabled = false;
        Save.onClick.AddListener(Create);
    }

    public void OnButtonPress()
    {
        int year = Convert.ToInt32(inputDate.text.Split('-')[0]);
        int month = Convert.ToInt32(inputDate.text.Split('-')[1]);
        StringBuilder tmp = new StringBuilder(inputDate.text.Split('-')[2]);
        tmp[2] = '\0';
        int day = Convert.ToInt32(tmp.ToString());
        ndbs.read(year, month, day);
    }

    private void Create()
    {
        Date.text = choseDate.text;
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
