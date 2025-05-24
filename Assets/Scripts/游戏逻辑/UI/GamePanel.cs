using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GamePanel : BasePanel
{
    private Text txtEnemyCoinNum;
    private Text txtPlayerCoinNum;

    private Text txtEnemyMobilityNum;
    private Text txtPlayerMobilityNum;

    private Text txtTime;

    public Text txtTip;

    private Image imgEnemyMobility;
    private Image imgPlayerMobility;

    private ScrollRect svTavern;

    private Vector2 playerInitSize;
    private Vector2 enemyInitSize;

    private List<RoleItem> roleItems = new List<RoleItem>();

    public Toggle togCloseCombat;
    public Toggle togArcher;
    public Toggle togWizard;

    private Button btnAdvertise;



    public override void HideMe()
    {
        //先清楚之前的物体
        foreach (RoleItem item in roleItems)
        {
            Destroy(item.gameObject);
        }
        roleItems.Clear();
    }

    public override void ShowMe()
    {
        ChangeType(E_RoleType.CloseCombat);
        togCloseCombat.isOn = true;

        if (SceneManager.GetActiveScene().buildIndex == 3)
            btnAdvertise.gameObject.SetActive(false);
        else
            btnAdvertise.gameObject.SetActive(true);
    }

    protected override void Awake()
    {
        base.Awake();
        

        svTavern = GetControl<ScrollRect>("svTavern");

        txtEnemyCoinNum = GetControl<Text>("txtEnemyCoinNum");
        txtPlayerCoinNum = GetControl<Text>("txtPlayerCoinNum");
        txtEnemyMobilityNum= GetControl<Text>("txtEnemyMobilityNum");
        txtPlayerMobilityNum = GetControl<Text>("txtPlayerMobilityNum");
        txtTime = GetControl<Text>("txtTime");
        //txtTip.gameObject.SetActive(false);

        imgEnemyMobility = GetControl<Image>("imgEnemyMobility");
        imgPlayerMobility = GetControl<Image>("imgPlayerMobility");

        playerInitSize= imgEnemyMobility.rectTransform.sizeDelta;
        enemyInitSize = imgPlayerMobility.rectTransform.sizeDelta;

        togCloseCombat = GetControl<Toggle>("togCloseCombat");
        togArcher = GetControl<Toggle>("togArcher");
        togWizard = GetControl<Toggle>("togWizard");

        btnAdvertise = GetControl<Button>("btnAdvertise");

        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //更新时间
        txtTime.text = TextUtil.SecondToMS(SceneTimeMgr.Instance.GetCurrentSceneTime());
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch (btnName)
        {
            case "btnRetreat":
                //记录金币，返回开始场景
                if(SceneManager.GetActiveScene().buildIndex == 1)
                    PCAI.Instance.gameObject.SetActive(false);

                GameObjectMgr.Instance.playerRoleInfo = null;
                GameObjectMgr.Instance.AIRoleInfo = null;
                GameLevelMgr.Instance.SetCheckFalse();
                GameObjectMgr.Instance.ClearPiece();
                MusicMgr.Instance.ClearSound();
                PoolMgr.Instance.ClearPool();
                UIMgr.Instance.HidePanel<GamePanel>();
                GameDataMgr.Instance.SavePlayerCoin();
                if (SceneManager.GetActiveScene().buildIndex == 3)
                    UIMgr.Instance.HidePanel<TipPanel>();

                SceneMgr.Instance.LoadSceneAsyn("开始场景", () =>
                {
                    UIMgr.Instance.ShowPanel<BeginPanel>(E_UILayer.Bottom, (panel) =>
                    {
                        panel.ChangeCoinNum(GameDataMgr.Instance.playCoin);
                    });
                    GameObjectMgr.Instance.ClearPiece();
                });
                break;
            case "btnSetting":
                MusicMgr.Instance.PlaySound("按钮点击");
                UIMgr.Instance.ShowPanel<SettingPanel>();
                break;

            case "btnAdvertise":
                MusicMgr.Instance.PlaySound("按钮点击");
                //播放广告
                AdvertisementMgr.Instance.ShowAdv();
                //if (GameObjectMgr.Instance.AIChess.Count < 81)
                //    ChessBoard.chessBoard.RandomPlaceTopPiece();
                //else
                //    ChessBoard.chessBoard.DeleteTenAIPiece();
                break;
        }
    }

    

    protected override void ToggleValueChange(string toggleName, bool value)
    {
        base.ToggleValueChange(toggleName, value);
        switch (toggleName)
        {
            case "togCloseCombat":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (value)
                {
                    ChangeType(E_RoleType.CloseCombat);
                }
                break;
                
            case "togArcher":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (value)
                {
                    ChangeType(E_RoleType.Archer);
                }
                break;

            case "togWizard":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (value)
                {
                    ChangeType(E_RoleType.Wizard);
                }
                break;

            case "togSupplyTruck":
                if (value)
                {
                    ChangeType(E_RoleType.SupplyTruck);
                }
                break;
        }
    }

    /// <summary>
    /// 根据Toggle的不同而加载不同的物体
    /// </summary>
    /// <param name="roleType"></param>
    private void ChangeType(E_RoleType roleType)
    {
        //先清楚之前的物体
        foreach (RoleItem item in roleItems)
        {
            Destroy(item.gameObject);
        }
        roleItems.Clear();

        switch (roleType)
        {
            case E_RoleType.CloseCombat:
                AddItem2Content(GameDataMgr.Instance.closeCombatList);
                togCloseCombat.isOn = true;
                break;
            case E_RoleType.Archer:
                AddItem2Content(GameDataMgr.Instance.archerList);
                togArcher.isOn = true;
                break;
            case E_RoleType.Wizard:
                AddItem2Content(GameDataMgr.Instance.wizardList);
                togWizard.isOn = true;
                break;            
        }
    }

    

    /// <summary>
    /// 将角色物件加载到Content下
    /// </summary>
    /// <param name="lists"></param>
    private void AddItem2Content(List<T_Role> lists)
    {
        foreach (T_Role roleInfo in lists)
        {
            //如果角色被解锁
            if (roleInfo.isUnlock)
            {
                ABResMgr.Instance.LoadResAsync<GameObject>("object", "roleItem", (obj) =>
                {
                    RoleItem roleItem = Instantiate(obj).GetComponent<RoleItem>();
                    roleItem.transform.SetParent(svTavern.content, false);
                    roleItem.InitInfo(roleInfo);
                    roleItems.Add(roleItem);
                });
            }            
        }
    }

    /// <summary>
    /// 更改敌人金币的方法
    /// </summary>
    /// <param name="coin"></param>
    public void ChangeEnemyCoin(long coin)
    {
        if (coin < 0)
            coin = 0;
        txtEnemyCoinNum.text = coin.ToString();
    }

    /// <summary>
    /// 更改玩家金币的方法
    /// </summary>
    /// <param name="coin"></param>
    public void ChangePlayerCoin(long coin)
    {
        if (coin < 0)
            coin = 0;
        txtPlayerCoinNum.text = coin.ToString();
    }

    /// <summary>
    /// 更改敌人行动力的方法
    /// </summary>
    /// <param name="mobility"></param>
    public void ChangeEnemyMobility(int mobility)
    {
        txtEnemyMobilityNum.text = mobility.ToString() + "/5";
        
        imgEnemyMobility.rectTransform.sizeDelta = new Vector2(enemyInitSize.x * mobility / 5 , enemyInitSize.y);
    }

    /// <summary>
    /// 更改玩家行动力的方法
    /// </summary>
    /// <param name="mobility"></param>
    public void ChangePlayerMobility(int mobility)
    {
        txtPlayerMobilityNum.text = mobility.ToString() + "/5";
        
        imgPlayerMobility.rectTransform.sizeDelta = new Vector2(playerInitSize.x*mobility / 5 , playerInitSize.y);
    }

    public void ChangeTip(string name)
    {
        txtTip.gameObject.SetActive(true);
        txtTip.text = name + "已降临";
        Invoke(nameof(HideTip), 1f);
    }

    private void HideTip()
    {
        txtTip.gameObject.SetActive(false);
    }
}
