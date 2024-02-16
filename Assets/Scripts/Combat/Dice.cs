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

	public void ChangeAbility(DieType type, int side, Ability ability)
	{
		switch (type)
		{
			case DieType.Physical:
				_physical.abilities[side] = ability;
				break;
			case DieType.Magical:
				_magical.abilities[side] = ability;
				break;
			case DieType.Defensive:
				_defensive.abilities[side] = ability;
				break;
		}
		Debug.Log("changed ability");
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
