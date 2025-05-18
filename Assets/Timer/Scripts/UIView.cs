using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
	private const string PauseOnText = "PAUSED";
	private const string PauseOffText = "...";

	private const string StartText = "IS ON";
	private const string StopText = "IS OFF";

	[SerializeField] private TMP_Text _startStopButtonText;
	[SerializeField] private TMP_Text _pauseButtonText;

	private Timer _timer;

	public void Initialize(Timer timer)
	{
		_timer = timer;
		_timer.Started += OnTimerStarted;
		_timer.Paused += OnTimerPaused;
	}

	private void OnDestroy()
	{
		_timer.Started -= OnTimerStarted;
		_timer.Paused -= OnTimerPaused;
	}

	private void OnTimerStarted(bool isStarted)
	{
		if (isStarted)		
			_startStopButtonText.text = StartText;		

		else		
			_startStopButtonText.text = StopText;		
	}

	private void OnTimerPaused(bool isPaused)
	{
		if (isPaused)
			_pauseButtonText.text = PauseOnText;

		else
			_pauseButtonText.text = PauseOffText;
	}	
}
