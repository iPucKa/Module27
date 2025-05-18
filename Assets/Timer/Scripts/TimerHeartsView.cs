using System.Collections.Generic;
using UnityEngine;

public class TimerHeartsView : MonoBehaviour
{
	[SerializeField] private GameObject _heartSpritePrefab;
	[SerializeField] private Transform _parentForHearts;

	private Timer _timer;
	private float _maxTime;
	private List<GameObject> _hearts;

	public void Initialize(Timer timer, float maxTime)
	{
		_timer = timer;
		_maxTime = maxTime;
		_timer.ValueChanged += OnTimerUpdated;
		_timer.Started += OnTimerStarted;

		_hearts = new List<GameObject>();
	}

	private void OnDestroy()
	{
		_timer.ValueChanged -= OnTimerUpdated;
		_timer.Started -= OnTimerStarted;
	}

	private void OnTimerStarted(bool isStarted)
	{
		if (isStarted)		
			CreateHearts();		

		else		
			DestroyHearts();		
	}

	private void OnTimerUpdated(float value)
	{
		if (_hearts.Count - value >= 1)
			for (int i = 0; i < _hearts.Count; i++)
			{
				if (i == _hearts.Count-1)
				{
					Destroy(_hearts[i]);
					_hearts.Remove(_hearts[i]);
				}
			}
	}	

	private void CreateHearts()
	{
		for (int i = 0; i < (int)_maxTime; i++)
		{
			GameObject heart = Instantiate(_heartSpritePrefab, _parentForHearts);
			_hearts.Add(heart);
		}
	}

	private void DestroyHearts()
	{
		for (int i = 0; i < _hearts.Count; i++)		
			Destroy(_hearts[i]);			
		
		_hearts.Clear();
	}
}
