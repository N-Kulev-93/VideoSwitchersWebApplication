namespace Application.Shared.Domain
{

    public abstract record ActionParameter
    {
        public abstract string Key { get; }
    }

    public record InputPositionParameter : ActionParameter
    {
        public override string Key => nameof(InputPositionParameter);
    }

    public record OutputPositionParameter : ActionParameter
    {
        public override string Key => nameof(InputPositionParameter);
    }

    public record NameParameter : ActionParameter
    {
        public override string Key => nameof(NameParameter);
    }

    public interface KeyValuePair
    {
        public string Key { get; }
        public string Value { get; }
    }
    public record InputPositionKeyValuePair : InputPositionParameter, KeyValuePair
    {
        public required string Value { get; set; }
    }

    public abstract class ActionDefinition
    {
        public virtual string ActionName { get; } = nameof(ActionDefinition);
        public abstract HashSet<ActionParameter> Parameters { get; }
    }

    public class RenameSwitcher : ActionDefinition
    {
        public override HashSet<ActionParameter> Parameters { get; } = new([new NameParameter()]);
    }

    public class RenameSwitcherInput : ActionDefinition
    {
        public override HashSet<ActionParameter> Parameters { get; } = new([new InputPositionParameter(), new NameParameter()]);
    }

    public class RenameSwitcherOutput : ActionDefinition
    {
        public override HashSet<ActionParameter> Parameters { get; } = new([new OutputPositionParameter(), new NameParameter()]);
    }
    public class SetSwitcherOutputSource : ActionDefinition
    {
        public override HashSet<ActionParameter> Parameters { get; } = new([new InputPositionParameter(), new OutputPositionParameter()]);
    }

    public static class ActionsDefinitions
    {
        public static Dictionary<string, ActionDefinition> Values { get; } = new ActionDefinition[]
        {
            new RenameSwitcher(),
            new RenameSwitcherInput(),
            new RenameSwitcherOutput(),
            new SetSwitcherOutputSource()

        }.ToDictionary(actionDef => actionDef.ActionName, actionDef => actionDef);
    }
}
