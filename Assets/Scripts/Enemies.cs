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
		// Test enemy
		_enemies.Add(new Fighter(
			name: "Test",
			dice: new Dice(
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
					Abilities.GetFromName("Block"))),
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
