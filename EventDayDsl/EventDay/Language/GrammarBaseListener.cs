//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5-SNAPSHOT
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\code\eventday\vNext\dsl\EventDayDsl\EventDay\Grammar.g4 by ANTLR 4.5-SNAPSHOT

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace EventDayDsl.EventDay.Language {

using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IGrammarListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5-SNAPSHOT")]
[System.CLSCompliant(false)]
public partial class GrammarBaseListener : IGrammarListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] GrammarParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] GrammarParser.ProgramContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.importAssingment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterImportAssingment([NotNull] GrammarParser.ImportAssingmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.importAssingment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitImportAssingment([NotNull] GrammarParser.ImportAssingmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.markerDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMarkerDefinition([NotNull] GrammarParser.MarkerDefinitionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.markerDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMarkerDefinition([NotNull] GrammarParser.MarkerDefinitionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateDefinitionInterface"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStateDefinitionInterface([NotNull] GrammarParser.StateDefinitionInterfaceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateDefinitionInterface"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStateDefinitionInterface([NotNull] GrammarParser.StateDefinitionInterfaceContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStateDefinition([NotNull] GrammarParser.StateDefinitionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStateDefinition([NotNull] GrammarParser.StateDefinitionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.state_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterState_name([NotNull] GrammarParser.State_nameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.state_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitState_name([NotNull] GrammarParser.State_nameContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.namespaceAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNamespaceAssignment([NotNull] GrammarParser.NamespaceAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.namespaceAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNamespaceAssignment([NotNull] GrammarParser.NamespaceAssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.@namespace"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNamespace([NotNull] GrammarParser.NamespaceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.@namespace"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNamespace([NotNull] GrammarParser.NamespaceContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.commandAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCommandAssignment([NotNull] GrammarParser.CommandAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.commandAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCommandAssignment([NotNull] GrammarParser.CommandAssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.eventAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEventAssignment([NotNull] GrammarParser.EventAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.eventAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEventAssignment([NotNull] GrammarParser.EventAssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.messageDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMessageDefinition([NotNull] GrammarParser.MessageDefinitionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.messageDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMessageDefinition([NotNull] GrammarParser.MessageDefinitionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.entityDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEntityDefinition([NotNull] GrammarParser.EntityDefinitionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.entityDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEntityDefinition([NotNull] GrammarParser.EntityDefinitionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.toString"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterToString([NotNull] GrammarParser.ToStringContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.toString"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitToString([NotNull] GrammarParser.ToStringContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.constantDefinitions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstantDefinitions([NotNull] GrammarParser.ConstantDefinitionsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.constantDefinitions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstantDefinitions([NotNull] GrammarParser.ConstantDefinitionsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.constant"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstant([NotNull] GrammarParser.ConstantContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.constant"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstant([NotNull] GrammarParser.ConstantContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterName([NotNull] GrammarParser.NameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitName([NotNull] GrammarParser.NameContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.optionalName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOptionalName([NotNull] GrammarParser.OptionalNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.optionalName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOptionalName([NotNull] GrammarParser.OptionalNameContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] GrammarParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] GrammarParser.TypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.typeArgument"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypeArgument([NotNull] GrammarParser.TypeArgumentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.typeArgument"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypeArgument([NotNull] GrammarParser.TypeArgumentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.typeArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypeArguments([NotNull] GrammarParser.TypeArgumentsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.typeArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypeArguments([NotNull] GrammarParser.TypeArgumentsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.marker"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMarker([NotNull] GrammarParser.MarkerContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.marker"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMarker([NotNull] GrammarParser.MarkerContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.markerList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMarkerList([NotNull] GrammarParser.MarkerListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.markerList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMarkerList([NotNull] GrammarParser.MarkerListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateApplicationList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStateApplicationList([NotNull] GrammarParser.StateApplicationListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateApplicationList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStateApplicationList([NotNull] GrammarParser.StateApplicationListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stateApplication"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStateApplication([NotNull] GrammarParser.StateApplicationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stateApplication"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStateApplication([NotNull] GrammarParser.StateApplicationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.argument"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgument([NotNull] GrammarParser.ArgumentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.argument"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgument([NotNull] GrammarParser.ArgumentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.typeModifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypeModifier([NotNull] GrammarParser.TypeModifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.typeModifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypeModifier([NotNull] GrammarParser.TypeModifierContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.argumentList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgumentList([NotNull] GrammarParser.ArgumentListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.argumentList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgumentList([NotNull] GrammarParser.ArgumentListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumDefinition([NotNull] GrammarParser.EnumDefinitionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumDefinition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumDefinition([NotNull] GrammarParser.EnumDefinitionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumMember"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumMember([NotNull] GrammarParser.EnumMemberContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumMember"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumMember([NotNull] GrammarParser.EnumMemberContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumMemberValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumMemberValue([NotNull] GrammarParser.EnumMemberValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumMemberValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumMemberValue([NotNull] GrammarParser.EnumMemberValueContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.enumMemberList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumMemberList([NotNull] GrammarParser.EnumMemberListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.enumMemberList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumMemberList([NotNull] GrammarParser.EnumMemberListContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace EventDayDsl.EventDay.Language
