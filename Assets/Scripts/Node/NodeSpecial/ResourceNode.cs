using System;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;
using Zenject;

[AdvancedInspector]
public class ResuorceNode : NodeNormal, IResuorceSource
{
	[Inject]
	GameControl control;

	protected int playerOwner = -1; 

	public override int Enter(Node node, Army army)
	{
		if(playerOwner != -1 && army.getPlayer() != playerOwner)
			control.getPlayer(playerOwner).Detach(this);
		if(army.getPlayer() != playerOwner)
		{
			playerOwner = army.getPlayer();
			control.getPlayer (playerOwner).Attach(this);
		}
		return base.Enter (node, army);
		playerOwner = army.getPlayer ();
	}
	public override void Leave(Node node, Army army)
	{
		node.setArmy(null);
		army.setNode(null);
	}
	
	public override int getOwner()
	{
		return playerOwner;
	}

	#region IResuorceSource implementation

	public virtual int getFoodGain (Player player)
	{
		return 0;
	}

	public virtual int getMoneyGain (Player player)
	{
		return 0;
	}

	public virtual void gatherResources (Player player)
	{
	}

	#endregion
}

