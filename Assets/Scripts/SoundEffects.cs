using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NameClipPair
{
	public string Name;
	public AudioClip AudioClip;
}

public class SoundEffects : MonoBehaviour
{
	public List<NameClipPair> Dictionary = new();

	public AudioClip Get(string name)
	{
		foreach (NameClipPair pair in Dictionary)
		{
			if (pair.Name == name)
			{
				return pair.AudioClip;
			}
		}

		Debug.LogError($"Couldn't find Audio Clip with name {name}");
		return null;
	}
}
