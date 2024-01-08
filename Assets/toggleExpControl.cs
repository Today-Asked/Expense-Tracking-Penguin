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
        // �b�o�̳B�zToggle���襤���A�ܤ�
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
