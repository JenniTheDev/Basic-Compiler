# JenPile - A Basic Compiler Written in C#

## Table Of Contents
* [Introduction](#Introduction)
* [Project Documentation](#documentation)
* [The Compiler - Lexer](#lexer)
* [The Compiler - Parser](#parser)
* [The Compiler - Symbol Table](#table)




## Project Overview <a name = "Overview"></a>
JenPile is a simple compiler that was built to translate basic programming logic into machine code. It was built in three phases; the Lexical Analyzer, Syntax Analyzer, and  Parser. It was created for the Compiler Project for Compilers and Languages, Fall 2020 at CSUF. Detailed descriptions of each part and directions on how to run can be found in the [Software Requirements Specification](https://jennithedev.github.io/Basic-Compiler/Documentation/JenPile.SoftwareRequirementsSpecification.pdf "PDF of Software Requirement Specification")
<br><br>

## Documentation <a name = "Documentation"></a>
[Software Requirement Specification](https://jennithedev.github.io/Basic-Compiler/Documentation/JenPile.SoftwareRequirementsSpecification.pdf "PDF of Software Requirement Specification") <br>
[Lexer Documentation](https://jennithedev.github.io/Basic-Compiler/Documentation/JenPile.CompilerDocumentation.Lexer.pdf "PDF of Software Requirement Specification")<br>
[Parser Documentation](https://jennithedev.github.io/Basic-Compiler/Documentation/JenPile.CompilerDocumentation.Parser.pdf "PDF of Software Requirement Specification")<br><br>

## The Compiler - Lexer <a name = "lexer"></a><br>

The first part of the project was to write a lexical analyzer, using a FSM for the entire lexer, or using FSM for
identifier, integer and real numbers. The function lexer, should return a token when it is needed. The lexer should return
a record, one field for the token and another field for the actual value (lexeme) of the token. The main program should read in a file containing the source code given
to generate tokens and write the results to an output file.
<br><br>
![](https://jennithe.dev/JenPile/img/lexer.png)

<br><br>


## The Compiler - Parser<a name = "parser"></a>  <br>

The second part of the project is to write a syntax analyzer. It can use any top-down
parser such as a RDP, a predictive recursive descent parser or a table driven
predictive parser. All grammar must be rewritten to remove left recursion.
Arithmetic expressions should be done first, then Assignment and declarations.
The Parser should print to an output file the token, lexeme, and production rules.
<br><br>
![](https://jennithe.dev/JenPile/img/parser.png)
<br> <br>


## The Compiler - Symbol Table<a name = "table"></a><br>

The third part of the project consists of Documentation and Specifications for the compiler
project, a symbol table with type checking, and one of the following options:
generating intermediate code from the grammar from the Parser, or implementing a
different approach for the Syntax Analyzer. Due to Coronavirus considerations, the
third assignment was shortened in class to consist of the documentation and
symbol table, with all other parts of the assignment being extra credit.
Documentation should include explaining approach and function, program flow and
diagrams for maximum points.
The Symbol Table should take every identifier declared in the program and place it
in a symbol table. The symbol table should hold the lexeme and a “memory
address” where it can be found. The table should be checked every time an
identifier is declared and return an error message if it is found. The symbol table
should also make sure the type matches.
<br><br>
![](https://jennithe.dev/JenPile/img/symboltable.png)
