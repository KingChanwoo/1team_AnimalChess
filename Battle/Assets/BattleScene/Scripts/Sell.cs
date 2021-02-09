using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour
{
    public GamePlayController gamePlayController;
    public UIController uiController;
    public Sound sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SellBox")
        {
            gamePlayController.currentGold += gamePlayController.draggedChampion.GetComponent<ChampionController>().sellCost;
            uiController.UpdateUI();
            Destroy(gamePlayController.draggedChampion);
            AudioSource.PlayClipAtPoint(sound.skillSE[2].clip, this.gameObject.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
