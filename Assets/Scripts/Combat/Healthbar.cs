using UnityEngine;

public class Healthbar : MonoBehaviour
{
	public GameObject health;

	private const float MaxLength = 340;

	public void UpdateHealth(float hp, float maxHp)
	{
		float fillAmount = MaxLength / (hp / maxHp);

		Vector3 scale = health.transform.localScale;
		scale = new Vector3(fillAmount, scale.y, scale.z);
	}
}
