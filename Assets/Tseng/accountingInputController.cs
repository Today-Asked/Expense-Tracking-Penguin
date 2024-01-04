using System;
using System.Collections;
using System.Collections.Generic;
using UI.Dates;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class accountingInputController : MonoBehaviour
{
    public Toggle toggleExp, toggleInc;
    public TMPro.TMP_Dropdown ddlExp, ddlInc;
    public TMPro.TMP_InputField inputItem, inputAmount;
    public TMPro.TMP_Text inputDate;
    DatabaseScript dbs;
    // Start is called before the first frame update
    void Start()
    {
        dbs = FindObjectOfType<DatabaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (!string.IsNullOrEmpty(inputItem.text) && !string.IsNullOrEmpty(inputAmount.text))
        {
            string catagory = ddlExp.options[ddlExp.value].text;
            string item = inputItem.text;
            int year = Convert.ToInt32(inputDate.text.Split('-')[0]);
            int month = Convert.ToInt32(inputDate.text.Split('-')[1]);
            StringBuilder tmp = new StringBuilder(inputDate.text.Split('-')[2]);
            tmp[2] = '\0';
            int day = Convert.ToInt32(tmp.ToString());
            string date= new DateTime(year, month, day).ToString();
            int amount=Convert.ToInt32(inputAmount.text);
            if (toggleExp.isOn)
            {
                Debug.Log($"0: Exp");
                Debug.Log($"1: {catagory}");
                Debug.Log($"2: {item}");
                Debug.Log($"3: {year}");
                Debug.Log($"3: {month}");
                Debug.Log($"3: {day}");
                Debug.Log($"4: {amount}");
                /*foreach(string i in inputDate.text.Split('-'))
                {
                    Debug.Log(i);
                }*/
                dbs.InsertDataIntoDatabase(0, catagory, item, year, month, day, date, amount);
            }
            else
            {
                Debug.Log($"0: Inc");
                Debug.Log($"1: {catagory}");
                Debug.Log($"2: {item}");
                Debug.Log($"3: {year}");
                Debug.Log($"3: {month}");
                Debug.Log($"3: {day}");
                Debug.Log($"4: {amount}");
                /*foreach (string i in inputDate.text.Split('-'))
                {
                    Debug.Log(i);
                }*/
                dbs.InsertDataIntoDatabase(1, catagory, item, year, month, day, date, amount);
            }
        }
        else
        {
            Debug.Log("Something Empty!");
        }
    }
}
