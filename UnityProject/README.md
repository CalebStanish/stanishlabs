# Unity Project Starter (First Task)

This commit includes only the **first task** requested:
- Unity folder structure
- RegionScene setup guidance
- Initial clickable parcel selection scripts
- Simple UI display wiring

## Folder structure

- `Assets/Scenes/` — create and save `RegionScene.unity` here.
- `Assets/Scripts/Selection/` — click/selection scripts.
- `Assets/Scripts/UI/` — simple selection UI script.
- `Assets/Prefabs/` — optional parcel prefabs.
- `Assets/Materials/` — optional parcel materials.
- `Assets/Art/` — placeholder art assets.
- `Assets/UI/` — UI prefabs/resources.

## RegionScene setup guidance

1. Open Unity and create/open your project rooted at `UnityProject`.
2. Create a scene and save it as `Assets/Scenes/RegionScene.unity`.
3. Add a `Main Camera` and ensure it can view your parcel objects.
4. Create a few parcel GameObjects (e.g., cubes/planes), each with:
   - a Collider (BoxCollider is fine)
   - the `ParcelSelectable` component
   - tag set to `Parcel`
5. Add an empty GameObject named `SelectionManager` and attach `ParcelSelectionManager`.
   - Assign `Main Camera` to the manager's `Target Camera` field.
6. Create a Canvas with a Text (`Legacy` UI Text) called `SelectionLabel`.
7. Add `ParcelSelectionUI` to the same `SelectionLabel` object.
   - Assign the `SelectionManager` reference in the inspector.
   - Assign the `SelectionText` reference to the Text component.
8. Press Play and click parcels to see the selected parcel text update.

## Notes

- This is intentionally minimal and only covers initial click-to-select flow.
- No game loop, economy, map generation, or progression systems are included yet.
