using UnityEngine;

public class DieButton : MonoBehaviour
{
	public DieType dieType;
	public CombatSystem combatSystem;

	public void OnClick()
	{
		combatSystem.OnPickDie(dieType);
	}
}
