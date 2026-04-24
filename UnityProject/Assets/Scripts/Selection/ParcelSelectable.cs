using UnityEngine;

namespace RegionGame.Selection
{
    /// <summary>
    /// Add this to any parcel object that should be clickable/selectable.
    /// </summary>
    public class ParcelSelectable : MonoBehaviour
    {
        [Header("Parcel Metadata")]
        [SerializeField] private string parcelId = "Parcel-001";
        [SerializeField] private string displayName = "Parcel";

        public string ParcelId => parcelId;
        public string DisplayName => string.IsNullOrWhiteSpace(displayName) ? gameObject.name : displayName;
    }
}
