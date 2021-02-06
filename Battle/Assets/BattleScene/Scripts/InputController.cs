using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controlls player input
/// </summary>
public class InputController : MonoBehaviour
{
    public UIController uiController;
    public GamePlayController gamePlayController;
    public GameObject hitObject;

    public GameObject championInfo;
    public Text nameText;
    public Text levelText;
    public Text synergyText;
    public Text skillText;
    public Text skillNameText;
    public Text skillExplianText;
    public Text hpText;
    public Text mpText;
    public Text atkText;
    public Text defText;
    public Text atkSpeedText;
    public Text criticalText;
    public Text moveSpeedText;
    public Text evasionText;
    public Text sellCostnText;

    //map script
    public Map map;


    public LayerMask triggerLayer;

    //declare ray starting position var
    private Vector3 rayCastStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set position of ray starting point to trigger objects
        rayCastStartPosition = new Vector3(0, 20, 0);
        uiController = GameObject.Find("Scripts").GetComponent<UIController>();
    }

    //to store mouse position
    private Vector3 mousePosition;

    
    [HideInInspector]
    public TriggerInfo triggerInfo = null;

    /// Update is called once per frame
    void Update()
    {
        triggerInfo = null;
        map.resetIndicators();

        //declare rayhit
        RaycastHit hit;

        //convert mouse screen position to ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if ray hits something
        if (Physics.Raycast(ray, out hit, 100f, triggerLayer, QueryTriggerInteraction.Collide))
        {
            //get trigger info of the  hited object
            triggerInfo = hit.collider.gameObject.GetComponent<TriggerInfo>();
            hitObject = hit.collider.gameObject;
            

            //this is a trigger
            if(triggerInfo != null)
            {
                //get indicator
                GameObject indicator = map.GetIndicatorFromTriggerInfo(triggerInfo);

                //set indicator color to active
                indicator.GetComponent<MeshRenderer>().material.color = map.indicatorActiveColor;
            }
            else
                map.resetIndicators(); //reset colors
        }
               

        if (Input.GetMouseButtonDown(0))
        {
            gamePlayController.StartDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            gamePlayController.StopDrag();
        }

        //store mouse position
        mousePosition = Input.mousePosition;
    }
    
    public void ChampionInfoOn(GameObject champion)
    {
        championInfo.SetActive(true);
        ChampionController champ = champion.GetComponent<ChampionController>();
        nameText.text = champ.champion.uiname;
        levelText.text = champ.lvl + "성";
        synergyText.text = champ.champType1.displayName + "\n" + champ.champType2.displayName;
        skillNameText.text = champ.champion.skillName;
        skillExplianText.text = champ.champion.skillExplain;
        hpText.text = "체력 : " + champ.currentHealth + "/" + champ.maxHealth;
        mpText.text = "마나 : " + champ.currentMana + "/" + champ.maxMana;
        atkText.text = "공격력 : " + champ.currentDamage;
        defText.text = "방어력 : " + champ.currentDefence;
        atkSpeedText.text = "공격속도 : " + champ.currentAttackSpeed;
        criticalText.text = "치명률 : " + champ.currentCritical;
        moveSpeedText.text = "이동속도 : " + champ.currentMoveSpeed;
        evasionText.text = "회피율 : " + champ.currentEvasion;
        sellCostnText.text = "판매가격 : " + champ.champion.sellCost + "G";
    }

    public void ChampionInfoOff()
    {
        championInfo.SetActive(false);
    }
}
