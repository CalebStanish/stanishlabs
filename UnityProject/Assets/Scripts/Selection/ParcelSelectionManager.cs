using System;
using UnityEngine;

namespace RegionGame.Selection
{
    /// <summary>
    /// Handles click-to-select behavior using a camera raycast.
    /// </summary>
    public class ParcelSelectionManager : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;
        [SerializeField] private LayerMask selectionMask = Physics.DefaultRaycastLayers;
        [SerializeField] private float rayDistance = 1000f;

        public ParcelSelectable CurrentSelection { get; private set; }

        public event Action<ParcelSelectable> OnSelectionChanged;

        private void Awake()
        {
            if (targetCamera == null)
            {
                targetCamera = Camera.main;
            }
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            if (targetCamera == null)
            {
                Debug.LogWarning("ParcelSelectionManager: No camera assigned.");
                return;
            }

            Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, rayDistance, selectionMask))
            {
                SetSelection(null);
                return;
            }

            ParcelSelectable selected = hit.collider.GetComponentInParent<ParcelSelectable>();
            if (selected != null && hit.collider.CompareTag("Parcel") == false)
            {
                // Accept parcel component even if collider is not explicitly tagged.
                SetSelection(selected);
                return;
            }

            if (hit.collider.CompareTag("Parcel"))
            {
                SetSelection(selected);
                return;
            }

            SetSelection(null);
        }

        private void SetSelection(ParcelSelectable newSelection)
        {
            if (CurrentSelection == newSelection)
            {
                return;
            }

            CurrentSelection = newSelection;
            OnSelectionChanged?.Invoke(CurrentSelection);
        }
    }
}
