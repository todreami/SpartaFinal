using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMapEvent : MapEvent
{
    Action BossMapEventF;
    protected override IEnumerator Eventing()
    {
        for (int i = 0; i < mapPhase.Length; i++)
        {
            for (int p = 0; p < mapPhase[i].summonMonster.Length; p++)
            {
                CallMonster(mapPhase[i].summonMonster[p], mapPhase[i].summonPos[p]);
            }
            if (i == 0)
            {
                //TODO 벽 및 몬스터 생성 연출 종료후
                playerAction.enabled = true;
                BossMapEventF = MapMaker.Instance.BossMapEvents.GiveBossEvent();
                BossMapEventF?.Invoke();
            }
            yield return isAllDieMonster;
        }
        ClearEvent();
    }
}
public class BossMapEventList
{
    public Action GiveBossEvent()
    {
        switch (MapMaker.Instance.CurChapterId)
        {
            case 0:
                return NoneEvent;
            case 1:
                return OnWayEvent;
            case 2:
                return ChBoss3;
            default:
                return null;
        }
    }
    void NoneEvent()
    {

    }
    void OnWayEvent()
    {
        OneWayMovePlatform.isStart = true;
    }
    void ChBoss3()
    {

    }
}
