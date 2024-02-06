using UnityEngine;

public enum DieType
{
	Physical,
	Magical,
	Defensive
}

public class Dice
{
	private Die _physical;
	private Die _magical;
	private Die _defensive;

	public Dice(Die physical, Die magical, Die defensive)
	{
		_physical = physical;
		_magical = magical;
		_defensive = defensive;
	}

	public Die GetDie(DieType type)
	{
		switch (type)
		{
			case DieType.Physical:
				return _physical;
			case DieType.Magical:
				return _magical;
			case DieType.Defensive:
				return _defensive;
		}

		Debug.Log($"Die of type {type} not found");
		return null;
	}
}

public class Die
{
	public Ability[] abilities;

	public Die(Ability a, Ability b, Ability c, Ability d, Ability e, Ability f)
	{
		abilities = new[] { a, b, c, d, e, f };
	}
}
