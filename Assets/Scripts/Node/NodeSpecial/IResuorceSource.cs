using UnityEngine;
using System.Collections;

public interface IResuorceSource{

	void gatherResources(Player player);
	int getFoodGain(Player player);
	int getMoneyGain(Player player);

}
