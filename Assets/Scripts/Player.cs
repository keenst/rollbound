public class Player
{
	public const float MaxHP = 20;

	public int DieFragments;
	public Dice Dice;
	public float HP = MaxHP;

	public Player()
	{
		Dice = new Dice(
				new Die(
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite")),
				new Die(
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite")),
				new Die(
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block")));
		HP = 20;
	}

	public Fighter GetFighter()
	{
		return new Fighter(Dice, HP, MaxHP, "Player");
	}
}
