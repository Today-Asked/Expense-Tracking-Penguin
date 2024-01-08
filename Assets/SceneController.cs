using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public GameObject Panel;
    int Page = 1;
    // Start is called before the first frame update
    void Start()
    {
        //set panel's image to page 1
        Panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Tutorials/"+ Page.ToString());
        //Panel.GetComponent<Image>().sprite = Resources.Load<Image>("Sprites/Panel1");penguinPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Image/" + PenguinName);
    }
    
    public void OpenTutorial() {
        Page = 1;
        Panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Tutorials/" + Page.ToString());
    }

    public void NextPage() {
        if (Page == 9) return;
        Page++;
        Panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Tutorials/" + Page.ToString());
    }

    public void PrevPage() {
        if(Page == 1) return;
        Page--;
        Panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Tutorials/" + Page.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene() {
        //jump to game scene
        SceneManager.LoadScene(1);
    }
}
