grammar Sane;
 
module : 'module' ID '=' (let|declaration)+;

let : ID '=' expression;
expression 
    : '(' expression ')'
    | expression (ASTERISK|SLASH) expression
    | expression (PLUS|MINUS) expression ;

declaration
    : ID ':' type;

type
    : ID;


fragment LETTER     : [a-zA-Z] ;
fragment DIGIT      : [0-9] ;

ID : LETTER DIGIT;
ASTERISK            : '*' ;
SLASH               : '/' ;
PLUS                : '+' ;
MINUS               : '-' ;

// expression          : '(' expression ')'                        #parenthesisExp
//                     | expression (ASTERISK|SLASH) expression    #mulDivExp
//                     | expression (PLUS|MINUS) expression        #addSubExp
//                     | <assoc=right>  expression '^' expression  #powerExp
//                     | NAME '(' expression ')'                   #functionExp
//                     | NUMBER                                    #numericAtomExp
//                     | ID                                        #idAtomExp
//                     ;
 
// fragment LETTER     : [a-zA-Z] ;
// fragment DIGIT      : [0-9] ;
 
// ASTERISK            : '*' ;
// SLASH               : '/' ;
// PLUS                : '+' ;
// MINUS               : '-' ;
 
// ID                  : LETTER DIGIT ;
 
// NAME                : LETTER+ ;
 
// NUMBER              : DIGIT+ ('.' DIGIT+)? ;
 
// WHITESPACE          : ' ' -> skip;