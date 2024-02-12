using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CombatSystem : MonoBehaviour
{
	public Text[] dieButtons;
	public GameObject[] diceObjects;

	// TODO: Remove
	public enterCave enterCaveScript;

	public Text playerNameText;
	public Text enemyNameText;

	public Healthbar playerHealthbar;
	public Healthbar enemyHealthbar;

	public SoundEffects soundEffects;
	public AudioSource audioSource;

	private Player _playerStats;

	private Fighter _player;
	private Fighter _enemy;

	// What side each die landed on
	private int[] _dieSidesUp = new int[3];

	// If the player is currently making their first or second pick
	private bool _isFirstPick;

	// The player's picked abilities
	private Ability _firstPick;
	private Ability _secondPick;

	private static Random _rng = new();

	public void OnStart(Player player, Fighter enemy)
	{
		_playerStats = player;
		_player = player.GetFighter();
		_enemy = enemy.Copy();

		UpdateInfo();

		PlayerTurn();
	}

	public void OnPickDie(DieType dieType)
	{
		int sideIndex = _dieSidesUp[(int)dieType];
		Die die = _player.Dice.GetDie(dieType);
		Ability ability = die.abilities[sideIndex];

		if (_isFirstPick)
		{
			_firstPick = ability;
			_isFirstPick = false;

			ThrowDice();
		}
		else
		{
			_secondPick = ability;

			ExecuteAbilities(_firstPick, _secondPick, _player, _enemy);
			EnemyTurn();
		}
	}

	private void ExecuteAbilities(Ability a, Ability b, Fighter user, Fighter target)
	{
		// If magical, handle combining
		if (a is MagicalAbility || b is MagicalAbility)
		{
			MagicalAbility magicalAbility;
			Ability otherAbility;

			if (a is MagicalAbility)
			{
				magicalAbility = (MagicalAbility)a;
				otherAbility = b;
			}
			else
			{
				magicalAbility = (MagicalAbility)b;
				otherAbility = a;
			}

			// If non-magical ability is physical
			if (otherAbility is PhysicalAbility)
			{
				PhysicalAbility physicalAbility = (PhysicalAbility)otherAbility;

				physicalAbility.UseCombo(target, magicalAbility);
			}

			// If non-magical ability is defensive
			if (otherAbility is DefensiveAbility)
			{
				DefensiveAbility defensiveAbility = (DefensiveAbility)otherAbility;

				// TODO: Make this combine with magical
				defensiveAbility.Use(user);
			}

			return;
		}

		// If no magical, use the abilities separately
		if (a is PhysicalAbility)
		{
			((PhysicalAbility)a).Use(target);
		}
		else
		{
			((DefensiveAbility)a).Use(user);
		}

		if (b is PhysicalAbility)
		{
			((PhysicalAbility)b).Use(target);
		}
		else
		{
			((DefensiveAbility)b).Use(user);
		}
	}

	private void ThrowDice()
	{
		for (int i = 0; i < _dieSidesUp.Length; i++)
		{
			_dieSidesUp[i] = _rng.Next(0, 6);

			Ability ability = i switch {
				0 => _player.Dice.GetDie(DieType.Physical).abilities[_dieSidesUp[i]],
				1 => _player.Dice.GetDie(DieType.Magical).abilities[_dieSidesUp[i]],
				2 => _player.Dice.GetDie(DieType.Defensive).abilities[_dieSidesUp[i]],
				_ => null
			};

			if (ability == null)
			{
				Debug.LogError("Something went wrong when getting ability from dice");
			}

			dieButtons[i].text = ability.Name;

			// Disable magical die if a magical ability has already been selected
			if (!_isFirstPick && _firstPick is MagicalAbility)
			{
				diceObjects[1].SetActive(false);
			}
		}
	}

	private void DisableDice()
	{
		foreach (GameObject diceObject in diceObjects)
		{
			diceObject.SetActive(false);
		}
	}

	private void EnableDice()
	{
		foreach (GameObject diceObject in diceObjects)
		{
			diceObject.SetActive(true);
		}
	}

	private void EnemyTurn()
	{
		DisableDice();

		Ability[] abilities = new Ability[2];

		// Get 2 random abilities
		for (int i = 0; i < 2; i++)
		{
			// Roll dice
			int[] dieSidesUp = new int[3];

			for (int j = 0; j < dieSidesUp.Length; j++)
			{
				dieSidesUp[j] = _rng.Next(6);
			}

			// Pick random die
			int die = _rng.Next(2);

			// Get ability
			Ability ability = _enemy.Dice.GetDie((DieType)die).abilities[dieSidesUp[die]];
			abilities[i] = ability;
		}

		ExecuteAbilities(abilities[0], abilities[1], _enemy, _player);

		UpdateInfo();

		PlayerTurn();
	}

	private void PlayerTurn()
	{
		EnableDice();
		ThrowDice();
		_isFirstPick = true;

		UpdateInfo();
	}

	private void EndBattle()
	{
		_playerStats.HP = _player.HP;
		enterCaveScript.combatEnd();
	}

	private void UpdateInfo()
	{
		playerNameText.text = _player.Name;
		enemyNameText.text = _enemy.Name;

		playerHealthbar.UpdateHealth(_player.HP, _player.MaxHP);
		enemyHealthbar.UpdateHealth(_enemy.HP, _enemy.MaxHP);

		if (_player.HP <= 0 || _enemy.HP <= 0)
		{
			EndBattle();
		}
	}

	private void PrintInfo()
	{
		Debug.Log($"Player hp: {_player.HP}");

		DamageType playerBlockingType;
		if (_player.IsBlockingDamage(out playerBlockingType)) Debug.Log("Player is blocking damage");

		Debug.Log($"Enemy hp: {_enemy.HP}");

		DamageType enemyBlockingType;
		if (_enemy.IsBlockingDamage(out enemyBlockingType)) Debug.Log("Enemy is blocking damage");
	}

	private void PlaySound(string name)
	{
		AudioClip[] audioClips = soundEffects.Get(name);
		audioSource.PlayOneShot(audioClips[_rng.Next(audioClips.Length)]);
	}
}
