# 🧪 NUnit & Moq Unit Testing Scenarios

This repository demonstrates how to write **unit tests** using **NUnit** and **Moq** in different real-world application scenarios, including **mocking email services, file systems, and databases**. It emphasizes **Test-Driven Development (TDD)** and **Dependency Injection (DI)** to create testable, maintainable, and loosely coupled code.

---

## 🎯 Objectives

- ✅ Understand how **Mocking** enhances **Test-Driven Development (TDD)**
- ✅ Differentiate **Mock**, **Fake**, and **Stub**
- ✅ Learn **Mocking & Isolation** in Unit Testing
- ✅ Apply **Dependency Injection (DI)** techniques:
  - Constructor Injection
  - Method Injection
- ✅ Create **testable code** with Moq for:
  - Email sending
  - File system access
  - Database communication
- ✅ Use NUnit features: `[TestFixture]`, `[OneTimeSetUp]`, `[TestCase]`, and exception assertions

---

## 📁 Project Structure

```plaintext
NUnit_Moq_Tests/
│
├── CustomerCommLib/                # Mail sending service
│   ├── IMailSender.cs
│   └── MailSender.cs
│   └── CustomerComm.cs
│
├── CustomerComm.Tests/            # Unit tests for mail service
│   └── CustomerCommTests.cs
│
├── MagicFilesLib/                 # File directory search service
│   ├── IDirectoryExplorer.cs
│   └── DirectoryExplorer.cs
│
├── DirectoryExplorer.Tests/       # Unit tests for file system
│   └── DirectoryExplorerTests.cs
│
├── PlayersManagerLib/             # Player registration and DB communication
│   ├── IPlayerMapper.cs
│   ├── PlayerMapper.cs
│   └── Player.cs
│
├── PlayerManager.Tests/           # Unit tests for DB logic
│   └── PlayerTests.cs
```

---

## 📦 Required NuGet Packages

Install the following packages in each test project:

```bash
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Moq
dotnet add package Microsoft.NET.Test.Sdk
```

---

## 📌 Key Concepts Used

| Concept             | Purpose                                                         |
|---------------------|-----------------------------------------------------------------|
| Mocking             | Simulates behavior of real objects for isolation                |
| Test Doubles        | Includes Mock, Stub, and Fake objects                           |
| Dependency Injection| Injecting dependencies for better testability                  |
| NUnit Attributes    | `[TestFixture]`, `[SetUp]`, `[TearDown]`, `[TestCase]`, etc.    |
| Exception Handling  | Validating thrown exceptions using assertions or attributes     |

---

## ✅ Scenario 1: Mocking Mail Sender

**Class under test**: `CustomerComm`  
**Dependency**: `IMailSender`

### Goal:
Test `SendMailToCustomer()` without actually sending an email.

### Strategy:
- Mock `IMailSender`
- Configure it to return `true` when `SendMail` is called
- Assert that the method executes successfully

---

## ✅ Scenario 2: Mocking File System

**Class under test**: `DirectoryExplorer`  
**Dependency**: `IDirectoryExplorer`

### Goal:
Test file search functionality without accessing real file system.

### Strategy:
- Mock `GetFiles` method
- Return a predefined list of file names
- Assert collection count and contents

### Example Assertions:
- Collection is not `null`
- Collection `.Count == 2`
- Collection contains `"file.txt"`

---

## ✅ Scenario 3: Mocking Database Access

**Class under test**: `Player`  
**Dependency**: `IPlayerMapper`

### Goal:
Test `RegisterNewPlayer()` without accessing real DB.

### Strategy:
- Mock `IsPlayerNameExistsInDb` to return `false`
- Mock `AddNewPlayerIntoDb` to simulate DB write
- Assert the returned `Player` object’s properties

### Exception Testing:
- When name exists in DB → mock `IsPlayerNameExistsInDb` to return `true`
- Assert it throws `ArgumentException`

---

## ✅ Sample Output

```powershell
NUnit Adapter 5.0.0.0: Test execution started
Running all tests...
CustomerCommTests: ✅ passed
DirectoryExplorerTests: ✅ passed
PlayerTests: ✅ passed
All tests passed! (8 total, 0 failed, 0 skipped)
```

---

## 📝 Summary

- Demonstrated **unit testing** using **Moq + NUnit**
- Practiced **mocking external dependencies** like SMTP, File System, and DB
- Used **Dependency Injection** to isolate logic
- Improved **code testability, flexibility, and maintainability**

---

