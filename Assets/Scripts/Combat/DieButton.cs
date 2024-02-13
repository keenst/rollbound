using System;
using UnityEngine;
using UnityEngine.UI;

public class DieButton : MonoBehaviour
{
	public DieType dieType;
	public CombatSystem combatSystem;
	public Sprite[] rollingFrames;
	public Sprite stillFrame;

	private bool _isRolling;
	private Image _image;

	private const int FrameDurationMS = 200;
	private int _currentFrame;
	private long _lastFrameUpdateMS;

	public void Start()
	{
		_image = GetComponent<Image>();
	}

	public void Update()
	{
		if (!_isRolling) return;
		Debug.Log("is rolling");

		long timeNow = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		if (_lastFrameUpdateMS - timeNow > FrameDurationMS) return;

		Debug.Log("frame update");

		_lastFrameUpdateMS = timeNow;

		_currentFrame = (_currentFrame + 1) % rollingFrames.Length;

		_image.sprite = rollingFrames[_currentFrame];
	}

	public void OnClick()
	{
		combatSystem.OnPickDie(dieType);
	}

	public void StartRolling()
	{
		_isRolling = true;
	}

	public void StopRolling()
	{
		_isRolling = false;

		_image.sprite = stillFrame;
	}

	public void StopInMS(int time)
	{
		Invoke("StopRolling", (float)time / 1000);
	}
}
