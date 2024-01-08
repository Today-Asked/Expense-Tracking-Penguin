using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public TextMeshProUGUI Item;
    public TextMeshProUGUI Amount;
    public TextMeshProUGUI Date;
    // Start is called before the first frame update
    public void Cleared()
    {
        Item.text = "";
        Amount.text = "";
        Date.text = "";
    }
}
