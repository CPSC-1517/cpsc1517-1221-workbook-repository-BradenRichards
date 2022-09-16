/*  Test Plan for Person
 *  
 *  Test Case                   Test Data                       Expected Behaviour
 *  ==========                  ==========                      ==================
 *  Valid FullName              FullName: Connor McDavid        FullName = Connor McDavid
 *  
 *  Null FullName               FullName: null                  ArgumentNullException
 *                                                              "FullName value is required"
 *  Empty FullName              FullName: ""                    ArgumentNullException
 *                                                              "FullName value is required"
 *  Whitespace FullName         FullName: "            "        ArgumentNullException
 *                                                              "FullName value is required"
 *  FullName <3 characters      FullName: Bo                    ArgumentException
 *                                                              "FullName must contain 3 or more characters"
 */

//Test Case 1: Valid FullName
using NhlSystem;

var validPerson = new Person("Connor McDavid");
Console.WriteLine(validPerson.FullName); //Value should be Connor McDavid

//Test Case 2: Null FullName
try
{
    var nullPerson = new Person(null);
    Console.WriteLine("Null Test Case failed");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}


//Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine("Empty Test Case failed");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}

//Test Case 4: WhiteSpace FullName
try
{
    var whiteSpacePerson = new Person("");
    Console.WriteLine("WhiteSpace Test Case failed");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}


//Test Case 5: MinimumLength FullNam
try
{
    var invalidLengthPerson = new Person("Bo");
    Console.WriteLine("Minimum Name Length Test Case failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}

