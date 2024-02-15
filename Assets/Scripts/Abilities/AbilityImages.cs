using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct NameSpritePair
{
	public string Name;
	[FormerlySerializedAs("Sprite")]
	public Sprite Card;
	public Sprite Overlay;
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
				return pair.Card;
			}
		}

		Debug.LogError($"Couldn't find image for ability {name}");
		return null;
	}

	public Sprite GetOverlay(string name)
	{
		foreach (NameSpritePair pair in _dictionary)
		{
			if (pair.Name == name)
			{
				return pair.Overlay;
			}
		}

		Debug.LogError($"Couldn't find overlay for ability {name}");
		return null;
	}
}
