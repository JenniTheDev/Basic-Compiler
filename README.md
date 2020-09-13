# Compiler Project for Compilers and Languages, Fall 2020 at CSUF

## Table Of Contents
* [Assignment Instructions](#AssignmentInstructions)
* [Sample Token List](#SampleTokenList)
* [Simple Declaration Assignment Input](#AssignmentInput)
* [Simple Declaration Assignment Output](#AssignmentOutput)
* [Sample Input File](#InputFile)
* [Sample Output File](#OutputFile)
* [Documentation](#documentation)



## Assignment Instructions <a name = "AssigmentInstructions"></a>
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


## Sample Token List <a name = "SampleTokenList"></a>

TOKENS			Example Lexemes

KEYWORDS 	=	int, float, bool, true, false, if, else, then, endif, while, whileend, do, doend, for, forend, input, output, and, or, not
IDENTIFIERS 	=	legal identifiers must start with alphabetic character follow by digits, alpha, or $
SEPARATORS 	=	'(){}[],.:; sp(space)
OPERATORS 	=	*+-=/><%


Additional examples:
Valid IDENTIFIERS	:  	num, num1, large$, num$1, num2, num2$, a9, ab, ab2, etc...
Valid Numbers		:	integers whole numbers (1,2,3,...) and reals floats (5.0, 0.9, 1.75, ...)
Valid Block Comments	:	!  this is a block comment to be ignored by the Lexical Analyzer !



## Simple Declaration Assignment Input<a name ="AssignmentInput"></a>

```! Declare and assign a number !
int number;
number = 9;
```


## Simple Declaration Assignment Output<a name = "AssignmentOutput"></a>

TOKEN			LEXEMES

KEYWORD		=	int
IDENTIFIER	=	number
SEPARATOR	=	;
IDENTIFIER	=	number
OPERATOR	=	=
INTEGER		=	9
SEPARATOR	=	;


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

TOKENS			Lexemes

KEYWORD 	=	 int
IDENTIFIER 	=	 num1
SEPARATOR 	=	 ,
IDENTIFIER 	=	 num2
SEPARATOR 	=	 ,
IDENTIFIER 	=	 large$
KEYWORD 	=	 if
SEPARATOR 	=	 (
IDENTIFIER 	=	 num1
OPERATOR 	=	 >
IDENTIFIER 	=	 num2
SEPARATOR 	=	 )
SEPARATOR 	=	 {
IDENTIFIER 	=	 large
OPERATOR 	=	 =
IDENTIFIER 	=	 num1$
SEPARATOR 	=	 ;
SEPARATOR 	=	 }
KEYWORD 	=	 else
SEPARATOR 	=	 {
IDENTIFIER 	=	 large
OPERATOR 	=	 =
IDENTIFIER 	=	 num2$
SEPARATOR 	=	 ;
SEPARATOR 	=	 }


## Documentation<a name = "documentation"></a>



