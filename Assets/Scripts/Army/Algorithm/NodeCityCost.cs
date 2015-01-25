using System;

public class NodeCityCost 
{
	public int getCost(AlgorithmCostInterface alg)
	{
		try
		{
			return alg.getCityCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}

