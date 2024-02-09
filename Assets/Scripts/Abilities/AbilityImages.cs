using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NameTexPair
{
	public string Name;
	public Texture2D Texture;
}

public class AbilityImages : MonoBehaviour
{
	public List<NameTexPair> _dictionary = new();

	public Texture2D Get(string name)
	{
		foreach (NameTexPair pair in _dictionary)
		{
			if (pair.Name == name)
			{
				return pair.Texture;
			}
		}

		Debug.LogError($"Couldn't find image for ability {name}");
		return null;
	}
}
