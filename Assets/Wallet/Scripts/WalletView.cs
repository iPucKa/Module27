using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
	[SerializeField] private TMP_Text _coinsCountText;
	[SerializeField] private TMP_Text _diamondsCountText;
	[SerializeField] private TMP_Text _energieCountText;

	private Wallet _wallet;

	public void Initialize(Wallet wallet)
	{
		_wallet = wallet;
		_wallet.Changed += OnCurrencyChanged;
	}

	private void OnDestroy()
	{
		_wallet.Changed -= OnCurrencyChanged;
	}

	private void OnCurrencyChanged(ItemsType type, int value)
	{
		if(type == ItemsType.Coins)		
			_coinsCountText.text = value.ToString();

		if (type == ItemsType.Diamonds)
			_diamondsCountText.text = value.ToString();

		if (type == ItemsType.Energie)
			_energieCountText.text = value.ToString();
	}
}
