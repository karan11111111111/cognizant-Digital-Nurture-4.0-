# Exercise 1: Ranking and Window Functions

This exercise demonstrates the use of **SQL Server ranking functions** — `ROW_NUMBER()`, `RANK()`, `DENSE_RANK()` — along with `OVER()` and `PARTITION BY`, to rank products within their categories.

---

## 🎯 Goal

- Use `ROW_NUMBER()`, `RANK()`, and `DENSE_RANK()` functions
- Understand how ties are handled by each
- Apply `PARTITION BY` to group products by category
- Select the **top 3 most expensive products per category**

---

## 🗃️ Sample Table: `Products`

| Column      | Type           | Description          |
| ----------- | -------------- | -------------------- |
| ProductID   | INT (PK)       | Unique identifier    |
| ProductName | VARCHAR(100)   | Name of the product  |
| Category    | VARCHAR(50)    | Product category     |
| Price       | DECIMAL(10, 2) | Price of the product |

---

## 🧪 SQL Concepts Used

- `ROW_NUMBER()` – assigns a unique number to each row within a category
- `RANK()` – assigns the same rank to tied values but leaves gaps
- `DENSE_RANK()` – assigns the same rank to ties without leaving gaps
- `OVER()` – used to define the window (partition and sort order)
- `PARTITION BY` – used to group rows by category

---

## 📋 Queries Demonstrated

### 1. **Using `ROW_NUMBER()`**

Assigns a unique rank within each category.

```sql
ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC)

```

## 2. 🏷️ Using `RANK()`

Ranks with gaps for tied values.

```sql
RANK() OVER (PARTITION BY Category ORDER BY Price DESC)
```

## 3. 🏷️ Using `DENSE_RANK()`

Ranks without gaps for ties.

```sql
DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC)
```

## 4. 🥇 Get Top 3 Products per Category

```sql

WITH RankedProducts AS (
    SELECT *,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE RowNum <= 3;
```

▶️ How to Run the Script
Open Command Prompt or Windows Terminal

Run the script using sqlcmd:

```bash

sqlcmd -S localhost -E -d YourDatabaseName -i "path\to\Ranking_Top3_Products.sql"

```

Replace `"YourDatabaseName"` and `"path\to\Ranking_Top3_Products.sql"` with your actual database
name and file path.

---

## 📌 Notes

- Ensure the Products table doesn’t already exist, or the script will drop and recreate it.

- This script is intended for learning purposes and showcases differences between:

  - ROW_NUMBER()

  - RANK()

  - DENSE_RANK()

- Sample categories used:

  - Electronics

  - Appliances

  - Books

## ✅ Sample Output Preview

For `Category = 'Electronics'`, you might get the following:

| ProductName | Price | RowNum | Rank | DenseRank |
| ----------- | ----- | ------ | ---- | --------- |
| Laptop      | 85000 | 1      | 1    | 1         |
| Smartphone  | 55000 | 2      | 2    | 2         |
| Tablet      | 55000 | 3      | 2    | 2         |

---
