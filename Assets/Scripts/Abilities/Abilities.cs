using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class Abilities
{
	private static List<Ability> _abilities = new();
	private static Random rng = new();
	private static bool _isInitialized;

	public static Ability GetFromName(string name)
	{
		TryInit();

		foreach (Ability ability in _abilities)
		{
			if (ability.Name == name)
			{
				return ability;
			}
		}

		Debug.LogError($"No ability with name {name} found");
		return null;
	}

	public static Ability GetFromRarity(CardRarity rarity)
	{
		TryInit();

		List<Ability> matchingRarity = new();
		foreach (Ability ability in _abilities)
		{
			if (ability.Rarity == rarity)
			{
				matchingRarity.Add(ability);
			}
		}

		int randomIndex = rng.Next(matchingRarity.Count);
		return matchingRarity[randomIndex];
	}

	private static void Init()
	{
        _abilities.Add(new PhysicalAbility("Punch", CardRarity.Common, 3));
        _abilities.Add(new PhysicalAbility("Bite", CardRarity.Common, 5));
        _abilities.Add(new PhysicalAbility("Crossbow", CardRarity.Rare, 5));
        _abilities.Add(new PhysicalAbility("Slash", CardRarity.Rare, 5));
        _abilities.Add(new PhysicalAbility("Stab", CardRarity.Legendary, 9));
        _abilities.Add(new PhysicalAbility("Rock Throw", CardRarity.Rare, 8));

        _abilities.Add(new MagicalAbility("Poison", CardRarity.Common));
        _abilities.Add(new MagicalAbility("Ignite", CardRarity.Common));
		_abilities.Add(new MagicalAbility("Freeze", CardRarity.Common));

        _abilities.Add(new DefensiveAbility("Heal", CardRarity.Common, DefensiveType.Block));
		_abilities.Add(new DefensiveAbility("Block", CardRarity.Rare, DefensiveType.Block));
        _abilities.Add(new DefensiveAbility("I-Will", CardRarity.Rare, DefensiveType.Block));


    }

    private static void TryInit()
	{
		if (!_isInitialized)
		{
			Init();
			_isInitialized = true;
		}
	}
}
