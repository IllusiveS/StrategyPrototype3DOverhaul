using System;

public class NodePlainsCost
{
	public int getCost(AlgorithmCostInterface alg)
	{
		try
		{
			return alg.getPlainsCost ();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
}
