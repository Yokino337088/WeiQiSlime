using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Text txtTip;

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    public void ChangeText()
    {
        if (GameLevelMgr.Instance.nowLevelInfo.f_gkname == "新手教学1")
        {
            txtTip.text = "教学1：落子\r\n在敌方棋子的上下左右各落一颗棋子，对方将陷入被包围状态，受到的伤害增加4倍\r\n尝试击败敌人吧\r\n(点击下方滑动窗口内的棋子选中棋子，然后点击棋盘上的某一个位置就可以在该位置落子)";
        }
        if (GameLevelMgr.Instance.nowLevelInfo.f_gkname == "新手教学2")
        {
            txtTip.text = "教学2：移动\r\n点击棋盘上的一颗棋子，可以进行上下左右移动的操作，每次移动消耗1点行动力，优势时可节省消耗以消灭敌方残余棋子，若劣势时则建议利用行动力增加己方棋子的数量\r\n尝试击败敌人吧\r\n（点击棋盘上的一颗棋子，该棋子周围会出现可移动的标识点，再次点击这些标识点所在的位置即可移动）";
        }
    }
}
