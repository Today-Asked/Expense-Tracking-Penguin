using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yearRead : MonoBehaviour
{
    public TMPro.TMP_Text str;
    public int year;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnButtonClick()
    {
        year = int.Parse(str.text);
    }
}
