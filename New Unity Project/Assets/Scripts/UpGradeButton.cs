using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeButton : MonoBehaviour
{
    public Text upgradeDisplay;

    public string upGradeName;

    //퍼블릭이지만 숨겨서 수정이 불가능하게함
    [HideInInspector]

    //게임을 하면서 업그레이드
    public int goldByUpgrade;

    //게임시작할때 골드업그레이드
    public int startGoldByUpgrade;

    //아이템을 구매할때 가격
    public int currentCost = 1;

    //게임시작할때 아이템구매가격
    public int startCurrentCost = 1;

    [HideInInspector]
    public int level = 1;

    //업그레이드시 파워상승값
    public float upGradePow = 1.07f;

    //업그레이드시 가격
    public float costPow = 3.14f;

    //public DataController datacontroller;



    void Start()
    {
        /*
        currentCost = startCurrentCost;
        level = 1;
        goldByUpgrade = startGoldByUpgrade;
        */
        //게임시작할때 업그레이드 버튼에 저장된 자신의 데이타를 불러옴. 저장은 밑에 구매했을때
        DataController.GetInstance().LoadUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            //구매와 동시에 자신의 데이타를 저장함.
            DataController.GetInstance().SaveUpgradeButton(this);
        }
    }

    public void UpdateUpgrade()
    {
        //업그레이드 가격과 파워 상승
        goldByUpgrade = startGoldByUpgrade * (int) Mathf.Pow(upGradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        upgradeDisplay.text = upGradeName + "\nCost:" + currentCost + "\nLevel:" + level + "\nNext GoldPerClick:" + goldByUpgrade;
    }
}
