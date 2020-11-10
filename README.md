# Lab3FLCD
BNF FA.in formation :
identifier ::= letter | letter{letter}{digit}
letter ::= "A" | "B" | . ..| "Z"
digit ::= "0" | "1" |...| "9"
multipleIdentifier = identifier | multipleIdentifier identifier
multipleLetter = letter | multipleLetter letter
multipleTransition = identifier indentifier identifier | multipleTransition
identifier indentifier identifier
file ::= statesString alphabetString transitionsString initialStatesString
finalStatesString
states: q1 r
statesString ::= “states: ” multipleIdentifier
alphabet: a b c d e f g h i j k l
alphabetString ::= “alphabet: “ multipleLetter
transitions:
q1 a r
q1 b r
transitionsString ::= “transitions:” multipleTransition
initialstate: q1
initialStatesString ::= “initialstate:” identifier
finalstate: r
finalStatesString ::= “finalstate:” multipleIdentifier
