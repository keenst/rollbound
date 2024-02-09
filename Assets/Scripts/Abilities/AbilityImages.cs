using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NameSpritePair
{
	public string Name;
	public Sprite Sprite;
}

public class AbilityImages : MonoBehaviour
{
	public List<NameSpritePair> _dictionary = new();

	public Sprite Get(string name)
	{
		foreach (NameSpritePair pair in _dictionary)
		{
			if (pair.Name == name)
			{
				return pair.Sprite;
			}
		}

		Debug.LogError($"Couldn't find image for ability {name}");
		return null;
	}
}
