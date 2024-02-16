using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public static class Enemies
{
	private static List<Fighter> _enemies = new();
	private static Random rng = new();
	private static bool _isInitialized;

	public static Fighter GetFromName(string name)
	{
		TryInit();

		foreach (Fighter fighter in _enemies)
		{
			if (fighter.Name == name)
			{
				return fighter;
			}
		}

		Debug.LogError($"No enemy with name {name} found");
		return null;
	}

	private static void Init()
	{
		// Bat
		_enemies.Add(new Fighter(
			name: "Bat",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Rock Throw"),
					Abilities.GetFromName("Rock Throw"),
					Abilities.GetFromName("Rock Throw")),
				new Die(
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"))),
			maxHp: 20,
			hp: 20));

		// Zombie
		_enemies.Add(new Fighter(
			name: "Zombie",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Sickle")),
				new Die(
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"))),
			maxHp: 20,
			hp: 20));

		// Burning Zombie
		_enemies.Add(new Fighter(
			name: "Burning Zombie",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Sickle")),
				new Die(
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle boots"),
					Abilities.GetFromName("Broken Helmet"))),
			maxHp: 20,
			hp: 20));

		// Lizard
		_enemies.Add(new Fighter(
			name: "Lizard",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Bite")),
				new Die(
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"))),
			maxHp: 20,
			hp: 20));

		// Spitter
		_enemies.Add(new Fighter(
			name: "Spitter",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Rock Throw"),
					Abilities.GetFromName("Rock Throw"),
					Abilities.GetFromName("Rock Throw")),
				new Die(
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Herbal Tonic"))),
			maxHp: 20,
			hp: 20));

		// Physical Boss
		_enemies.Add(new Fighter(
			name: "Physical Boss",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch"),
					Abilities.GetFromName("Punch")),
				null,
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Herbal Tonic"))),
			maxHp: 20,
			hp: 20));

		// Magical boss
		_enemies.Add(new Fighter(
			name: "Magical boss",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Crossbow"),
					Abilities.GetFromName("Crossbow"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Rock Throw"),
					Abilities.GetFromName("Rock Throw")),
				new Die(
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Freeze"),
					Abilities.GetFromName("Freeze"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Golden Chestplate"))),
			maxHp: 20,
			hp: 20));

		// Final boss
		_enemies.Add(new Fighter(
			name: "Final boss",
			dice: new Dice(
				new Die(
					Abilities.GetFromName("Crossbow"),
					Abilities.GetFromName("Rock Throw"),
					Abilities.GetFromName("Bite"),
					Abilities.GetFromName("Sickle"),
					Abilities.GetFromName("Stab"),
					Abilities.GetFromName("Diabolical Smite")),
				new Die(
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Ignite"),
					Abilities.GetFromName("Freeze"),
					Abilities.GetFromName("Freeze"),
					Abilities.GetFromName("Poison"),
					Abilities.GetFromName("Poison")),
				new Die(
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Battle Boots"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Broken Helmet"),
					Abilities.GetFromName("Golden Chestplate"))),
			maxHp: 20,
			hp: 20));
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
