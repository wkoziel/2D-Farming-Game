# Sprite Swap and 2D Animation Integration

__Sprite Swap__ is integrated with the 2D Animation workflow. You must install the following packages or newer to use Sprite Swap:

- [2D Animation version 2.2.0-preview.1](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest/index.html?preview=1)
- [PSDImporter version 1.2.0-preview.1](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@latest/index.html?preview=1)

To ensure Sprite Swap works correctly with skeletal animation, the animation rig needs to be identical between the interchangeable Sprites. Use the [Copy and Paste](CopyPasteSkele.md) tools to duplicate the rig from one Sprite to the other Sprite(s) to ensure they can be swapped.

## Asset Generation Behaviour

The following is the steps that Unity takes to generate the various Sprite Swap components.

1. When you import a PSB file with the [PSD Importer](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@latest/index.html?preview=1), Unity generates a Prefab and creates a [Sprite Library Asset](SLAsset.md) as a sub-Asset of this Prefab.

2. Unity then generates a GameObject for each Sprite in the Prefab that does not belong to a __Category__, or is the first Label in the Category.

3. Unity attaches the [Sprite Resolver component](SRComponent.md) to all Sprite GameObjects that belong to a Category.

4. Unity then attaches the [Sprite Library component](SLComponent.md) to the root GameObject, and the component is set to reference the Sprite Library Asset created in Step 1.

## Sprite Swap and Skeletal Animation Limitations

To ensure Sprite Swap works correctly with skeletal animation, the animation skeleton rig needs to be identical between corresponding Sprites that are to be swapped. Use the [Copy and Paste](CopyPasteSkele.md) feature to copy both the bones and Mesh data from one Sprite(s) to the other corresponding Sprite(s).