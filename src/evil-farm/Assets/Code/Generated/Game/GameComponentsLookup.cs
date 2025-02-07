//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int SelfDestructTimer = 0;
    public const int View = 1;
    public const int ViewPath = 2;
    public const int ViewPrefab = 3;
    public const int Id = 4;
    public const int Transform = 5;
    public const int WorldPosition = 6;
    public const int Input = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "SelfDestructTimer",
        "View",
        "ViewPath",
        "ViewPrefab",
        "Id",
        "Transform",
        "WorldPosition",
        "Input"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Common.SelfDestructTimer),
        typeof(Code.Common.View),
        typeof(Code.Common.ViewPath),
        typeof(Code.Common.ViewPrefab),
        typeof(Code.Gameplay.Common.Id),
        typeof(Code.Gameplay.Common.TransformComponent),
        typeof(Code.Gameplay.Common.WorldPosition),
        typeof(Code.Gameplay.Features.Input.Input)
    };
}
