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
using Antlr4.Runtime.Tree;

#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace EventDayDsl.EventDay.Language {
    /// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5-SNAPSHOT")]
[System.CLSCompliant(false)]
public interface IGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] GrammarParser.ProgramContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.importAssingment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImportAssingment([NotNull] GrammarParser.ImportAssingmentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.markerDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMarkerDefinition([NotNull] GrammarParser.MarkerDefinitionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.stateDefinitionInterface"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStateDefinitionInterface([NotNull] GrammarParser.StateDefinitionInterfaceContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.stateDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStateDefinition([NotNull] GrammarParser.StateDefinitionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.state_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitState_name([NotNull] GrammarParser.State_nameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.namespaceAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespaceAssignment([NotNull] GrammarParser.NamespaceAssignmentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespace([NotNull] GrammarParser.NamespaceContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.commandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommandAssignment([NotNull] GrammarParser.CommandAssignmentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.eventAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEventAssignment([NotNull] GrammarParser.EventAssignmentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.messageDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessageDefinition([NotNull] GrammarParser.MessageDefinitionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.entityDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntityDefinition([NotNull] GrammarParser.EntityDefinitionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.toString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToString([NotNull] GrammarParser.ToStringContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.constantDefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantDefinitions([NotNull] GrammarParser.ConstantDefinitionsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] GrammarParser.ConstantContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitName([NotNull] GrammarParser.NameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.optionalName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOptionalName([NotNull] GrammarParser.OptionalNameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] GrammarParser.TypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.typeArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeArgument([NotNull] GrammarParser.TypeArgumentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.typeArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeArguments([NotNull] GrammarParser.TypeArgumentsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.marker"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMarker([NotNull] GrammarParser.MarkerContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.markerList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMarkerList([NotNull] GrammarParser.MarkerListContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.stateApplicationList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStateApplicationList([NotNull] GrammarParser.StateApplicationListContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.stateApplication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStateApplication([NotNull] GrammarParser.StateApplicationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument([NotNull] GrammarParser.ArgumentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.typeModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeModifier([NotNull] GrammarParser.TypeModifierContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgumentList([NotNull] GrammarParser.ArgumentListContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.enumDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumDefinition([NotNull] GrammarParser.EnumDefinitionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.enumMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumMember([NotNull] GrammarParser.EnumMemberContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.enumMemberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumMemberValue([NotNull] GrammarParser.EnumMemberValueContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.enumMemberList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumMemberList([NotNull] GrammarParser.EnumMemberListContext context);
}
} // namespace EventDay.DSL
