//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWalkingProvided;

    public static Entitas.IMatcher<GameEntity> WalkingProvided {
        get {
            if (_matcherWalkingProvided == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WalkingProvided);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWalkingProvided = matcher;
            }

            return _matcherWalkingProvided;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Input.WalkingProvided walkingProvidedComponent = new Code.Gameplay.Features.Input.WalkingProvided();

    public bool isWalkingProvided {
        get { return HasComponent(GameComponentsLookup.WalkingProvided); }
        set {
            if (value != isWalkingProvided) {
                var index = GameComponentsLookup.WalkingProvided;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : walkingProvidedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
