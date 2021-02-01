using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampionInfo : MonoBehaviour
{
    InputController inputController;
    private void OnMouseEnter()
    {
        inputController.ChampionInfoOn(this.gameObject);
    }
    private void OnMouseExit()
    {
        inputController.ChampionInfoOff();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputController = GameObject.Find("Scripts").GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
