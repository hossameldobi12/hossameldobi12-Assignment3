/*
.csproj: Contains the project settings, such as the .NET version
and the settings used when building the project.

Program.cs: Contains the code that runs when the application starts.

obj/: Contains temporary files created during the build process.

bin/: Contains the compiled application and its output files.

A file-scoped namespace lets us write the namespace without
adding curly braces around the whole file, so the code has less indentation.

This project uses the newer .slnx format.
One advantage of the classic .sln format is that it has wider
compatibility with older tools and workflows.
*/


using CSharpBasicsAssignment;
using System.Drawing;


Console.WriteLine("=== PART A: Project & Structure ===");
Console.WriteLine("Project setup is ready.");


Console.WriteLine("=== PART B: Variables, Types & Casting ===");
RunTypesDemo();
RunValueVsReferenceDemo();
Console.WriteLine("\n=== PART D: Scope & Operators ===");
RunScopeDemo();
RunCompoundAssignmentDemo();
RunBitwiseDemo();

static void RunTypesDemo()
{
    // 1. Variables and types
    int age = 25;
    long population = 8000000000L;
    double height = 175.5;
    decimal price = 99.99m;
    bool isStudent = true;
    char grade = 'A';
    string name = "Hossam";
    var score = 95;

    Console.WriteLine("\n1. Variables and Types:");
    Console.WriteLine($"age = {age}, Type = {age.GetType()}");
    Console.WriteLine($"population = {population}, Type = {population.GetType()}");
    Console.WriteLine($"height = {height}, Type = {height.GetType()}");
    Console.WriteLine($"price = {price}, Type = {price.GetType()}");
    Console.WriteLine($"isStudent = {isStudent}, Type = {isStudent.GetType()}");
    Console.WriteLine($"grade = {grade}, Type = {grade.GetType()}");
    Console.WriteLine($"name = {name}, Type = {name.GetType()}");
    Console.WriteLine($"score = {score}, Type = {score.GetType()}");

    // 2. Implicit conversion
    int number = 100;
    long bigNumber = number;

    char letter = 'A';
    int letterCode = letter;

    // These conversions are allowed implicitly because the target types can represent these values.
    Console.WriteLine("\n2. Implicit Conversion:");
    Console.WriteLine($"int to long: {bigNumber}");
    Console.WriteLine($"char to int: {letterCode}");

    // 3. Explicit conversion
    double value = 9.8;
    int castResult = (int)value;
    int convertResult = Convert.ToInt32(value);

    // int truncates the decimal part, while Convert.ToInt32 rounds to the nearest integer.
    Console.WriteLine("\n3. Explicit Conversion:");
    Console.WriteLine($"(int) result: {castResult}");
    Console.WriteLine($"Convert.ToInt32 result: {convertResult}");

    // 4. Integer division
    int intResult = 5 / 2;
    double doubleResult = 5.0 / 2;

    // Integer division drops the fractional part, while double division keeps it.
    Console.WriteLine("\n4. Integer Division:");
    Console.WriteLine($"5 / 2 = {intResult}");
    Console.WriteLine($"5.0 / 2 = {doubleResult}");

    // 5. Boxing and unboxing
    int originalNumber = 50;
    object boxedNumber = originalNumber;

    Console.WriteLine("\n5. Boxing and Unboxing:");
    Console.WriteLine($"Before boxing: {originalNumber}");
    Console.WriteLine($"After boxing: {boxedNumber}");

    int unboxedNumber = (int)boxedNumber;
    Console.WriteLine($"After unboxing: {unboxedNumber}");

    // 6. Parsing
    string validInput = "42";
    int parsedNumber = int.Parse(validInput);

    string invalidInput = "abc";
    bool success = int.TryParse(invalidInput, out int parsedValue);

    Console.WriteLine("\n6. Parsing:");
    Console.WriteLine($"int.Parse result: {parsedNumber}");
    Console.WriteLine($"TryParse succeeded: {success}");

    if (success)
    {
        Console.WriteLine($"Parsed value: {parsedValue}");
    }
    else
    {
        Console.WriteLine("Invalid input. Could not convert to int.");
    }

    // 7. float to decimal
    float floatValue = 12.5f;

    // decimal decimalValue = floatValue; // This does not compile because float to decimal has no implicit conversion.
    decimal decimalValue = (decimal)floatValue;

    Console.WriteLine("\n7. Float to Decimal:");
    Console.WriteLine($"float value: {floatValue}");
    Console.WriteLine($"decimal value: {decimalValue}");
}

