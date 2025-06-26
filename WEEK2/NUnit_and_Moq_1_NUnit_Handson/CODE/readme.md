# 🧪 NUnit Calculator Unit Testing - Hands-On Guide

This repository demonstrates **Unit Testing** in C# using the **NUnit Framework**. You'll learn the difference between unit testing and functional testing, write tests for a calculator application, and understand key concepts like mocking, loosely coupled design, and test attributes like `[TestFixture]`, `[SetUp]`, `[TestCase]`, and `[Ignore]`.

---

## 🎯 Objectives

- ✅ Understand **Unit Testing** and how it differs from **Functional Testing**
- ✅ Learn how to test the **smallest unit** of functionality with **mocked dependencies**
- ✅ List and differentiate between various types of testing:
  - Unit Testing
  - Functional Testing
  - Automated Testing
  - Performance Testing
- ✅ Appreciate the **benefits of Automated Testing**
- ✅ Understand **Loosely Coupled & Testable Design**
- ✅ Write testable code that is **not tightly dependent** on other classes
- ✅ Create your **first NUnit test** for validating calculator addition
- ✅ Use core NUnit attributes: `[TestFixture]`, `[Test]`, `[SetUp]`, `[TearDown]`, `[Ignore]`, `[TestCase]`

---

## 🛠️ Technologies Used

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [NUnit](https://nunit.org/)
- [NUnit3TestAdapter](https://github.com/nunit/nunit3-vs-adapter)
- Microsoft.NET.Test.Sdk

---

## 📁 Project Structure
```plaintext
NUnit_and_Moq_1_NUnit_Handson/
│
├── CODE/
│   ├── CalcLibrary/
│   │   └── Calculator.cs              # Business logic class
│   ├── CalculatorTestProject/
│   │   └── CalculatorTests.cs        # NUnit test cases
│   └── CalculatorTestProject.csproj  # Test project file
```

---

## ✅ Steps to Run the Project

1. **Install dependencies** (if not already):

```bash
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

2. **Build the solution:**

```bash
dotnet build
```
3. **Run tests:**

```bash
dotnet test
```
## Calculator Code (from CalcLibrary)
```csharp

public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }
}
```

## 🧪 NUnit Test Code Explained
```csharp

[TestFixture] // Marks this class as a test class
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp() => _calculator = new Calculator();

    [TearDown]
    public void TearDown() => _calculator = null;

    [TestCase(2, 3, 5)]
    [TestCase(-1, -1, -2)]
    [TestCase(0, 0, 0)]
    public void Add_WhenCalled_ReturnsCorrectSum(int a, int b, int expected)
    {
        var result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Ignore("This is a demonstration of [Ignore] attribute.")]
    public void ThisTestIsIgnored()
    {
        Assert.Fail("This test should be ignored.");
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }
}
```
## 🧠 Key NUnit Attributes

| Attribute     | Description                                               |
|---------------|-----------------------------------------------------------|
| `[TestFixture]` | Declares the class as a test class                       |
| `[Test]`        | Marks a method as a test case                            |
| `[SetUp]`       | Runs before each test (used for initialization)          |
| `[TearDown]`    | Runs after each test (used for cleanup)                  |
| `[Ignore]`      | Skips the test method                                    |
| `[TestCase]`    | Defines parameterized tests with different inputs        |

### 🖥️ Sample Output After Running Tests

```powershell
Restore complete (0.4s)
  CODE succeeded (0.3s) → bin\Debug\net9.0\CODE.dll
NUnit Adapter 5.0.0.0: Test execution started
Running all tests in C:\...\CODE\bin\Debug\net9.0\CODE.dll
   NUnit3TestExecutor discovered 5 of 5 NUnit test cases using Current Discovery mode, Non-Explicit run
ThisTestIsIgnored: This is a demonstration of [Ignore] attribute.
NUnit Adapter 5.0.0.0: Test execution complete
  CODE test succeeded (1.2s)

Test summary: total: 5, failed: 0, succeeded: 4, skipped: 1, duration: 1.2s
```

> ✅ 4 tests passed  
> ⚠️ 1 test skipped due to `[Ignore]`  
> ❌ 0 tests failed

---

You can use this table and output section in your documentation to clearly explain the purpose and effect of each NUnit attribute.

## 💡 Benefits of Parameterized Tests
Using [TestCase] allows you to:

- Reduce duplication in test methods

- Test multiple scenarios with one method

- Increase readability and maintainability

## 📘 Summary
This project introduces core unit testing concepts using NUnit in .NET. You now know how to:

- Set up a test project

- Write clean, testable code

- Use NUnit attributes effectively

- Catch runtime issues like divide-by-zero early



