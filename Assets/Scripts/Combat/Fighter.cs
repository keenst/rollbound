using System.Collections.Generic;
using Random = System.Random;

public enum StatusEffect
{
	Burning,
	Frozen,
	Poisoned,
	None
}

public class Fighter
{
	public Dice Dice;
	public float HP;
	public float MaxHP;
	public string Name;
	public StatusEffect StatusEffect = StatusEffect.None;
	public int RoundsWithStatusEffect;

	public List<DefensiveStatus> DefensiveStatuses = new();

	private static Random _rng = new();

	public Fighter(Dice dice, float hp, float maxHp, string name)
	{
		Dice = dice;
		HP = hp;
		MaxHP = maxHp;
		Name = name;
	}

	public Fighter Copy()
	{
		return new Fighter(Dice, HP, MaxHP, Name);
	}

	public DamageInfo ApplyDamage(float damage, DamageType type)
	{
		DefensiveStatus blockStatus;
		if (IsBlockingDamage(out blockStatus) && blockStatus.DamageType == type)
		{
			return new DamageInfo();
		}

		DamageInfo damageInfo = new();

		DefensiveStatus healStatus;
		if (IsHealingDamage(out healStatus) && healStatus.DamageType == type)
		{
			float toHeal = damage * 0.4f;
			damage *= 0.6f;
			HP += toHeal;
			damageInfo.DamageHealed = toHeal;
		}

		if (StatusEffect == StatusEffect.Poisoned)
		{
			damage *= 0.6f;
		}

		HP -= damage;

		// If status effect could be applied
		if (type != DamageType.Physical)
		{
			float chance = damage / 3;
			if (_rng.NextDouble() < chance)
			{
				StatusEffect = (StatusEffect)type;
				RoundsWithStatusEffect = 0;
			}
		}

		switch (type)
		{
			case DamageType.Physical:
				damageInfo.PhysicalDamage = damage;
				break;
			case DamageType.Fire:
				damageInfo.FireDamage = damage;
				break;
			case DamageType.Frost:
				damageInfo.FrostDamage = damage;
				break;
			case DamageType.Poison:
				damageInfo.PoisonDamage = damage;
				break;
		}

		return damageInfo;
	}

	public void ResetDefensiveStatus()
	{
		DefensiveStatuses.Clear();
	}

	public void HealDamage(DamageType type)
	{
		DefensiveStatus status = new();
		status.DefensiveType = DefensiveType.Heal;
		status.DamageType = type;
		DefensiveStatuses.Add(status);
	}

	public bool IsHealingDamage(out DefensiveStatus status)
	{
		status = DefensiveStatuses.Find(s => s.DefensiveType == DefensiveType.Heal);
		return !status.Equals(default(DefensiveStatus));
	}

	public void BlockDamage(DamageType type)
	{
		DefensiveStatus status = new();
		status.DefensiveType = DefensiveType.Block;
		status.DamageType = type;
		DefensiveStatuses.Add(status);
	}

	public bool IsBlockingDamage(out DefensiveStatus status)
	{
		status = DefensiveStatuses.Find(s => s.DefensiveType == DefensiveType.Block);
		return !status.Equals(default(DefensiveStatus));
	}
}
