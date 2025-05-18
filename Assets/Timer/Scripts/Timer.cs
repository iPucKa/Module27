using System;
using System.Collections;
using UnityEngine;

public class Timer : IPause
{
	public event Action<float> ValueChanged;
	public event Action<bool> Started;
	public event Action<bool> Paused;

	private MonoBehaviour _coroutineRunner;

	//private float _maxTime;
	private float _remainingTime;
	private Coroutine _countDown;

	private bool _isPaused;

	public Timer(MonoBehaviour coroutineRunner)
	{
		_coroutineRunner = coroutineRunner;
		_isPaused = false;
	}

	public bool InProcess => _countDown != null;
	public bool IsPaused => _isPaused;

	public void Setup(/*float maxTime, */float currentTime)
	{
		//_maxTime = maxTime;
		_remainingTime = currentTime;

		ValueChanged?.Invoke(_remainingTime);
	}

	public void StartCountingTime()
	{
		if (_countDown != null)
			_coroutineRunner.StopCoroutine(_countDown);

		Started?.Invoke(true);

		_countDown = _coroutineRunner.StartCoroutine(Process());
	}

	public void StopCountineTime()
	{
		if (_countDown != null)
			_coroutineRunner.StopCoroutine(_countDown);

		Started?.Invoke(false);

		_countDown = null;
	}

	public void SetPause(bool isPaused)
	{
		Paused?.Invoke(isPaused);

		_isPaused = isPaused;		
	}

	private IEnumerator Process()
	{
		while (_remainingTime > 0)
		{
			_remainingTime -= Time.deltaTime;

			ValueChanged?.Invoke(_remainingTime);

			if (_remainingTime < 0)
				_remainingTime = 0;

			yield return new WaitWhile(() => _isPaused);
		}

		_countDown = null;
	}
}
