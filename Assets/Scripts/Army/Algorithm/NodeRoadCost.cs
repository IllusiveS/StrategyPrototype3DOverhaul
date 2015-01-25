using System;

public class NodeRoadCost
{
	public int getCost(AlgorithmCostInterface alg)
	{
		try
		{
			return alg.getRoadCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}

