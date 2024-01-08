using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Panels
    public GameObject NewPenguin;
    public GameObject SellPenguin;
    public GameObject ExpandIsland;
    public GameObject Dictionary;
    public GameObject NoMoney;

    GameObject PenguinOnClicked;
    public GameObject money;
    public GameObject level;

    public Canvas Canvas1, accountingInput;
    public GameObject Island1, Island2, Island3;
    public Dictionary<string, PenguinController> PenguinList = new Dictionary<string, PenguinController>();
    // Start is called before the first frame update
    string[] cat = new string[9];
    int PenguinCount = 0;
    void Start()
    {
        cat = new string[] { "Food", "Drink", "Transport", "Shopping", "Entertainment", "Renting", "Medical", "Education", "Income" };
        money.GetComponent<TextMeshProUGUI>().text = "800";
        level.GetComponent<TextMeshProUGUI>().text = "Lv. 1";
        //read penguin prefab from Resources/Prefabs/Penguin

        ExpandIsland.transform.GetChild(1).gameObject.SetActive(false);
        foreach (string s in cat)
        {
            GameObject penguinPrefab = Resources.Load<GameObject>("Prefabs/Penguins/Pinguin_" + s);
            if (penguinPrefab != null) Debug.Log("find" + penguinPrefab.gameObject.name);
            else Debug.Log("not found");
            PenguinController penguinController = penguinPrefab.GetComponent<PenguinController>();
            PenguinList.Add(s, penguinController);
            if (penguinController != null)
            {
                Debug.Log("inserted " + penguinPrefab.gameObject.name);
            }
        }

        //AddPenguin(0);
    }
    public bool Block()
    {
        if (Canvas1.gameObject.activeSelf == true || accountingInput.gameObject.activeSelf == true ||
           NewPenguin.activeSelf == true || SellPenguin.activeSelf == true || ExpandIsland.activeSelf == true || Dictionary.activeSelf == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if penguin is clicked, delete window will pop out
        if (Input.GetMouseButtonDown(0) && !Block())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // 進行射線檢測
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name.Contains("Pinguin"))
                {
                    PenguinOnClicked = hit.transform.gameObject;
                    SellPenguin.SetActive(true);
                    GameObject penguinPic = SellPenguin.transform.GetChild(1).gameObject;
                    string PenguinName = (PenguinOnClicked.name.Contains("Clone") ? PenguinOnClicked.name.Substring(0, PenguinOnClicked.name.Length - 7) : PenguinOnClicked.name);
                    Debug.Log(PenguinName);
                    penguinPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Image/" + PenguinName);
                }
            }
        }
    }

    public void ConfirmSell()
    { //confirm selling penguin
        PenguinOnClicked.SetActive(false);
        money.GetComponent<TextMeshProUGUI>().text = (int.Parse(money.GetComponent<TextMeshProUGUI>().text) + 100).ToString();
        PenguinCount--;
    }
    public Toggle Inc;
    public TMP_Dropdown Cat;
    
    public void AddPenguin()
    { //cat: catagory
        int i;
        if (Inc.isOn) i = 8;
        else i = Cat.value;
        Debug.Log("Adding penguin!");
        NewPenguin.SetActive(true);
        GameObject penguinPic = NewPenguin.transform.GetChild(1).gameObject;
        penguinPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Image/Pinguin_" + cat[i]);
        PenguinCount++;
        Instantiate(PenguinList[cat[i]].gameObject, new Vector3(Random.Range(2, -22), 5, Random.Range(2, -24)), Quaternion.identity);
        if (PenguinCount >= 15)
        {
            ExpandIsland.transform.GetChild(1).gameObject.SetActive(true); //hint to expand island
        }
        else
        {
            ExpandIsland.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public GameObject YesBtnText;
    public void Expand()
    {
        if (Island1.activeSelf == true)
        {
            ExpandIsland.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Upgrade to Level 2 island";
            ExpandIsland.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Finally, we see something except for ice.";
            YesBtnText.transform.GetComponent<TextMeshProUGUI>().text = "Yes ($1000)";
        }
        else if (Island2.activeSelf == true)
        {
            ExpandIsland.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Upgrade to Level 3 island";
            ExpandIsland.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "More entertainment for your penguins.";
            YesBtnText.transform.GetComponent<TextMeshProUGUI>().text = "Yes ($1500)";
        }
    }
    public void ConfirmExpand()
    {
        if ((Island1.activeSelf == true && int.Parse(money.GetComponent<TextMeshProUGUI>().text) < 1000) || (Island2.activeSelf == true && int.Parse(money.GetComponent<TextMeshProUGUI>().text) < 1500))
        {
            NoMoney.SetActive(true);
        }
        else
        {
            if (Island1.activeSelf == true)
            {
                Island1.SetActive(false);
                Island2.SetActive(true);
                money.GetComponent<TextMeshProUGUI>().text = (int.Parse(money.GetComponent<TextMeshProUGUI>().text) - 1000).ToString();
                level.GetComponent<TextMeshProUGUI>().text = "Lv. 2";
            }
            else if (Island2.activeSelf == true)
            {
                Island2.SetActive(false);
                Island3.SetActive(true);
                money.GetComponent<TextMeshProUGUI>().text = (int.Parse(money.GetComponent<TextMeshProUGUI>().text) - 1500).ToString();
                level.GetComponent<TextMeshProUGUI>().text = "Lv. 3";
            }
        }
    }
}