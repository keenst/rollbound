using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public struct DamageInfo
{
	public float PhysicalDamage;
	public float FireDamage;
	public float FrostDamage;
	public float PoisonDamage;
	public float DamageHealed;

	public static DamageInfo operator +(DamageInfo a, DamageInfo b)
	{
		DamageInfo newInfo;
		newInfo.PhysicalDamage = a.PhysicalDamage + b.PhysicalDamage;
		newInfo.FireDamage = a.FireDamage + b.FireDamage;
		newInfo.FrostDamage = a.FrostDamage + b.FrostDamage;
		newInfo.PoisonDamage = a.PoisonDamage + b.PoisonDamage;
		newInfo.DamageHealed = a.DamageHealed + b.DamageHealed;
		return newInfo;
	}
}

public class CombatSystem : MonoBehaviour
{
	public topDownMove topDownMove;
	public RewardController rewardController;

	public GameObject[] diceObjects;
	public DieButton[] dieButtons;
	public AbilityImages abilityImages;

	public Image playerCard1;
	public Image playerCard2;
	public Image enemyCard1;
	public Image enemyCard2;

	public Image playerCardRarity1;
	public Image playerCardRarity2;
	public Image enemyCardRarity1;
	public Image enemyCardRarity2;

	public Image[] playerStatusCards1;
	public Image[] playerStatusCards2;
	public Image[] enemyStatusCards1;
	public Image[] enemyStatusCards2;

	public Text playerDamageInfoText;
	public Text enemyDamageInfoText;

	// TODO: Remove
	public topDownMove enterCaveScript;

	public Text playerNameText;
	public Text enemyNameText;

	public Healthbar playerHealthbar;
	public Healthbar enemyHealthbar;

	public SoundEffects soundEffects;
	public AudioSource audioSource;

	private Player _playerStats;

	private Fighter _player;
	private Fighter _enemy;

	private DamageInfo _playerDamageInfo;
	private DamageInfo _enemyDamageInfo;

	// What side each die landed on
	private int[] _dieSidesUp = new int[3];

	// If the player is currently making their first or second pick
	private bool _isFirstPick;

	// The player's picked abilities
	private Ability _firstPick;
	private Ability _secondPick;

	private static Random _rng = new();

	// TODO: Remove
	public void Start()
	{
		OnStart(new Player(), Enemies.GetFromName("Test"));
	}

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

			ExecuteAbilities(_firstPick, _secondPick, _player, _enemy, ref _playerDamageInfo, ref _enemyDamageInfo);

			// Display both abilities
			playerCard1.enabled = true;
			playerCard2.enabled = true;
			playerCard1.sprite = abilityImages.Get(_firstPick.Name);
			playerCard2.sprite = abilityImages.Get(_secondPick.Name);

			playerCardRarity1.enabled = true;
			playerCardRarity2.enabled = true;
			playerCardRarity1.sprite = abilityImages.GetRarityOverlay(_firstPick.Rarity);
			playerCardRarity2.sprite = abilityImages.GetRarityOverlay(_secondPick.Rarity);

			DisableDice();

			if (_player.ToHeal > 0)
			{
				_player.HP = Mathf.Min(_player.HP + _player.ToHeal, _player.MaxHP);
				_playerDamageInfo.DamageHealed += _player.ToHeal;
				_player.ToHeal = 0;
			}

			bool gameOver = UpdateInfo();
			if (gameOver) return;

