@echo off
set JAR=%~dp0packages\Antlr4.4.5-alpha002\tools\antlr4-csharp-4.5-SNAPSHOT-complete.jar
set ARGS=%~dp0dsl\Grammar.g4 -Dlanguage=CSharp_v4_5 -package EventDay.DSL -o %~dp0dsl\Language -visitor
java -jar %JAR% %ARGS%