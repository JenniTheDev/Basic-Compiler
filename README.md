# Basic Compiler Written in C++

## Table Of Contents
* [Project Overview](#Overview)
* [Documentation](#documentation)
* [Project Directions: Lexical Analyzer](#AssignmentInstructionsPartOne)
* [Sample Token List](#SampleTokenList)
* [Simple Declaration Assignment Input](#AssignmentInput)
* [Simple Declaration Assignment Output](#AssignmentOutput)
* [Sample Input File](#InputFile)
* [Sample Output File](#OutputFile)
* [Project Directions: Syntax Analyzer](#AssignmentInstructionsPartTwo)
* [Syntax Analyzer Rules](#SyntaxRules)


## Project Overview <a name = "Overview"></a>
JenPile is a simple compiler that was built to translate basic programming logic into machine code. It was built in three phases; the Lexical Analyzer, Syntax Analyzer, and  Parser. It was created for the Compiler Project for Compilers and Languages, Fall 2020 at CSUF </br></br>

## Documentation <a name = "Documentation"></a>
[Software Requirement Specification](https://jennithedev.github.io/Basic-Compiler/Documentation/JenPile.SoftwareRequirementsSpecification.pdf "PDF of Software Requirement Specification")

## Project Directions: Lexical Analyzer <a name = "AssigmentInstructionsPartOne"></a>


The first assignment is to write a lexical analyzer (lexer)
You can build your entire lexer using a FSM , Or build using at least FSMs for
identifier, integer and real (the rest can be written ad-hoc/procedural) but YOU
HAVE TO CONSTRUCT A FSM for this assignment otherwise, there will be a deduction
of 2 points!

Note: In your documentation (design section), YOU MUST write the REs for Identifiers,
Real and Integer, and also show the NFSM using Thompson.

The Lexer

A major component of your assignment will be to write a procedure (Function) – lexer (), that
returns a token when it is needed. Your lexer() should return a record, one field for the token
and another field the actual "value" of the token (lexeme), i.e. the instance of a token.
Your main program should test the lexer i.e., your program should read a file containing
the source code given from class to generate tokens and write out the results to an output
file . Make sure that you print both, the tokens and lexemes.
Basically, your main program should work as follows:

while not finished (i.e. not end of the source file) do:

call the lexer for a token
print the token and lexeme
endwhile 
</br></br>

## Sample Token List <a name = "SampleTokenList"></a>

TOKENS			Example Lexemes</br>

KEYWORDS 	=	int, float, bool, true, false, if, else, then, endif, while, whileend, do, doend, for, forend, input, output, and, or, not </br>
IDENTIFIERS 	=	legal identifiers must start with alphabetic character follow by digits, alpha, or $</br>
SEPARATORS 	=	'(){}[],.:; sp(space)</br>
OPERATORS 	=	*+-=/><%</br>


Additional examples:</br>
Valid IDENTIFIERS	:  	num, num1, large$, num$1, num2, num2$, a9, ab, ab2, etc...</br>
Valid Numbers		:	integers whole numbers (1,2,3,...) and reals floats (5.0, 0.9, 1.75, ...)</br>
Valid Block Comments	:	!  this is a block comment to be ignored by the Lexical Analyzer !</br>



## Simple Declaration Assignment Input<a name ="AssignmentInput"></a>

```! Declare and assign a number !
int number;
number = 9;
```


## Simple Declaration Assignment Output<a name = "AssignmentOutput"></a>

TOKEN			LEXEMES </br>

KEYWORD		=	int</br>
IDENTIFIER	=	number</br>
SEPARATOR	=	;</br>
IDENTIFIER	=	number</br>
OPERATOR	=	=</br>
INTEGER		=	9</br>
SEPARATOR	=	;</br>


## Sample Input File<a nam e= "InputFile"></a>

``` ! Find largest value between two numbers!
int num1, num2, large$
if(num1 > num2)
{
	large = num1$;
}
else
{
	large = num2$;
}
```

## Sample Output File<a name = "OutputFile"></a>

TOKENS			Lexemes</br>
</br>
KEYWORD 	=	 int</br>
IDENTIFIER 	=	 num1</br>
SEPARATOR 	=	 ,</br>
IDENTIFIER 	=	 num2</br>
SEPARATOR 	=	 ,</br>
IDENTIFIER 	=	 large$</br>
KEYWORD 	=	 if</br>
SEPARATOR 	=	 (</br>
IDENTIFIER 	=	 num1</br>
OPERATOR 	=	 ></br>
IDENTIFIER 	=	 num2</br>
SEPARATOR 	=	 )</br>
SEPARATOR 	=	 {</br>
IDENTIFIER 	=	 large</br>
OPERATOR 	=	 =</br>
IDENTIFIER 	=	 num1$</br>
SEPARATOR 	=	 ;</br>
SEPARATOR 	=	 }</br>
KEYWORD 	=	 else</br>
SEPARATOR 	=	 {</br>
IDENTIFIER 	=	 large</br>
OPERATOR 	=	 =</br>
IDENTIFIER 	=	 num2$</br>
SEPARATOR 	=	 ;</br>
SEPARATOR 	=	 }</br>



## Project Directions: Syntax Analyzer<a name = "AssignmentInstructionsPartTwo"></a>  </br>
The second assignment is to write a syntax analyzer. You may use any top-down parser such as a RDP, a
predictive recursive descent parser or a table driven predictive parser. <br>
</br>
The parser should print to an output file the tokens, lexemes and the production rules used;
That is, first, output the token and lexeme found like the output example below.
Then, print out all productions rules used for analyzing this token.
For more points, print out the parse tree used for analyzing the tokens.
Note: - a simple way to do it is to have a “print statement” at the beginning of each function that will print
the production rule.
 - It would be a good idea to have a “switch” with the “print statement” so that you can turn it on or off. 
 - Then do the While and single If statements next for extra points. 
 - Integrate your code with the lexer() or functions generated in the assignment 1 to get more points. 
 - Error handling: if a syntax error occurs, your parser should generate a meaningful error message, such as
token, lexeme, line number, and error type etc.
 - Then, your program may exit or you may continue for further analysis. 
 </br> </br>


# Syntax Analyzer Rules <a name = "SyntaxRules"></a>  </br>
</br>

Do the arithmetic expressions first using these rules:<br>
Expression -> Expression + Term | Expression - Term | Term </br>
Term -> Term * Factor | Term / Factor | Factor </br>
Factor -> ( Expression ) | ID | Num </br>
ID -> id </br>
*the Num rule is OPTIONAL </br> </br>
	
Then do the Assignment statement using these rules:</br>
Statement -> Assign </br>
Assign -> ID = Expression; </br>
*using a semicolon ; at the end of the rule is OPTIONAL </br>

Then do the single Declarative statement using these rules: </br></br>
Statement -> Declarative </br>
Declarative -> Type ID </br>
Type -> bool | float | int </br>
*using a semicolon ; at the end of the rule is OPTIONAL  </br>

* The bottom line is that your program must be able to parse the entire program if it is syntactically correct </br>
