# SSTARK INDUSTRIES CODING STANDARDS
--- 
### Terminology


**Identifier**: This is the name of a method, class or variable in the program.
**Loop Structures**: If, When, Else, Do, While, For, Foreach
**Blocks**: Any section of code contained between curly braces that is itself one entire method/function.

### General Formatting
-	All public methods must have language appropriate documentation to explain them documentation as explained in the official site for [ASP.NET MVC 5](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments).
-	Use appropriate indentation for interior method logic and loop structures so it is easy to read. As our environment is ASP.NET MVC, please avail yourself of the “Format Selection” command under the Edit menu.
-	One action per line, however a statement with multiple method calls is fine. 
	‘’’ db.Friends.Where(n => n.Name == Jane”).FirstOrDefault(); ‘’’
	is ok but 
	‘’’ Clear(); Item.Add(“Apple”); ‘’’
	is not.
-	White space is allowed only in the following situations:
	-	Where it follows a loop structure command and precedes the parenthesis for its condition. 
		‘’’Foreach ()’’’
	-	Separating any reserved words from a curly brace or parenthesis. 
		‘’’} else {‘’’
	-	On both sides of a binary or ternary operator.  
		‘’’int == 0 || int == 1’’’
	-	Around “operator-like” symbols.
		‘’’db.Friends.Select(n => n.FriendID);’’’
	-	One blank line of space should exist after each independent method and/or class and after the variable declaration lists.
	-	Before a comment that is directly following a line of code.
	-	Between a variable and its type. 
		‘’’List<Apples> redApple;’’’
	-	*Optional*: On the interior of curly braces or parenthesis. 
		‘’’new int[] {5, 6}’’’
-	Do not write “short cut” coding for this project. It is good that many programmers know such evolved and concise forms of code but it is hard for those just getting into the project to understand what they are looking at and readability is King.
-	Use parenthesis around expressions to make them easier to discern. 
	‘’’if (( val1 > val2) && (val1 > val3)) {}’’’
-	Use a try-catch statement for any exception handling.
-	Don't use the Visual Basic line separator character (:). 

### Identifier Naming Conventions
-	Identifiers may only involve letters, numbers and in a small number of cases underscores.
-	Identifiers should always be descriptive of the action or role the method/class/variable is playing. No identifier should ever be one character in length.
-	Identifiers use camel casing, what varies is the situation in which the first letter is capitalized: 
	-	*Capitol*: Namespace, Type, Interface, Property, Method, Event, Field & Enum Value
	-	*Lower Case*: Parameter
-	Favor readability over brevity. 
	‘’’CatButtWiggle();’’’ 
	is much more explanatory and easy to use than 
	‘’’wigglesX()’’’
-	Underscores should only be used if the method is private or protected, and then it should be put before the identifier of the method. This is to let us know, easily, that this method cannot be accessed outside of the class. 
	‘’’_HighJump();’’’
-	Constant variables should have their identifiers in all caps so they are easily discerned. 
-	Avoid language specific identifiers. 
-	Do not shorten your identifier. Use GetWindow, not GWin.
-	Do not use acronyms for the entire identifier, though it can make up part of it. Ex: For a heart rate iterator monitor, write it as HRIMonitor or HeartRateIteratorMonitor, but not as HRIM.

### Loop Structures
-	All if, else, for, do and while statement will have curly brackets for their operations, even if they are one line and technically do not require them.
-	Loop structures will be written in the following format: 
‘’’
	if (condition)
	{
    	stuff 
	} 
	else (condition)
	{
    	more stuff 
	}
‘’’
-	Empty blocks should be made one line and concise if possible: 
	‘’’public void doThing() {};’’’
-	All switch statements must have a default case.

### Variables
-	Variables are declared at the start of the class or method in which they are used - with all global variables being declared at the start of the class itself. The exception to this is loop specific counter variables.
-	Variables will be declared one line at a time so avoid confusion. 
	‘’’int a;’’’ 
	is fine but not 
	‘’’int a, b, c;’’’
-	A local variable should never be a constant. 
-	Array initializers will only be presents in block style if the data type makes sense for that presentation method. Acceptable data for this display would be: Matrixes, Dictionaries, Hashmaps, and other types that utilize key-value pairs.
-	Please do not use hyphens or Hungarian notation.
-	When using the variable type “var” be sure to explicitly declare the variable so that people can see its type. 
	‘’’var var1 = “Hello”;’’’
	means that that is clearly of type string.
-	If you cannot explicitly type the variable, avoid using var and instead give the variable an explicit time. 
	‘’’int randomNumber;’’’
-	When generating a new array with predefined variables, please declare it in this format:
	‘’’Dim letters5() As String = {"a", "b", “c”}’’’
	Not this format: 
	‘’’
	Dim letters6(2) As String
		letters6(0) = "a"
		letters6(1) = "b"
		letters6(2) = "c"
	‘’’

### Comments
-	Comments should typically be on a separate line, they should only follow a line of code if they directly warn/notify someone about a very important factor of the code that must be taken into account and is not readily obvious.
-	Comments should not be where your grammar goes to die, treat it like a normal paragraph and put capitols and periods where they belong.
-	Put one space between the comment and its delimiters (aka the  //, /* */ or ///).
-	Do not surround comments with formatted blocks of asterisks.

### SQL 
-	When writing SQL queries align clauses under the From statement: 
	‘’’
	Dim newyorkCustomers = From cust In customers 
                      	   Where cust.City = "New York" 
                      	   Select cust.LastName, cust.CompanyName
	‘’’
-	Aliases for SQL should be shortened versions of their parent identifier so they are easy to connect back to where they come from. Ex: Customer would be cust.
-	Any SQL primary key identifier should be written as <name> followed by ID and no spaces. Ex: FriendID.
-	Any SQL foreign key identifier should have the same name as it does in its home table. This means that if BirdID is the name of a primary key in one table, and a foreign key in another, when it is a foreign key it should still be called BirdID.


