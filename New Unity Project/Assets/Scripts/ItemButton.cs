using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Text itemDisplayer;

    public string itemName;

    public int level;

    [HideInInspector]
    public int currentCost;

    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerSec;

    public int startGoldPerSec = 1;

    public float costPow = 3.14f;

    public float upgradePow = 1.07f;

    public bool isPurchased = false;

    void Start()
    {

        DataController.GetInstance().LoadItemButton(this);
        //시작시 가격과 골드를 캐는 능력수치
        //순서도 중요함, 밑에2줄을 코루틴 아래에 넣으면 0으로 나옴
        //데이타 콘트롤러에서 저장된걸 로드함으로써 밑에 2줄 안씀
        //currentCost = startCurrentCost;
        //goldPerSec = startGoldPerSec;

        StartCoroutine("AddGoldLoop");

        //게임시작하자마자 아이템 구입 유무를 알려줌.
        UpdateUI();

    }

    public void PurchaseItem()
    {
        if(DataController.GetInstance().GetGold() >= currentCost)
        {
            //돈이 충분하면 아이템을 구입하고, 가격만큼 돈을 뺀다
            isPurchased = true;
            DataController.GetInstance().SubGold(currentCost);
            //level = level + 1
            level++;

            UpDateItem();
            UpdateUI();

            //아이템을 구매하면 데이타콘트롤러에 저장이 됨
            DataController.GetInstance().SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()
    {
        while(true)
        {
            if(isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);
            }
            //yield 를 중간에 넣어 1초 대기타임을 준다.이게 없으면 위 문장이 무한정 반복한다.
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpDateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int) Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = itemName + "\nLevel:" + level + "\nCost:" + currentCost + "\nGold Per Sec:" 
            + goldPerSec + "\nisPurchased: " + isPurchased;
    }
}
