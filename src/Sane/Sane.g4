grammar Sane;

options {
    language=CSharp;   
}
program 
    : module+ EOF;
      
module 
    : 'module' moduleName=ID  (declaration|let)* 'end';
    
let
    : 'let' bindingName=ID parameter* '=' expression;
    
parameter
    : ID;

expression 
    : '(' expression ')'                        
        #parenthesisExp
    | left=expression operation=(ASTERISK|SLASH) right=expression    
        #mulDivExp
    | left=expression operation=(PLUS|MINUS) right=expression        
        #addSubExp
    | value=NUMBER                                    
        #numericAtomExp
    | ID
        #idAtomExp;

declaration
    : ID ':' type;

type
    : '(' type+ ')'                        
        #parenthesisType
    | type ',' type
        #commaType
    | type '->' type
        #curryType    
    | ID
        #idAtomType;

ID : LETTER+ DIGIT*;
ASTERISK            : '*' ;
SLASH               : '/' ;
PLUS                : '+' ;
MINUS               : '-' ;
NUMBER              : DIGIT+ ('.' DIGIT+)?;
WHITESPACE          : [ \n\t\r]+ -> skip;
SingleLineComment   : '//' ~[\r\n\u2028\u2029]* -> channel(HIDDEN);

fragment LETTER     : [a-zA-Z]+ ;
fragment DIGIT      : [0-9]+ ;


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