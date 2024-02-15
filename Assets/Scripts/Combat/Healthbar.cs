using UnityEngine;
using UnityEngine.UI;
using System;

public class Healthbar : MonoBehaviour
{
	public GameObject health;
	public Sprite[] healthBarOverlays;
	public Image overlay;

	private const float MaxLength = 340;

	private float _startingX;
	private int _sign;
	private bool _isInitialized;

	public void Start()
	{
		_startingX = health.transform.position.x;
		_sign = Math.Sign(health.transform.parent.localPosition.x);
		_isInitialized = true;
	}

	public void UpdateHealth(float hp, float maxHp, StatusEffect statusEffect)
	{
		if (!_isInitialized) return;

		// Health
		float fillAmount = MaxLength * (MathF.Max(hp, 0) / maxHp);

		Vector3 scale = health.transform.localScale;
		health.transform.localScale = new Vector3(fillAmount, scale.y, scale.z);

		Vector3 position = health.transform.position;
		health.transform.position = new Vector3(_startingX + _sign * (MaxLength - fillAmount) / 2, position.y, position.z);

		// Status effects
		if (statusEffect == StatusEffect.None)
		{
			overlay.enabled = false;
			return;
		}

		overlay.enabled = true;
		overlay.sprite = healthBarOverlays[(int)statusEffect];
	}
}
