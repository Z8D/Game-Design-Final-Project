using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{

    public Text collectablesText;

    public int collectablesInt;





    // Start is called before the first frame update
    void Start()
    {
        collectablesInt = PlayerPrefs.GetInt("goldCount");
        collectablesText.text = "Gold Collected: " + collectablesInt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
