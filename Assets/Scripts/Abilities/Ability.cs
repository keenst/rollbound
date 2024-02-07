using System;

public class Ability
{
	public virtual String Name { get; }
	public virtual CardRarity Rarity { get; }

	public Ability(String name, CardRarity rarity)
	{
		Name = name;
		Rarity = rarity;
	}
}

public class PhysicalAbility : Ability
{
	private float _damage;

	public PhysicalAbility(String name, CardRarity rarity, float damage) : base(name, rarity)
	{
		_damage = damage;
	}

	public void UseCombo(Fighter target, MagicalAbility magicalAbility)
	{
		target.ApplyDamage(_damage * magicalAbility.Potency, (DamageType)magicalAbility.Element);
		target.ApplyDamage(_damage * 1 - magicalAbility.Potency, (DamageType)magicalAbility.Element);
	}

	public void Use(Fighter target)
	{
		target.ApplyDamage(_damage, DamageType.Physical);
	}
}

public class MagicalAbility : Ability
{
	// The proportion of physical damage replaced by magical
	public float Potency;

	public Element Element;

	public MagicalAbility(String name, CardRarity rarity) : base(name, rarity)
	{
	}
}

public class DefensiveAbility : Ability
{
	private DefensiveType _defensiveType;

	public DefensiveAbility(String name, CardRarity rarity, DefensiveType defensiveType) : base(name, rarity)
	{
		_defensiveType = defensiveType;
	}

	public void UseCombo(Fighter user, MagicalAbility magicalAbility)
	{
	}

	public void Use(Fighter user)
	{
		switch (_defensiveType)
		{
			case DefensiveType.Block:
			{
				HandleBlock();
			} break;
		}
	}

	private void HandleBlock()
	{
	}
}
