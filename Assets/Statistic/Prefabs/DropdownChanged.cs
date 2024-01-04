using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownChanged : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> names = new List<string>() { "2024", "2023", "2022" };
    public Dropdown dropdown;
    public Text Date;


    public void Dropdown_IndexChanged(int index)
    {
        Date.text = names[index];
    }
    void Start()
    {
        PopulateList();
    }

    private void PopulateList()
    {
        dropdown.AddOptions(names);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
