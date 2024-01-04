using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateData : MonoBehaviour
{
    public Sprite[] tag;
    public GameObject DataSpace;
    public GameObject Content;
    public Transform ParentObject;
    public float[] values;
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != 0)
            {
                Vector3 spawnPosition = transform.position + new Vector3(0f, 250 -150f * cnt, 0f);

                GameObject Temp = Instantiate(DataSpace, ParentObject);
                Temp.transform.position = spawnPosition;
                //change the image
                Transform childImage = Temp.transform.Find("Image");
                Image Image = childImage.GetComponent<Image>();
                Image.sprite = tag[i];
                Image.color = new Color((float)137/255, (float)127 / 255, (float)127 / 255, 1f);
                //change the text
                Transform childText = Temp.transform.Find("Amount");
                TMP_Text myText = childText.GetComponent<TMP_Text>();
                myText.text = "$ " + values[i].ToString();
                myText.color = new Color((float)137 / 255, (float)127 / 255, (float)127 / 255, 1f);
                cnt++;
            }
        }
        //change Height
        RectTransform rectTransform = Content.GetComponent<RectTransform>();
        float elementHeight = rectTransform.rect.height;
        elementHeight = 150 * cnt;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, elementHeight);
        //change y
        float elementY = elementHeight / 2 * (-1);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, elementY);
    }

    // Update is called once per frame
    void Update()
    {

    }

 
}
