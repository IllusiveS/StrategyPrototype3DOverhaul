using System;
using System.Collections.Generic;
using AdvancedInspector;
using UnityEngine;
using Zenject;

[System.Serializable]
public class VictoryPointSpecial : NodeNormal, IVictoryPointsObserver
{
    [Inspect, SerializeField]
    protected int victoryPointValue;
    [Inspect, SerializeField]
    protected int playerOwner = -1;
	[Inject]
	GameControl control;

    public override int Enter(Node node, Army army)
    {
		if(playerOwner != -1 && army.getPlayer() != playerOwner)
			control.getPlayer(playerOwner).Detach(this);
		if(army.getPlayer() != playerOwner)
		{
        	playerOwner = army.getPlayer();
			control.getPlayer (playerOwner).Attach (this);
		}
        return base.Enter(node, army);
    }
    public override void Leave(Node node, Army army)
    {
        base.Leave(node, army);
    }
    public override int getOwner()
    {
        return playerOwner;
    }
	public int getPoints (Player player)
	{
		if(player.PlayerLeader == Leader.OLIVER)
			return victoryPointValue * 2;
		return victoryPointValue;
	}
}
