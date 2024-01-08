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
    newDatabaseScript ndbs;
    // Start is called before the first frame update
    void Start()
    {
        ndbs = FindObjectOfType<newDatabaseScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {   /* && !string.IsNullOrEmpty(inputAmount.text) && !(inputDate.text[0] >= '0' && inputDate.text[0] <= '9'))*/
        if (!string.IsNullOrEmpty(inputItem.text)) {

            string item = inputItem.text;
            int year = Convert.ToInt32(inputDate.text.Split('-')[0]);
            int month = Convert.ToInt32(inputDate.text.Split('-')[1]);
            StringBuilder tmp = new StringBuilder(inputDate.text.Split('-')[2]);
            tmp[2] = '\0';
            int day = Convert.ToInt32(tmp.ToString());
            string date = new DateTime(year, month, day).ToString();
            int amount = Convert.ToInt32(inputAmount.text);
            if (toggleExp.isOn)
            {
                int catagory = ddlExp.value;
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
                inputItem.text = inputAmount.text = "";
                ndbs.insert(0, catagory, item, year, month, day, date, amount);
            }
            else
            {
                int catagory = 8;
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
                inputItem.text = inputAmount.text = "";
                ndbs.insert(1, catagory, item, year, month, day, date, amount);

            }
        }
        else
        {
            Debug.Log("Something Empty!");
        }
    }
}
