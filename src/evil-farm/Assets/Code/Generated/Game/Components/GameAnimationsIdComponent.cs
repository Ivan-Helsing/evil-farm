//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimationsId;

    public static Entitas.IMatcher<GameEntity> AnimationsId {
        get {
            if (_matcherAnimationsId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimationsId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimationsId = matcher;
            }

            return _matcherAnimationsId;
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

    public Code.Gameplay.Features.Animations.AnimationsId animationsId { get { return (Code.Gameplay.Features.Animations.AnimationsId)GetComponent(GameComponentsLookup.AnimationsId); } }
    public Code.Gameplay.Features.Animations.AnimationTypeId AnimationsId { get { return animationsId.Value; } }
    public bool hasAnimationsId { get { return HasComponent(GameComponentsLookup.AnimationsId); } }

    public GameEntity AddAnimationsId(Code.Gameplay.Features.Animations.AnimationTypeId newValue) {
        var index = GameComponentsLookup.AnimationsId;
        var component = (Code.Gameplay.Features.Animations.AnimationsId)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimationsId));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAnimationsId(Code.Gameplay.Features.Animations.AnimationTypeId newValue) {
        var index = GameComponentsLookup.AnimationsId;
        var component = (Code.Gameplay.Features.Animations.AnimationsId)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimationsId));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAnimationsId() {
        RemoveComponent(GameComponentsLookup.AnimationsId);
        return this;
    }
}
