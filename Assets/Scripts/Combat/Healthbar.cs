using UnityEngine;
using System;

public class Healthbar : MonoBehaviour
{
	public GameObject health;

	private const float MaxLength = 340;

	private float startingX;
	private int sign;

	public void Start()
	{
		startingX = health.transform.position.x;
		sign = Math.Sign(health.transform.parent.localPosition.x);
	}

	public void UpdateHealth(float hp, float maxHp)
	{
		float fillAmount = MaxLength * (MathF.Max(hp, 0) / maxHp);

		Vector3 scale = health.transform.localScale;
		health.transform.localScale = new Vector3(fillAmount, scale.y, scale.z);

		Vector3 position = health.transform.position;
		health.transform.position = new Vector3(startingX + sign * (MaxLength - fillAmount) / 2, position.y, position.z);
	}
}
