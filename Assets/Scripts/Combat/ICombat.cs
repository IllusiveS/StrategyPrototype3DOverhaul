public interface ICombat
{
	ICombat getInstance();

	void setUp(UCombat unity, Army atk, Army def);

	Army CalculateWinner();
	void BeginCombat(Army atk, Army def);
	void EndCombat();
}
