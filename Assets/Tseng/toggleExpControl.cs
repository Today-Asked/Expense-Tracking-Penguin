using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class toggleExpControl : MonoBehaviour
{
    public Toggle toggleExp;
    public GameObject ddlExp;
    public GameObject ddlInc;
    // Start is called before the first frame update
    void Start()
    {
        toggleExp.onValueChanged.AddListener(OnRatioButtonValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRatioButtonValueChanged(bool isOn)
    {
        // 在這裡處理Toggle的選中狀態變化
        if (isOn)
        {
            ddlExp.SetActive(true);
            ddlInc.SetActive(false);
        }
        else
        {
            ddlExp.SetActive(false);
            ddlInc.SetActive(true);
        }
    }
}
