using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public TextMeshProUGUI btn_text;
    public GameObject Out;
    public GameObject In_Out;
    public GameObject Out_S;
    public GameObject In_Out_S;
    public void Changed()
    {
        if (btn_text.text == "Expenditures")
        {
            In_Out.SetActive(true);
            Out.SetActive(false);
            In_Out_S.SetActive(true);
            Out_S.SetActive(false);
            btn_text.text = "Expenditures / Incomes";
        }
        else
        {
            In_Out.SetActive(false);
            Out.SetActive(true);
            In_Out_S.SetActive(false);
            Out_S.SetActive(true);
            btn_text.text = "Expenditures";
        }
    }
}
