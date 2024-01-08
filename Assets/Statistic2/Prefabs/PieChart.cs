using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PieChart : MonoBehaviour
{
    //pie chart
    public Image[] imagePieChart;
    public float[] values;

    public Image[] imagePieChart1;
    public float[] values1;
    //content

    public GameObject DataSpace;

    public GameObject Content;
    public Transform ParentObject;
    public string[] tagName;
    public Sprite[] tag;

    public GameObject Content1;
    public Transform ParentObject1;
    public string[] tagName1;
    public Sprite[] tag1;
    //date
    public Text Date;

    int cnt = 0;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetValue(values, imagePieChart);
        SetValue(values1, imagePieChart1);
        SetData(values, Content, ParentObject, tagName, tag);
        SetData(values1, Content1, ParentObject1, tagName1, tag1);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void recieve(string str)
    {
        string[] strs = str.Split(',');
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"$${int.Parse(strs[i])}");
        }
        for (int i = 0; i < 8; i++)
        {
            values[i] = int.Parse(strs[i]);
        }
        values1[0] = int.Parse(strs[8]);//
        values1[1] = int.Parse(strs[9]);
        foreach (float i in values1)
        {
            Debug.Log($"&{i}");
        }
        SetValue(values, imagePieChart);
        SetValue(values1, imagePieChart1);//
        foreach (Transform child in ParentObject)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ParentObject1)
        {
            Destroy(child.gameObject);
        }
        SetData(values, Content, ParentObject, tagName, tag);
        SetData(values1, Content1, ParentObject1, tagName1, tag1);
    }

    public void SetValue(float[] valuesToSet, Image[] imagePieChart)
    {
        float totalValues = 0;
        for (int i = 0; i < imagePieChart.Length; i++)
        {
            totalValues += FindPercentage(valuesToSet, i);
            imagePieChart[i].fillAmount = totalValues;
        }
    }

    private float FindPercentage(float[] valueToSet, int index)
    {
        float totalAmount = 0;
        for (int i = 0; i < valueToSet.Length; i++)
        {
            totalAmount += valueToSet[i];
        }
        if (totalAmount == 0)
        {
            return 0;
        }
        return valueToSet[index] / totalAmount;
    }

    private void SetData(float[] values, GameObject Content, Transform ParentObject, string[] tagName, Sprite[] tag)
    {
        cnt = 0;
        count = 0;
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != 0)
            {
                count++;
            }
        }
        //change Height
        RectTransform rectTransform = Content.GetComponent<RectTransform>();
        float elementHeight = rectTransform.rect.height;
        elementHeight = 120 * count + 40;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, elementHeight);
        //change y
        float elementY = elementHeight / 2 * (-1);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, elementY);

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != 0)
            {
                Vector3 spawnPosition = Content.transform.position + new Vector3(0f, -80 - 120f * cnt, 0f);
                GameObject Temp = Instantiate(DataSpace, ParentObject);
                Temp.transform.position = spawnPosition;
                //change the image
                Transform childImage = Temp.transform.Find("Image");
                Image Image = childImage.GetComponent<Image>();
                Image.sprite = tag[i];
                Image.color = new Color((float)137 / 255, (float)127 / 255, (float)127 / 255, 1f);
                //change the text
                Transform childText = Temp.transform.Find("Amount");
                TMP_Text myText = childText.GetComponent<TMP_Text>();
                myText.text = "$ " + values[i].ToString();
                myText.color = new Color((float)137 / 255, (float)127 / 255, (float)127 / 255, 1f);
                //change class
                Transform childClass = Temp.transform.Find("Class");
                TMP_Text myClass = childClass.GetComponent<TMP_Text>();
                myClass.text = tagName[i];
                myClass.color = new Color((float)137 / 255, (float)127 / 255, (float)127 / 255, 1f);

                cnt++;
            }
        }
    }
}


