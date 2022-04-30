using UnityEngine;

namespace GDS.MenuSystem
{
    public class MenusController : MonoBehaviour
    {

        #region Serialized fields

        [SerializeField] private MenuType defaultMenu;

        #endregion


        #region Private fields

        private MenuType currentMenu;
        private MenuType nextMenu;

        #endregion


        #region Events

        public delegate void MenuSwitch(MenuType menuType);
        public static event MenuSwitch OnMenuTurnOffStart;
        public static event MenuSwitch OnMenuTurnOnStart;

        #endregion


        #region Private methods

        private void OnMenuSwitchButtonClicked(MenuType menuToSwitchTo)
        {
            nextMenu = menuToSwitchTo;
            OnMenuTurnOffStart?.Invoke(currentMenu);
        }

        private void OnMenuTurnOffComplete(MenuType menuType)
        {
            OnMenuTurnOnStart?.Invoke(nextMenu);
        }

        private void OnMenuTurnOnComplete(MenuType menuType)
        {
            currentMenu = menuType;
        }

        #endregion


        #region Unity methods

        private void Start()
        {
            currentMenu = defaultMenu;
        }

        private void OnEnable()
        {
            MenuSwitchUIButton.OnMenuSwitchButtonClick += OnMenuSwitchButtonClicked;

            MenuBase.OnMenuTurnOffComplete += OnMenuTurnOffComplete;
            MenuBase.OnMenuTurnOnComplete += OnMenuTurnOnComplete;
        }

        private void OnDisable()
        {
            MenuSwitchUIButton.OnMenuSwitchButtonClick -= OnMenuSwitchButtonClicked;

            MenuBase.OnMenuTurnOffComplete -= OnMenuTurnOffComplete;
            MenuBase.OnMenuTurnOnComplete -= OnMenuTurnOnComplete;
        }

        #endregion

    } 
}
