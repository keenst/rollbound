using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CombatSystem : MonoBehaviour
{
	public Text[] dieButtons;
	public GameObject[] diceObjects;

	private Fighter _player;
	private Fighter _enemy;

	// What side each die landed on
	// 0 = physical
	// 1 = magical
	// 2 = defensive
	private int[] _dieSidesUp = new int[3];

	// If the player is currently making their first or second pick
	private bool _isFirstPick;

	// The player's picked abilities
	private Ability _firstPick;
	private Ability _secondPick;

	// TODO: Remove
	public void Start()
	{
		Dice playerDice = new(
			new Die(
				Abilities.GetFromName("Bite"),
				Abilities.GetFromName("Bite"),
				Abilities.GetFromName("Bite"),
				Abilities.GetFromName("Rock Throw"),
				Abilities.GetFromName("Rock Throw"),
				Abilities.GetFromName("Rock Throw")),
			new Die(
				Abilities.GetFromName("Ignite"),
				Abilities.GetFromName("Ignite"),
				Abilities.GetFromName("Ignite"),
				Abilities.GetFromName("Freeze"),
				Abilities.GetFromName("Freeze"),
				Abilities.GetFromName("Freeze")),
			new Die(
				Abilities.GetFromName("Heal"),
				Abilities.GetFromName("Heal"),
				Abilities.GetFromName("Heal"),
				Abilities.GetFromName("Block"),
				Abilities.GetFromName("Block"),
				Abilities.GetFromName("Block"))
		);

		Dice enemyDice = playerDice;

		Fighter player = new(playerDice);
		Fighter enemy = new(enemyDice);

		OnStart(player, enemy);
	}

	public void OnStart(Fighter player, Fighter enemy)
	{
		_player = player;
		_enemy = enemy;

		_isFirstPick = true;

		EnableDice();
		ThrowDice();
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
			DisableDice();
			ExecuteAbilities(_firstPick, _secondPick, _player, _enemy);
		}
	}

	private void ExecuteAbilities(Ability a, Ability b, Fighter user, Fighter target)
	{
		// TODO:
		// If there are no synergies, use both abilities separately
		// If there are syngergies, figure it out
	}

	private void ThrowDice()
	{
		Random rng = new();

		for (int i = 0; i < _dieSidesUp.Length; i++)
		{
			_dieSidesUp[i] = rng.Next(0, 6);
			dieButtons[i].text = _dieSidesUp[i].ToString();
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
}
