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
		_abilities.Add(new PhysicalAbility("Punch", CardRarity.Common, 1.5f, "Don’t know why you’d need to learn how to punch…but allow me to demonstrate", "Deals minor physical damage", 10));
		_abilities.Add(new PhysicalAbility("Bite", CardRarity.Common, 2, "Bite might be an understatement but…", "Bite deals decent physical damage", 10));
		_abilities.Add(new PhysicalAbility("Crossbow", CardRarity.Common, 2.5f, "For killing more than just a pesky fly…", "Deals decent physical damage. Guaranteed to hit flying enemies, unlike normal physical attacks", 10));
		_abilities.Add(new PhysicalAbility("Sickle", CardRarity.Rare, 3, "Not for cutting hay I take it…?", "Deals decent physical damage", 20));
		_abilities.Add(new PhysicalAbility("Stab", CardRarity.Rare, 4,  "Who doesn’t like a good shank…?", "Deals minor physical damage. Has a 25% chance to deal major damage.", 20));
		_abilities.Add(new PhysicalAbility("Rock Throw", CardRarity.Rare, 3, "Don’t have a sling, use your hand instead…", "Deals minor physical damage. Guaranteed to hit flying enemies, unlike normal physical attacks.", 20));
		_abilities.Add(new PhysicalAbility("Diabolical Smite", CardRarity.Legendary, 6, "When overkill just isn’t enough…", "Deals major physical damage.", 50));

		_abilities.Add(new MagicalAbility("Poison", CardRarity.Common, Element.Poison, 0.4f, "It’s poison… What else is there to say?", "Poisons enemies, poisoned enemies take more damage.", 10));
		_abilities.Add(new MagicalAbility("Ignite", CardRarity.Common, Element.Fire, 0.4f, "Playing with fire is definitely a good idea…", "Deals damage to enemies overtime.", 10));
		_abilities.Add(new MagicalAbility("Freeze", CardRarity.Common, Element.Frost, 0.4f, "A good way to send more than just a shiver down someone’s spine...", "Freezes enemies, frozen enemies don’t hit as hard.", 10));
		_abilities.Add(new MagicalAbility("Magical Staff", CardRarity.Legendary, Element.Holy, 1, "From dust to ashes…", "Deals major magical damage.", 50));

		_abilities.Add(new DefensiveAbility("Herbal Tonic", CardRarity.Common, DefensiveType.HerbalTonic, "Feeling a bit under the weather are we…? Don’t worry, I’m sure this will fix you right up…", "Cures minor wounds like cuts and bruises. Is also a catalyst for stronger medications.", 10));
		_abilities.Add(new DefensiveAbility("Battle Boots", CardRarity.Common, DefensiveType.Heal, "A bit too big for you, but it’s better than those sandals you’re wearing", "Absorbs minor amount of damage.", 10));
		_abilities.Add(new DefensiveAbility("Parry", CardRarity.Rare, DefensiveType.Block, "En garde…", "Prevents the attack of a single enemy.", 20));
		_abilities.Add(new DefensiveAbility("Broken Helmet", CardRarity.Rare, DefensiveType.Heal, "Keeps the noggin intact…Also good for covering up your ugly mug…", "Absorbs decent amount of damage.", 20));
		_abilities.Add(new DefensiveAbility("Golden Chestplate", CardRarity.Legendary, DefensiveType.Heal, "Certainly better than the rags you’re wearing…", "Absorbs major amount of damage.", 50));
		//_abilities.Add(new DefensiveAbility("Counter", CardRarity.Rare, DefensiveType.Counter));
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
