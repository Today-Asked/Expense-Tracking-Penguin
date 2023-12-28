using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class accountingInputController : MonoBehaviour
{
    public Toggle toggleExp, toggleInc;
    public TMPro.TMP_Dropdown ddlExp, ddlInc;
    public TMPro.TMP_InputField inputItem, inputDate, inputAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (!string.IsNullOrEmpty(inputItem.text) && !string.IsNullOrEmpty(inputDate.text) && !string.IsNullOrEmpty(inputAmount.text))
        {
            if(toggleExp.isOn)
            {
                Debug.Log($"0: Exp");
                Debug.Log($"1: {ddlExp.options[ddlExp.value].text}");
            }
            else
            {
                Debug.Log($"0: Inc");
                Debug.Log($"1: {ddlInc.options[ddlInc.value].text}");
            }
            Debug.Log($"2: {inputItem.text}");
            Debug.Log($"3: {inputDate.text}");
            Debug.Log($"4: {inputAmount.text}");
        }
        else
        {
            Debug.Log("Something Empty!");
        }
    }
}
