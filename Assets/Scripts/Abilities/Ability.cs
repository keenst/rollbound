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

	public virtual void Use(Fighter target) {}
}

public class PhysicalAbility : Ability
{
	private float _damage;

	public PhysicalAbility(String name, CardRarity rarity) : base(name, rarity)
	{
	}

	public override void Use(Fighter target)
	{
	}
}

public class MagicalAbility : Ability
{
	private Element _element;

	public MagicalAbility(String name, CardRarity rarity) : base(name, rarity)
	{
	}

	public override void Use(Fighter target)
	{
	}
}

public class DefensiveAbility : Ability
{
	private float _healAmount;

	public DefensiveAbility(String name, CardRarity rarity) : base(name, rarity)
	{
	}

	public override void Use(Fighter target)
	{
	}
}
