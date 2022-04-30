using DG.Tweening;
using System;
using UnityEngine;

namespace GDS.MenuSystem
{
	public class MenuFade : MenuBase
	{

		#region Serialized fields

		[SerializeField] private CanvasGroup canvasGroup;
		[SerializeField] private float fadeDuration = 0.5f;

		#endregion


		#region Private methods

		private void Fade(float endValue, float duration, Action<MenuType> onMenuSwitchComplete, Action onFadeStart, Action onFadeEnd)
		{
			onFadeStart?.Invoke();
			canvasGroup.DOFade(endValue, duration).OnComplete(() =>
			{
				onFadeEnd?.Invoke();
				onMenuSwitchComplete(Menu);
			});
		}

		private void SwitchInteractability(bool interactable)
		{
			canvasGroup.interactable = interactable;
			canvasGroup.blocksRaycasts = interactable;
		}

		private void SwitchGameObject(bool active)
		{
			canvasGroup.gameObject.SetActive(active);
		}

		#endregion


		#region Public methods

		protected override void TurnOn(MenuType menuType)
		{
			base.TurnOn(menuType);
			Fade(1, fadeDuration, TurnOnComplete, () => SwitchGameObject(true), () => SwitchInteractability(true));
		}

		protected override void TurnOff(MenuType menuType)
		{
			base.TurnOff(menuType);
			Fade(0, fadeDuration, TurnOffComplete, () => SwitchInteractability(false), () => SwitchGameObject(false));
		}

		#endregion

	} 
}
