public class Fighter
{
	public Dice Dice;
	public float HP;
	public string Name;
	
	private float _maxHp;

	// Defensive status
	private bool _isBlockingDamage;
	private DamageType _blockingDamageType;

	public Fighter(Dice dice, float hp, float maxHp, string name)
	{
		Dice = dice;
		HP = hp;
		_maxHp = maxHp;
		Name = name;
	}

	public void ApplyDamage(float damage, DamageType type)
	{
		HP -= damage;
	}

	public void ResetDefensiveStatus()
	{
		_isBlockingDamage = false;
	}

	public void BlockDamage(DamageType type)
	{
		_isBlockingDamage = true;
		_blockingDamageType = type;
	}

	public bool IsBlockingDamage(out DamageType type)
	{
		if (_isBlockingDamage)
		{
			type = _blockingDamageType;
			return true;
		}

		// Sets random unused value to type
		type = DamageType.Physical;

		return false;
	}
}
