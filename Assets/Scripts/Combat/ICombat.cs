public interface ICombat
{
	void setUp(UCombat unity, Army atk, Army def);

	Army CalculateWinner();
	void BeginCombat(Army atk, Army def);
	void EndCombat();
}
