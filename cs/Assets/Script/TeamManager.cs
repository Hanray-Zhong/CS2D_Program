using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {
    static private int T = 8;
    static private int CT = 9;

    public LayerMask ChooseEnemy(Team team)
    {
        LayerMask enemy = new LayerMask();
        switch (team)                                  //根据设置的层去选择攻击的敌人
        {
            case Team.CT:
                enemy = 1 << T;
                break;
            case Team.T:
                enemy = 1 << CT;
                break;
        }

        return enemy;
    }
	
    public int GetEnemyInt(Team team)
    {
        int enemy_layermask_int = 0;
        switch (team)
        {
            case Team.CT:
                enemy_layermask_int = 8;
                break;
            case Team.T:
                enemy_layermask_int = 9;
                break;
        }
        return enemy_layermask_int;
    }
}
