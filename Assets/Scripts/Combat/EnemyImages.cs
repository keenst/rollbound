using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NamePicPair
{
	public string Name;
	public Sprite Sprite;
}

public class EnemyImages : MonoBehaviour
{
	public List<NamePicPair> Dictionary = new();

	public Sprite Get(string name)
	{
		foreach (NamePicPair pair in Dictionary)
		{
			if (pair.Name == name)
			{
				return pair.Sprite;
			}
		}

		Debug.LogError($"Couldn't find image for enemy {name}");
		return null;
	}
}
