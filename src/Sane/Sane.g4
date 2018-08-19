grammar Sane;

options {
    language=CSharp;   
}
      
module 
    : 'module' moduleName=ID  (declaration|let)* 'end';
    
let
    : bindingName=ID '=' expression;
    
parameter
    : ID;

expression 
    : '(' body=expression ')'                        
        #parenthesisExp
    | 'let' lets=let* 'in' body=expression 'end'
        #letsInExp
    | (PLUS|MINUS) right=expression
        #leftPlusMinus
    | left=expression operation=(ASTERISK|SLASH) right=expression    
        #mulDivExp
    | left=expression operation=(PLUS|MINUS) right=expression        
        #addSubExp
    | left=expression operation=('>'|'<'|'>='|'<='|'=='|'!=') right=expression
        #compareExp
    | '!' right=expression
        #notExpr
    | left=expression '&&' right=expression
        #andExpr
    | left=expression '||' right=expression
        #orExpr
    // maybe to introduce capturing: left |> & right(a &1 c)  ==> ((_a1) -> right(a _a1 c))(left)
    // it would require to introduce a new operator '&' right=expression
    // Tu rodzi się pytanie, czy to ma być bardziej haskell czy Elixir, ponieważ analiza typu może być
    // w tym przypadku megabolesna. Jeżeli będzie implicit currying nie ma sprawy ale wycinanie ze  środka?! 
    // left |> right(a b c)  --> right(left a b c) |
    // left |> right  --> right(left)
    // TODO special syntax  
    | left=expression ('|>'|'<|') right=expression
        #pipeExpr     
    | left=expression ('>>'|'<<') right=expression
        #composeExpr        
    | callable=expression '{' arguments=expression* '}'
        #call
    | '(' parameters=parameter* ')' '->' body=expression
        #function
    | value=NUMBER                                    
        #numericAtomExp
    | value=ESCAPED_STRING  
        #stringAtomExp
    | id=ID
        #idAtomExp;

declaration
    : 'foreign' ID ':' type 
    | ID ':' type;

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

ESCAPED_STRING      : '"' ( '""' | ~["] )* '"';
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