			Invoke("EnemyTurn", 1.5f);
		}
	}

	private void ExecuteAbilities(Ability a, Ability b, Fighter user, Fighter target, ref DamageInfo userDamageInfo, ref DamageInfo targetDamageInfo)
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

				targetDamageInfo = physicalAbility.UseCombo(user, target, magicalAbility);
			}

			// If non-magical ability is defensive
			if (otherAbility is DefensiveAbility)
			{
				DefensiveAbility defensiveAbility = (DefensiveAbility)otherAbility;

				userDamageInfo = defensiveAbility.UseCombo(user, magicalAbility);
			}

			return;
		}

		// If no magical, use the abilities separately
		if (a is PhysicalAbility)
		{
			targetDamageInfo = ((PhysicalAbility)a).Use(user, target);
		}
		else
		{
			userDamageInfo = ((DefensiveAbility)a).Use(user);
		}

		if (b is PhysicalAbility)
		{
			targetDamageInfo += ((PhysicalAbility)b).Use(user, target);
		}
		else
		{
			userDamageInfo += ((DefensiveAbility)b).Use(user);
		}
	}

	private void ThrowDice()
	{
		EnableDice();

		// Disable magical die if a magical ability has already been selected
		if (!_isFirstPick && _firstPick is MagicalAbility)
		{
			diceObjects[1].SetActive(false);
		}

		for (int i = 0; i < _dieSidesUp.Length; i++)
		{
			_dieSidesUp[i] = _rng.Next(0, 6);

			Ability ability = _player.Dice.GetDie((DieType)i).abilities[_dieSidesUp[i]];

			if (ability == null)
			{
				Debug.LogError("Something went wrong when getting ability from dice");
			}

			dieButtons[i].StartRolling();
			Sprite overlay = abilityImages.GetOverlay(ability.Name);
			dieButtons[i].StopInMS(overlay, 800);
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
		if (++_enemy.RoundsWithStatusEffect > 1 && _enemy.StatusEffect != StatusEffect.None)
		{
			_enemy.StatusEffect = StatusEffect.None;
		}

		if (_enemy.StatusEffect == StatusEffect.Burning)
		{
			_enemyDamageInfo += _enemy.ApplyDamage(1.5f, DamageType.Fire);
		}

		playerCard1.enabled = false;
		playerCard2.enabled = false;
		playerCardRarity1.enabled = false;
		playerCardRarity2.enabled = false;

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

			// Make sure enemy doesn't pick 2 magical abilities in a row and that it doesn't pick a magical ability if it doesn't have any
			if (i == 1 && die == 1 || _enemy.Dice.GetDie(DieType.Magical) == null)
			{
				die += _rng.Next(1) == 0 ? 1 : -1;
			}

			// Get ability
			Ability ability = _enemy.Dice.GetDie((DieType)die).abilities[dieSidesUp[die]];
			abilities[i] = ability;
		}

		ExecuteAbilities(abilities[0], abilities[1], _enemy, _player, ref _enemyDamageInfo, ref _playerDamageInfo);

		if (_enemy.ToHeal > 0)
		{
			_enemy.HP = Mathf.Min(_enemy.HP + _enemy.ToHeal, _enemy.MaxHP);
			_enemyDamageInfo.DamageHealed += _enemy.ToHeal;
			_enemy.ToHeal = 0;
		}

		UpdateInfo();

		_player.ResetDefensiveStatus();

		enemyCard1.enabled = true;
		enemyCard2.enabled = true;
		enemyCard1.sprite = abilityImages.Get(abilities[0].Name);
		enemyCard2.sprite = abilityImages.Get(abilities[1].Name);

		enemyCardRarity1.enabled = true;
		enemyCardRarity2.enabled = true;
		enemyCardRarity1.sprite = abilityImages.GetRarityOverlay(abilities[0].Rarity);
		enemyCardRarity2.sprite = abilityImages.GetRarityOverlay(abilities[1].Rarity);

		Invoke("PlayerTurn", 1.5f);
	}

	private void PlayerTurn()
	{
		if (_player.StatusEffect == StatusEffect.Burning)
		{
			_playerDamageInfo += _player.ApplyDamage(1.5f, DamageType.Fire);
		}

		enemyCard1.enabled = false;
		enemyCard2.enabled = false;
		enemyCardRarity1.enabled = false;
		enemyCardRarity2.enabled = false;

		EnableDice();
		_isFirstPick = true;
		ThrowDice();

		UpdateInfo();
		_enemy.ResetDefensiveStatus();
	}

	private void LoseBattle()
	{
		topDownMove.combatLose();
	}

	private void WinBattle()
	{
		_playerStats.HP = _player.HP;
		rewardController.OpenReward(_playerStats);
		topDownMove.combatEnd();
	}

	private bool UpdateInfo()
	{
		playerNameText.text = _player.Name;
		enemyNameText.text = _enemy.Name;

		playerHealthbar.UpdateHealth(_player.HP, _player.MaxHP, _player.StatusEffect);
		enemyHealthbar.UpdateHealth(_enemy.HP, _enemy.MaxHP, _enemy.StatusEffect);

		UpdateStatusCards(playerStatusCards1, playerStatusCards2, _player);
		UpdateStatusCards(enemyStatusCards1, enemyStatusCards2, _enemy);

		UpdateDamageInfo(playerDamageInfoText, _playerDamageInfo);
		UpdateDamageInfo(enemyDamageInfoText, _enemyDamageInfo);

		// TODO: maybe (re)move these?
		_playerDamageInfo = new DamageInfo();
		_enemyDamageInfo = new DamageInfo();

		if (_player.HP <= 0)
		{
			print("-2");
			LoseBattle();
			return true;
		}

		if (_enemy.HP <= 0)
		{
			WinBattle();
			return true;
		}

		return false;
	}

	private void UpdateDamageInfo(Text text, DamageInfo info)
	{
		string newText = "";

		if (info.PhysicalDamage > 0)
		{
			newText += $"-{info.PhysicalDamage}\n";
		}

		if (info.FireDamage > 0)
		{
			newText += $"<color=orange>-{info.FireDamage}</color>\n";
		}

		if (info.FrostDamage > 0)
		{
			newText += $"<color=blue>-{info.FrostDamage}</color>\n";
		}

		if (info.PoisonDamage > 0)
		{
			newText += $"<color=green>-{info.PoisonDamage}</color>\n";
		}

		if (info.DamageHealed > 0)
		{
			newText += $"<color=magenta>+{info.DamageHealed}</color>\n";
		}

		newText = newText.TrimEnd('\r', '\n');

		text.text = newText;
	}

	private void UpdateStatusCards(Image[] cards1, Image[] cards2, Fighter fighter)
	{
		for (int i = 0; i < cards1.Length; i++)
		{
			Image card1 = cards1[i];
			Image card2 = cards2[i];

			card1.enabled = false;
			card2.enabled = false;

			if (fighter.DefensiveStatuses.Count <= i)
			{
				return;
			}

			card1.enabled = true;

			DefensiveStatus status = fighter.DefensiveStatuses[i];

			switch (status.DefensiveType)
			{
				case DefensiveType.Block:
					card1.sprite = abilityImages.Get("Parry");
					break;
				case DefensiveType.Heal:
					card1.sprite = status.Strength switch
					{
						Strength.Weak => abilityImages.Get("Battle Boots"),
						Strength.Medium => abilityImages.Get("Broken Helmet"),
						Strength.Strong => abilityImages.Get("Golden Chestplate"),
						_ => null
					};
					break;
			}

			if (status.DamageType != DamageType.Physical)
			{
				card2.enabled = true;

				card2.sprite = status.DamageType switch
				{
					DamageType.Fire => abilityImages.Get("Ignite"),
					DamageType.Frost => abilityImages.Get("Freeze"),
					DamageType.Poison => abilityImages.Get("Poison"),
					_ => null
				};
			}
		}
	}

	private void PlaySound(string name)
	{
		AudioClip[] audioClips = soundEffects.Get(name);
		audioSource.PlayOneShot(audioClips[_rng.Next(audioClips.Length)]);
	}
}
