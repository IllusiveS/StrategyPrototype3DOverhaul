using System;

public interface AlgorithmCostInterface
{
	int getRoadCost();
	int getPlainsCost();
	int getForestCost();
	int getCityCost();

	void setRoadCost(AlgorithmCost cost);
	void setPlainsCost(AlgorithmCost cost);
	void setForestCost(AlgorithmCost cost);
	void setCityCost(AlgorithmCost cost);
}


