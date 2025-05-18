using System;

public class Wallet
{
	public event Action<CurrencyType, int> Changed;
		
	private int _maxAmount;

	public Wallet(int maxAmount)
	{
		_maxAmount = maxAmount;
	}

	public void Add(Currency currency, int valueToAdd)
	{
		int currentAmount = currency.Value + valueToAdd;

		if (currentAmount < _maxAmount)
			currency.SetValue(currentAmount);

		if (currentAmount >= _maxAmount)
		{
			currentAmount = _maxAmount;
			currency.SetValue(_maxAmount);
		}

		Changed?.Invoke(currency.Type, currentAmount);
	}

	public void Remove(Currency currency, int valueToRemove)
	{
		int currentAmount = currency.Value - valueToRemove;

		if (currentAmount > 0)
			currency.SetValue(currentAmount);

		if (currentAmount <= 0)
		{
			currentAmount = 0;
			currency.SetValue(0);
		}

		Changed?.Invoke(currency.Type, currentAmount);
	}
}
