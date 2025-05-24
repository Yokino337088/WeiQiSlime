using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    
    void Start()
    {
        MusicMgr.Instance.PlayBKMusic("Crossroads");

        if (GameLevelMgr.Instance.nowLevelInfo.f_gkkjsl != 0)
            StartCoroutine(PlacePiece());
    } 
    
    private IEnumerator PlacePiece()
    {
        //print("函数被调用");
        UIMgr.Instance.ShowPanel<LoadingPanel>();
        for (int i = 0; i < GameLevelMgr.Instance.nowLevelInfo.f_gkkjsl; i++)
        {
            ChessBoard.chessBoard.PlaceRandomly();
            yield return new WaitForSeconds(0.1f);
        }
        UIMgr.Instance.HidePanel<LoadingPanel>();
    }
}
