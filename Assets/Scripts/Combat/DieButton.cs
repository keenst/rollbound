using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DieButton : MonoBehaviour
{
	public DieType dieType;
	public CombatSystem combatSystem;
	public Sprite[] rollingFrames;
	public Sprite stillFrame;
	public Image OverlayImage;

	private bool _isRolling;
	private Image _image;
	private Sprite _currentOverlay;

	private const int FrameDurationMS = 200;
	private int _currentFrame;
	private long _lastFrameUpdateMS;

	public void Start()
	{
		Random rng = new();
		_currentFrame = rng.Next(rollingFrames.Length);
		_image = GetComponent<Image>();
		OverlayImage.enabled = false;
	}

	public void Update()
	{
		if (!_isRolling) return;

		long timeNow = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		if (_lastFrameUpdateMS - timeNow > FrameDurationMS) return;

		_lastFrameUpdateMS = timeNow;

		_currentFrame = (_currentFrame + 1) % rollingFrames.Length;

		_image.sprite = rollingFrames[_currentFrame];
	}

	public void OnClick()
	{
		if (_isRolling) return;

		combatSystem.OnPickDie(dieType);
	}

	public void StartRolling()
	{
		_isRolling = true;

		OverlayImage.enabled = false;
	}

	private void StopRolling()
	{
		_isRolling = false;

		_image.sprite = stillFrame;
		OverlayImage.enabled = true;

		OverlayImage.sprite = _currentOverlay;
	}

	public void StopInMS(Sprite overlay, int time)
	{
		_currentOverlay = overlay;
		Invoke("StopRolling", (float)time / 1000);
	}
}
