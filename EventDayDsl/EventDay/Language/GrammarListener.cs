//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5-SNAPSHOT
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\code\eventday\vNext\server\tools\dsl\Grammar.g4 by ANTLR 4.5-SNAPSHOT

// Unreachable code detected

using Antlr4.Runtime.Misc;

#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace EventDayDsl.EventDay.Language {
    using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;

    /// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="GrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5-SNAPSHOT")]
[System.CLSCompliant(false)]
public interface IGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] GrammarParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] GrammarParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.importAssingment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImportAssingment([NotNull] GrammarParser.ImportAssingmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.importAssingment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImportAssingment([NotNull] GrammarParser.ImportAssingmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.markerDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMarkerDefinition([NotNull] GrammarParser.MarkerDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.markerDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMarkerDefinition([NotNull] GrammarParser.MarkerDefinitionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateDefinitionInterface"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStateDefinitionInterface([NotNull] GrammarParser.StateDefinitionInterfaceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateDefinitionInterface"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStateDefinitionInterface([NotNull] GrammarParser.StateDefinitionInterfaceContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStateDefinition([NotNull] GrammarParser.StateDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStateDefinition([NotNull] GrammarParser.StateDefinitionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.state_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterState_name([NotNull] GrammarParser.State_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.state_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitState_name([NotNull] GrammarParser.State_nameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.namespaceAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespaceAssignment([NotNull] GrammarParser.NamespaceAssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.namespaceAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespaceAssignment([NotNull] GrammarParser.NamespaceAssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespace([NotNull] GrammarParser.NamespaceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespace([NotNull] GrammarParser.NamespaceContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.commandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommandAssignment([NotNull] GrammarParser.CommandAssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.commandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommandAssignment([NotNull] GrammarParser.CommandAssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.eventAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEventAssignment([NotNull] GrammarParser.EventAssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.eventAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEventAssignment([NotNull] GrammarParser.EventAssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.messageDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMessageDefinition([NotNull] GrammarParser.MessageDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.messageDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMessageDefinition([NotNull] GrammarParser.MessageDefinitionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.entityDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityDefinition([NotNull] GrammarParser.EntityDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.entityDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityDefinition([NotNull] GrammarParser.EntityDefinitionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.toString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToString([NotNull] GrammarParser.ToStringContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.toString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToString([NotNull] GrammarParser.ToStringContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.constantDefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantDefinitions([NotNull] GrammarParser.ConstantDefinitionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.constantDefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantDefinitions([NotNull] GrammarParser.ConstantDefinitionsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] GrammarParser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] GrammarParser.ConstantContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterName([NotNull] GrammarParser.NameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitName([NotNull] GrammarParser.NameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.optionalName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionalName([NotNull] GrammarParser.OptionalNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.optionalName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionalName([NotNull] GrammarParser.OptionalNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] GrammarParser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] GrammarParser.TypeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.typeArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeArgument([NotNull] GrammarParser.TypeArgumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.typeArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeArgument([NotNull] GrammarParser.TypeArgumentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.typeArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeArguments([NotNull] GrammarParser.TypeArgumentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.typeArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeArguments([NotNull] GrammarParser.TypeArgumentsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.marker"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMarker([NotNull] GrammarParser.MarkerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.marker"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMarker([NotNull] GrammarParser.MarkerContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.markerList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMarkerList([NotNull] GrammarParser.MarkerListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.markerList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMarkerList([NotNull] GrammarParser.MarkerListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateApplicationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStateApplicationList([NotNull] GrammarParser.StateApplicationListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateApplicationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStateApplicationList([NotNull] GrammarParser.StateApplicationListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateApplication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStateApplication([NotNull] GrammarParser.StateApplicationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateApplication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStateApplication([NotNull] GrammarParser.StateApplicationContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgument([NotNull] GrammarParser.ArgumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgument([NotNull] GrammarParser.ArgumentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.typeModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeModifier([NotNull] GrammarParser.TypeModifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.typeModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeModifier([NotNull] GrammarParser.TypeModifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgumentList([NotNull] GrammarParser.ArgumentListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgumentList([NotNull] GrammarParser.ArgumentListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumDefinition([NotNull] GrammarParser.EnumDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumDefinition([NotNull] GrammarParser.EnumDefinitionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumMember([NotNull] GrammarParser.EnumMemberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumMember([NotNull] GrammarParser.EnumMemberContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumMemberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumMemberValue([NotNull] GrammarParser.EnumMemberValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumMemberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumMemberValue([NotNull] GrammarParser.EnumMemberValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumMemberList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumMemberList([NotNull] GrammarParser.EnumMemberListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumMemberList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumMemberList([NotNull] GrammarParser.EnumMemberListContext context);
}
} // namespace EventDay.DSL
