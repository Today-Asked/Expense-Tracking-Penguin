using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEditor.PackageManager.UI;
using System;
using Unity.VisualScripting;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;

public class DatabaseScript : MonoBehaviour
{
    SqlConnection db = new SqlConnection();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\Assets\\Database1.mdf;");
        db.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                "AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\Assets\\Database1.mdf;" +
                "Integrated Security=True";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InsertDataIntoDatabase(int type, string catagory, string item, int year, int month, int day, string date, int amount)
    {
        try
        {
            db.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = $"INSERT INTO AccountingTable(Type,Catagory,Item,Year,Month,Day,Date,Amount)VALUES({type},'{catagory}','{item}','{year}','{month}','{day}','{date}',{amount})";

            cmd.ExecuteNonQuery();
            db.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
