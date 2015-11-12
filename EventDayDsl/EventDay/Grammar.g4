grammar Grammar;

/*Parser Rules*/
program
	:	importAssingment*
	    namespaceAssignment
	    (
            stateDefinition
            | entityDefinition
            | constant
            | commandAssignment
            | eventAssignment
            | stateDefinition
            | markerDefinition
            | messageDefinition
            | enumDefinition
        )*

	;

importAssingment
    : IMPORT namespace TERMINATE?
    ;

markerDefinition
    : MARKER ID('(' argumentList ')')? TERMINATE?
    ;

stateDefinitionInterface
    : ID
    ;

stateDefinition
    : DEFINE_STATE state_name(':' stateDefinitionInterface)? TERMINATE?
    ;

state_name
    : ID
    ;

namespaceAssignment
	: NS namespace TERMINATE?
	;

namespace
    : ID (DOT ID)*
    ;

commandAssignment
	: COMMANDS 'are' type (COMMA type)* TERMINATE?
	;

eventAssignment
	: EVENTS 'are' type (COMMA type)* TERMINATE?
	;

messageDefinition
	: (CMD | EVENT)? type '(' argumentList ')'
	    markerList?
	    toString?
	    stateApplicationList*
	    TERMINATE?
	;


entityDefinition
    : ENTITY type '(' argumentList ')'
    ;

toString
    : STRINGIFY TO_STRING
    ;

constantDefinitions
    : constant*
    ;

constant
    : 'const' name (EQUALS|IS) type optionalName? TERMINATE?
    ;

name
    : ID
    ;

optionalName
    : ID
    ;

type
    : ID(typeArguments)?(typeModifier)?
    ;

typeArgument
    : ID
    ;

typeArguments
    :   '<' typeArgument (',' typeArgument|typeArguments)* '>'
    ;

marker
    : ID
    ;

markerList
    : MARK marker (COMMA marker)*
    ;

stateApplicationList
    : TELL stateApplication (COMMA stateApplication)*
    ;

stateApplication
    : ID
    ;

argument
    : type name?(typeModifier)?
    ;

typeModifier
    :  OPTIONAL
    ;

argumentList
    : argument* (COMMA argument)*
    ;

enumDefinition
    : ENUM type '(' enumMemberList ')'
    ;

//TODO: Enable Enum Flags

enumMember
    : name ('=' enumMemberValue)?
    ;
enumMemberValue
    : INTEGER
    ;

enumMemberList
    : enumMember* (COMMA enumMember)*
    ;

/*Lexical Rules*/
NS		                    : 'namespace'	;
ENUM                        : 'enum';
ENTITY                      : 'entity';
DEFINE	                    : 'def'	;
DEFINE_STATE                : 'state' ;
CMD		                    : 'command' ;
COMMANDS	                : 'commands' ;
EVENT	                    : 'event';
EVENTS                      : 'events';
TERMINATE                   : ';'   ;
COMMA                       : ','   ;
DOT                         : '.'   ;
REQUIRED                    : '!'   ;
OPTIONAL                    : '?'   ;
IS                          : 'is' ;
EQUALS                      : '=' ;
IMPORT                      : 'import' ;
MARK						: 'mark' ;
MARKER                      : 'marker' ;
STRINGIFY                   : 'text';
TELL                        : 'tell' ;

fragment LETTER             : ('a'..'z' | 'A'..'Z')     ;
fragment DIGIT              : '0'..'9';
fragment TYPECHARS          : '[' | ']';

INTEGER                     : DIGIT+ ;

ID                  : LETTER (LETTER | DIGIT | TYPECHARS)*              ;

TO_STRING                   : '"' .*? '"' ;
MULTILINE_COMMENT           : '/*' .*? '*/' -> skip ;
COMMENT                     : '//' .*? ('\n'|'\r') -> skip  ;
WS                          : (' ' | '\t' | '\n' | '\r' | '\f')+ -> skip    ;

