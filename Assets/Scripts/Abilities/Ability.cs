public class Ability
{
	public virtual string Name { get; }
	public virtual CardRarity Rarity { get; }

	public Ability(string name, CardRarity rarity)
	{
		Name = name;
		Rarity = rarity;
	}
}

public class PhysicalAbility : Ability
{
	private float _damage;

	public PhysicalAbility(string name, CardRarity rarity, float damage) : base(name, rarity)
	{
		_damage = damage;
	}

	public DamageInfo UseCombo(Fighter user, Fighter target, MagicalAbility magicalAbility)
	{
		float damage = user.StatusEffect == StatusEffect.Frozen ? _damage * 0.6f : _damage;
		DamageInfo a = target.ApplyDamage(damage * magicalAbility.Potency, (DamageType)magicalAbility.Element);
		DamageInfo b = target.ApplyDamage(damage, DamageType.Physical);
		return a + b;
	}

	public DamageInfo Use(Fighter user, Fighter target)
	{
		float damage = user.StatusEffect == StatusEffect.Frozen ? _damage * 0.6f : _damage;
		return target.ApplyDamage(damage, DamageType.Physical);
	}
}

public class MagicalAbility : Ability
{
	public float Potency;

	public Element Element;

	public MagicalAbility(string name, CardRarity rarity, Element element, float potency) : base(name, rarity)
	{
		Element = element;
		Potency = potency;
	}
}

public class DefensiveAbility : Ability
{
	private DefensiveType _defensiveType;

	public DefensiveAbility(string name, CardRarity rarity, DefensiveType defensiveType) : base(name, rarity)
	{
		_defensiveType = defensiveType;
	}

	public DamageInfo UseCombo(Fighter user, MagicalAbility magicalAbility)
	{
		switch (_defensiveType)
		{
			case DefensiveType.Block:
				HandleBlock(user, (DamageType)magicalAbility.Element);
				break;
			case DefensiveType.Heal:
				HandleBlock(user, (DamageType)magicalAbility.Element);
				break;
		}

		return new DamageInfo();
	}

	public DamageInfo Use(Fighter user)
	{
		switch (_defensiveType)
		{
			case DefensiveType.Block:
				HandleBlock(user, DamageType.Physical);
				break;
			case DefensiveType.Heal:
				HandleHeal(user, DamageType.Physical);
				break;
		}

		return new DamageInfo();
	}

	private void HandleBlock(Fighter user, DamageType typeToBlock)
	{
		user.BlockDamage(typeToBlock);
	}

	private void HandleHeal(Fighter user, DamageType type)
	{
		user.HealDamage(type);
	}
}
