using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : MonoBehaviour
{
    [SerializeField] private Image _fillImage;

	private Timer _timer;
	private float _maxTime;

	public void Initialize(Timer timer, float maxTime)
	{
		_timer = timer;
		_maxTime = maxTime;
		_timer.ValueChanged += OnTimerUpdated;
	}	

	private void OnDestroy()
	{
		_timer.ValueChanged -= OnTimerUpdated;
	}

	private void OnTimerUpdated(float value)
	{
		float progress = value / _maxTime;
		_fillImage.fillAmount = progress;
	}
}
