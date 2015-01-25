using System;

public class NodeForestCost
{
	public int getCost(AlgorithmCostInterface alg)
	{
		try
		{
			return alg.getForestCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}

