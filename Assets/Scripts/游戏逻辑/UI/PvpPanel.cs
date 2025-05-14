using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvpPanel : BasePanel
{
    private Toggle togCloseCombat;
    private Toggle togArcher;
    private Toggle togWizard;
    

    private ScrollRect svTavern;

    private Text txtplayer1CoinNum;
    private Text txtplayer2CoinNum;

    private Text txtTimePlayer1;
    private Text txtTimePlayer2;

    private List<RoleItem> roleItems = new List<RoleItem>();

    public Text txtTips1;
    public Text txtTips2;

    public Text txtTime;

    [System.Serializable]
    public class PlayerCountdown
    {
        public Text countdownText;
        public float currentTime;
        public Coroutine countdownCoroutine;
        public bool isCounting;
    }

    [Header("倒计时设置")]
    public float countdownTime = 15f;
    public string finishText = "时间到!";

    public PlayerCountdown player1 = new PlayerCountdown();
    public PlayerCountdown player2 = new PlayerCountdown();

    [Header("全局倒计时设置")]
    public float totalGameTime = 600f; // 10分钟 = 600秒
    private float remainingGameTime;
    private Coroutine gameCountdownCoroutine;
    private bool isGameCounting = false;

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
        //ChangeType(E_RoleType.CloseCombat);
        togCloseCombat.isOn = true;
        StartGameCountdown();
        StartPlayer1();
    }

    private void Start()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();


        svTavern = GetControl<ScrollRect>("svTavern");
        
        togCloseCombat = GetControl<Toggle>("togCloseCombat");
        togArcher = GetControl<Toggle>("togArcher");
        togWizard = GetControl<Toggle>("togWizard");
        
        txtplayer1CoinNum = GetControl<Text>("txtplayer1CoinNum");
        txtplayer2CoinNum= GetControl<Text>("txtplayer2CoinNum");
        txtTimePlayer1= GetControl<Text>("txtTimePlayer1");
        txtTimePlayer2 = GetControl<Text>("txtTimePlayer2");

        //先隐藏提示文字
        txtTips1.gameObject.SetActive(false);
        txtTips2.gameObject.SetActive(false);

        remainingGameTime = totalGameTime;
        UpdateGameTimeDisplay();
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch (btnName)
        {
            case "btnRetreat":
                GameObjectMgr.Instance.playerRoleInfo = null;
                //记录金币，返回开始场景
                UIMgr.Instance.HidePanel<PvpPanel>();
                GameObjectMgr.Instance.ClearPiece();
                MusicMgr.Instance.ClearSound();
                PoolMgr.Instance.ClearPool();
                SceneMgr.Instance.LoadSceneAsyn("开始场景", () =>
                {
                    
                });
                break;
            case "btnSetting":
                UIMgr.Instance.ShowPanel<SettingPanel>();
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
    /// 改变玩家1金币的方法
    /// </summary>
    /// <param name="coin"></param>
    public void ChangePlayer1Coin(int coin)
    {
        txtplayer1CoinNum.text = coin.ToString();
    }

    /// <summary>
    /// 改变玩家2金币的方法
    /// </summary>
    /// <param name="coin"></param>
    public void ChangePlayer2Coin(int coin)
    {
        txtplayer2CoinNum.text = coin.ToString();
    }

    #region 玩家倒计时
    // 玩家1控制方法
    public void StartPlayer1() => StartCountdown(player1);
    public void StopPlayer1() => StopCountdown(player1);
    public void ResetPlayer1() => ResetCountdown(player1);

    // 玩家2控制方法
    public void StartPlayer2() => StartCountdown(player2);
    public void StopPlayer2() => StopCountdown(player2);
    public void ResetPlayer2() => ResetCountdown(player2);

    // 同时控制两个玩家
    public void StartBoth() 
    { 
        StartPlayer1(); 
        StartPlayer2(); 
    }
    public void StopBoth() 
    { 
        StopPlayer1(); 
        StopPlayer2(); 
    }
    public void ResetBothCountdowns() 
    { 
        ResetPlayer1(); 
        ResetPlayer2(); 
    }

    // 通用倒计时控制（去掉 ref）
    private void StartCountdown(PlayerCountdown player)
    {
        //先停止之前的携程
        if (player.countdownCoroutine != null)
            StopCoroutine(player.countdownCoroutine);

        player.currentTime = countdownTime;
        player.countdownCoroutine = StartCoroutine(CountdownRoutine(player));

        // 根据是哪个玩家触发不同事件
        if (player == player1)
        {
            // 这里可以添加玩家1特定的逻辑
            txtTips1.gameObject.SetActive(true);
            //设置回合
            GameDataMgr.Instance.PlayerRound = 1;
        }
        else if (player == player2)
        {
            // 这里可以添加玩家2特定的逻辑
            txtTips2.gameObject.SetActive(true);
            //设置回合
            GameDataMgr.Instance.PlayerRound = 2;
        }
    }

    private void StopCountdown(PlayerCountdown player)
    {
        if (player.countdownCoroutine != null)
            StopCoroutine(player.countdownCoroutine);
        player.isCounting = false;
        
    }

    private void ResetCountdown(PlayerCountdown player)
    {
        StopCountdown(player);
        player.currentTime = countdownTime;
        UpdateDisplay(player);
    }

    // 倒计时协程（去掉 ref）
    IEnumerator CountdownRoutine(PlayerCountdown player)
    {
        player.isCounting = true;
        while (player.currentTime > 0)
        {
            UpdateDisplay(player);
            yield return new WaitForSeconds(1f);
            player.currentTime--;
        }
        player.currentTime = 0;
        UpdateDisplay(player);
        player.isCounting = false;
        OnCountdownFinished(player);
    }

    /// <summary>
    /// 更新显示（去掉 ref）
    /// </summary>
    /// <param name="player"></param>
    private void UpdateDisplay(PlayerCountdown player)
    {
        if (player.countdownText != null)
        {
            player.countdownText.text = Mathf.CeilToInt(player.currentTime).ToString();
            //player.countdownText.color = (player.currentTime <= 5f) ? Color.red : Color.white;
        }
    }

    /// <summary>
    /// 倒计时结束处理（去掉 ref）
    /// </summary>
    /// <param name="player"></param>
    private void OnCountdownFinished(PlayerCountdown player)
    {
        if (player.countdownText != null)
            player.countdownText.text = finishText;

        // 根据是哪个玩家触发不同事件
        if (player == player1)
        {
            // 这里可以添加玩家1特定的逻辑
            //切换到玩家2的回合
            StartPlayer2();
            //隐藏提示
            txtTips1.gameObject.SetActive(false);
        }
        else if (player == player2)
        {
            // 这里可以添加玩家2特定的逻辑
            //切换到玩家1的回合
            StartPlayer1();
            //隐藏提示
            txtTips2.gameObject.SetActive(false);
        }
    }
    #endregion

    #region 全局倒计时
    // 开始全局游戏倒计时
    public void StartGameCountdown()
    {
        if (isGameCounting && gameCountdownCoroutine != null)
        {
            StopCoroutine(gameCountdownCoroutine);
        }

        isGameCounting = true;
        gameCountdownCoroutine = StartCoroutine(GameCountdownRoutine());
    }

    // 暂停全局游戏倒计时
    public void StopGameCountdown()
    {
        if (gameCountdownCoroutine != null)
        {
            StopCoroutine(gameCountdownCoroutine);
        }
        isGameCounting = false;
    }

    // 重置全局游戏倒计时
    public void ResetGameCountdown()
    {
        StopGameCountdown();
        remainingGameTime = totalGameTime;
        UpdateGameTimeDisplay();
    }

    // 全局倒计时协程
    IEnumerator GameCountdownRoutine()
    {
        while (remainingGameTime > 0)
        {
            UpdateGameTimeDisplay();
            yield return new WaitForSeconds(1f);
            remainingGameTime -= 1f;

            // 最后1分钟变红色
            if (remainingGameTime <= 60f)
            {
                txtTime.color = Color.red;
            }
        }

        remainingGameTime = 0;
        UpdateGameTimeDisplay();
        isGameCounting = false;
        OnGameTimeFinished();
    }

    // 使用SecondToMS函数更新显示
    private void UpdateGameTimeDisplay()
    {
        if (txtTime != null)
        {
            txtTime.text = TextUtil.SecondToMS(Mathf.FloorToInt(remainingGameTime));
        }
    }

    // 全局倒计时结束处理
    private void OnGameTimeFinished()
    {
        if (txtTime != null)
        {
            txtTime.text = "游戏结束";
        }

        // 这里可以添加游戏结束的逻辑
        Debug.Log("10分钟游戏时间到，游戏结束");

        // 例如：停止所有玩家倒计时
        StopBoth();
        StopGameCountdown();
        // 显示游戏结束UI或返回主菜单等
        GameLevelMgr.Instance.CheckTimeEndPvp();
    }
    #endregion

    /// <summary>
    /// 玩家1落子结束的逻辑
    /// </summary>
    public void Player1EndOfDrop()
    {
        StopPlayer1();
        StartPlayer2();
        txtTips1.gameObject.SetActive(false);
    }

    /// <summary>
    /// 玩家2落子结束的逻辑
    /// </summary>
    public void Player2EndOfDrop()
    {
        StopPlayer2();
        StartPlayer1();
        txtTips2.gameObject.SetActive(false);
    }
}