static void RunValueVsReferenceDemo()
{
    Console.WriteLine("\n=== PART C: Value vs. Reference Types ===");

    // Experiment 1: Struct copy
    Point p1 = new Point { X = 1, Y = 2 };
    Point p2 = p1;

    p2.X = 99;

    Console.WriteLine("\n1. Struct Copy:");
    Console.WriteLine($"p1.X = {p1.X}");
    Console.WriteLine($"p2.X = {p2.X}");

    // A struct assignment copies the values, so p1 and p2 are independent copies.

    // Experiment 2: Class reference
    Order o1 = new Order
    {
        OrderId = 101,
        CustomerName = "Ahmed",
        Quantity = 3,
        UnitPrice = 100m,
        TotalPrice = 0m,
        IsPaid = false,
        DiscountPercent = 10.0,
        ShippingCity = "Cairo",
        Priority = 'H',
        ItemCode = 123456L
    };

    o1.CalculateTotal();

    Order o2 = o1;
    o2.IsPaid = true;

    Console.WriteLine("\n2. Class Reference:");
    Console.WriteLine($"o1.IsPaid = {o1.IsPaid}");
    Console.WriteLine($"o2.IsPaid = {o2.IsPaid}");

    // Both variables reference the same heap object, so changes through o2 affect o1.

    // Experiment 3: Working with object
    object boxedOrder = o1;
    Order o3 = (Order)boxedOrder;

    Console.WriteLine("\n3. Object Reference:");
    Console.WriteLine($"Same instance: {object.ReferenceEquals(o1, o3)}");

    o2.PrintSummary();

    // Memory explanation:
    // A local value-type variable stores its value directly in its storage.
    // Reference-type objects are allocated on the managed heap, while variables hold references to them.
    // Assigning a struct copies its data, but assigning a class variable copies the reference.
    // That's why o1 and o2 point to the same Order object.
    // Assigning o1 to an object variable doesn't create another Order or box it.
}


static void RunScopeDemo()
{
    Console.WriteLine("\nD1. Scope:");

    Scope scopeInstance = new Scope();
    scopeInstance.Method1();
    scopeInstance.Method2();


    ShowLocalVariable();

    for (int i = 0; i < 3; i++)
    {
        int loopValue = i * 10;
        Console.WriteLine($"i = {i}, loopValue = {loopValue}");
    }

    // Console.WriteLine(i);
    // Console.WriteLine(loopValue);
    // Both lines cause compile errors because these variables
    // are only accessible inside the for-loop block.
}



static void ShowLocalVariable()
{
    int localNumber = 50;
    Console.WriteLine($"Local variable: {localNumber}");

    // localNumber can only be used inside this method.
}


static void RunCompoundAssignmentDemo()
{
    Console.WriteLine("\n=== D2: Compound Assignment Operators ===");

    int total = 100;

    total += 5;
    Console.WriteLine($"After += 5: {total}");

    total -= 10;
    Console.WriteLine($"After -= 10: {total}");

    total *= 2;
    Console.WriteLine($"After *= 2: {total}");

    total /= 5;
    Console.WriteLine($"After /= 5: {total}");

    total %= 7;
    Console.WriteLine($"After %= 7: {total}");

    // total += 5 is the same as total = total + 5.
}

static void RunBitwiseDemo()
{
    Console.WriteLine("\n=== D3: Bitwise Operators ===");

    int a = 12; // Binary: 1100
    int b = 10; // Binary: 1010

    // AND: 1100 & 1010 = 1000 (8)
    Console.WriteLine($"a & b = {a & b}");

    // OR:  1100 | 1010 = 1110 (14)
    Console.WriteLine($"a | b = {a | b}");

    // XOR: 1100 ^ 1010 = 0110 (6)
    Console.WriteLine($"a ^ b = {a ^ b}");

    // & evaluates both operands, while && skips the right operand
    // when the left operand is false.
}


class Scope
{
    private int number = 100;

    public void Method1()
    {
        Console.WriteLine($"Field from Method1 = {number}");
    }

    public void Method2()
    {
        Console.WriteLine($"Field from Method2 = {number}");
    }
}
