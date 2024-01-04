using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class newDatabaseScript : MonoBehaviour
{
    int type;
    int catagory;
    string item;
    int year;
    int month;
    int day;
    string date;
    int amount;
    int curState;
    string url = "https://script.google.com/macros/s/AKfycbymsxcR4X--MkLvFfCY5ct42Kn0ojvUzEPvBZ6At4cgANsrfW16VgODLinkUMPhL1aR/exec";
    string output;

    //public Canvas canva;
    PieChart pc;
    private void Start()
    {
        //StartCoroutine(UpLoad());
        //canva.enabled = false;
        output = "";
        pc = FindObjectOfType<PieChart>();
        read(2024, 1, -1);
    }

    public void insert(int _type, int _catagory, string _item, int _year, int _month, int _day, string _date, int _amount)
    {
        curState = 0;
        type = _type;
        catagory = _catagory;
        item = _item;
        year = _year;
        month = _month;
        day = _day;
        date = _date;
        amount = _amount;
        StartCoroutine(UpLoad());
    }

    public void read(int _year, int _month, int _day)
    {
        curState = 1;
        year = _year;
        month = _month;
        day = _day;
        StartCoroutine(UpLoad());
    }
    /*public void trans()
    {
        int[] ints = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"##{output.Split(' ')[i]}");
            ints[i] = int.Parse(output.Split(' ')[i]);
        }
        pc.recieve(ints);
    }*/
    public IEnumerator UpLoad()
    {
        if (curState == 0)
        {
            WWWForm form = new WWWForm();
            form.AddField("method", "Write");
            form.AddField("type", type);
            form.AddField("catagory", catagory);
            form.AddField("item", item);
            form.AddField("year", year);
            form.AddField("month", month);
            form.AddField("day", day);
            form.AddField("date", date);
            form.AddField("amount", amount);
            UnityWebRequest request = UnityWebRequest.Post(url, form);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log($"***{request.error}");
            }
            else
            {
                Debug.Log($"***{request.downloadHandler.text}");
            }
        }
        else if (curState == 1)
        {

            WWWForm form = new WWWForm();
            form.AddField("method", "Read");
            form.AddField("year", year);
            form.AddField("month", month);
            form.AddField("day", day);
            UnityWebRequest request = UnityWebRequest.Post(url, form);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log($"***{request.error}");
            }
            else
            {
                output = request.downloadHandler.text;
                Debug.Log($"***{output}");
                //trans();
                pc.recieve(output);
            }
        }
    }

}