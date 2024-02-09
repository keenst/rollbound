public class Player
{
	public const float MaxHP = 20;

	public int DieFragments;
	public Dice Dice;
	public float HP;

	public Fighter GetFighter()
	{
		return new Fighter(Dice, HP, MaxHP, "Player");
	}
}
