public class Ability
{
	public virtual string Name { get; }
	public virtual CardRarity Rarity { get; }
	public virtual string Description { get; }
	public virtual string Quote { get; }
	public virtual int Cost { get; }

	public Ability(string name, CardRarity rarity, string quote, string description, int cost)
	{
		Name = name;
		Rarity = rarity;
		Quote = quote;
		Description = description;
		Cost = cost;
	}
}

public class PhysicalAbility : Ability
{
	private float _damage;

	public PhysicalAbility(string name, CardRarity rarity, float damage, string quote, string description, int cost) : base(name, rarity, quote, description, cost)
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

	public MagicalAbility(string name, CardRarity rarity, Element element, float potency, string quote, string description, int cost) : base(name, rarity, quote, description, cost)
	{
		Element = element;
		Potency = potency;
	}
}

public class DefensiveAbility : Ability
{
	private DefensiveType _defensiveType;

	public DefensiveAbility(string name, CardRarity rarity, DefensiveType defensiveType, string quote, string description, int cost) : base(name, rarity, quote, description, cost)
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
				HandleAbsorb(user, (DamageType)magicalAbility.Element);
				break;
			case DefensiveType.Counter:
				HandleCounter(user, (DamageType)magicalAbility.Element);
				break;
			case DefensiveType.HerbalTonic:
				HandleHerbalTonic(user, (DamageType)magicalAbility.Element);
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
				HandleAbsorb(user, DamageType.Physical);
				break;
			case DefensiveType.Counter:
				HandleCounter(user, DamageType.Physical);
				break;
			case DefensiveType.HerbalTonic:
				HandleHerbalTonic(user, DamageType.Physical);
				break;
		}

		return new DamageInfo();
	}

	private void HandleHerbalTonic(Fighter user, DamageType type)
	{
		if (type == DamageType.Physical)
		{
			user.Heal(1.5f);
			return;
		}

		if ((StatusEffect)type == user.StatusEffect)
		{
			user.StatusEffect = StatusEffect.None;
		}
	}

	private void HandleCounter(Fighter user, DamageType type)
	{
	}

	private void HandleBlock(Fighter user, DamageType typeToBlock)
	{
		user.BlockDamage(typeToBlock);
	}

	private void HandleAbsorb(Fighter user, DamageType type)
	{
		user.AbsorbDamage(type, (Strength)Rarity);
	}
}
