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
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite")),
				new Die(
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Freeze"),
					Abilities.GetFromName("Freeze")),
				new Die(
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Block"),
					Abilities.GetFromName("Heal"),
					Abilities.GetFromName("Heal"),
					Abilities.GetFromName("Heal")));
	}

	public Fighter GetFighter()
	{
		return new Fighter(Dice, HP, MaxHP, "Player");
	}
}
