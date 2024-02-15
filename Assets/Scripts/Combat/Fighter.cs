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
	public float ToHeal;
	public DamageType Weakness;

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

		DefensiveStatus absorbStatus;
		if (IsAbsorbingDamage(out absorbStatus) && absorbStatus.DamageType == type)
		{
			float toHeal = damage * absorbStatus.Strength switch
			{
				Strength.Weak => 0.4f,
				Strength.Medium => 0.8f,
				Strength.Strong => 1.4f,
				_ => 0
			};

			damage *= absorbStatus.Strength switch
			{
				Strength.Weak => 0.6f,
				Strength.Medium => 0.4f,
				Strength.Strong => 0.0f,
				_ => 0
			};

			HP += toHeal;
			damageInfo.DamageHealed = toHeal;
		}

		DefensiveStatus counterStatus;
		if (IsCountering(out counterStatus) && counterStatus.DamageType == type)
		{
			damage *= 0.6f;
		}

		if (StatusEffect == StatusEffect.Poisoned)
		{
			damage *= 1.5f;
		}

		if (Weakness == type)
		{
			damage *= 3;
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

	public void AbsorbDamage(DamageType type, Strength strength)
	{
		DefensiveStatus status = new();
		status.DefensiveType = DefensiveType.Heal;
		status.DamageType = type;
		status.Strength = strength;
		DefensiveStatuses.Add(status);
	}

	public void Heal(float amount)
	{
		ToHeal = amount;
	}

	public void Counter(DamageType type)
	{
		DefensiveStatus status = new();
		status.DefensiveType = DefensiveType.Counter;
		status.DamageType = type;
		DefensiveStatuses.Add(status);
	}

	public bool IsCountering(out DefensiveStatus status)
	{
		status = DefensiveStatuses.Find(s => s.DefensiveType == DefensiveType.Counter);
		return !status.Equals(default(DefensiveStatus));
	}

	public bool IsAbsorbingDamage(out DefensiveStatus status)
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
