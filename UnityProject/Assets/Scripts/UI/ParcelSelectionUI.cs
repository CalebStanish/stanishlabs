using RegionGame.Selection;
using UnityEngine;
using UnityEngine.UI;

namespace RegionGame.UI
{
    /// <summary>
    /// Displays the currently selected parcel in a basic UI Text element.
    /// </summary>
    public class ParcelSelectionUI : MonoBehaviour
    {
        [SerializeField] private ParcelSelectionManager selectionManager;
        [SerializeField] private Text selectionText;

        private void Awake()
        {
            if (selectionText == null)
            {
                selectionText = GetComponent<Text>();
            }

            RefreshLabel(null);
        }

        private void OnEnable()
        {
            if (selectionManager != null)
            {
                selectionManager.OnSelectionChanged += RefreshLabel;
                RefreshLabel(selectionManager.CurrentSelection);
            }
        }

        private void OnDisable()
        {
            if (selectionManager != null)
            {
                selectionManager.OnSelectionChanged -= RefreshLabel;
            }
        }

        private void RefreshLabel(ParcelSelectable selected)
        {
            if (selectionText == null)
            {
                return;
            }

            if (selected == null)
            {
                selectionText.text = "Selected Parcel: None";
                return;
            }

            selectionText.text = $"Selected Parcel: {selected.DisplayName} ({selected.ParcelId})";
        }
    }
}
