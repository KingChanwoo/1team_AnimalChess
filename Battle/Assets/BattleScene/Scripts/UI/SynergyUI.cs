using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynergyUI : MonoBehaviour
{
    public GameObject explainPannel;
    public GameObject explainText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplainOn()
    {
        explainPannel.SetActive(true);
        explainText.SetActive(true);
    }

    public void ExplainOff()
    {
        explainPannel.SetActive(false);
        explainText.SetActive(false);
    }
}
