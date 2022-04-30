using UnityEngine;
using UnityEngine.UI;

namespace GDS.MenuSystem
{
    public class MenuSwitchUIButton : MonoBehaviour
    {

        #region Serialized fields

        [SerializeField] private MenuType menuToTurnOn;

        #endregion


        #region Events

        public delegate void MenuSwitch(MenuType menuType);
        public static event MenuSwitch OnMenuSwitchButtonClick;

        #endregion


        #region Unity methods

        private void Start()
        {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                OnMenuSwitchButtonClick?.Invoke(menuToTurnOn);
            }
            );
        } 

        #endregion

    } 
}
