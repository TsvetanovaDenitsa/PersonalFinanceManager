CREATE DATABASE PersonalFinanceDB;
GO

USE PersonalFinanceDB;
GO

---------------------------------------------------
-- TABLE: Users
---------------------------------------------------

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    Username NVARCHAR(50) NOT NULL UNIQUE,

    Email NVARCHAR(100) NOT NULL UNIQUE,

    PasswordHash NVARCHAR(255) NOT NULL,

    FirstName NVARCHAR(50),

    LastName NVARCHAR(50),

    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

---------------------------------------------------
-- TABLE: Categories
---------------------------------------------------

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    Name NVARCHAR(100) NOT NULL UNIQUE,

    Description NVARCHAR(255)
);
GO

---------------------------------------------------
-- TABLE: Transactions
---------------------------------------------------

CREATE TABLE Transactions
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    UserId INT NOT NULL,

    CategoryId INT NOT NULL,

    Amount DECIMAL(18,2) NOT NULL,

    Description NVARCHAR(255),

    TransactionType NVARCHAR(20) NOT NULL,

    TransactionDate DATETIME DEFAULT GETDATE(),

    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Transactions_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(Id),

    CONSTRAINT FK_Transactions_Categories
    FOREIGN KEY (CategoryId)
    REFERENCES Categories(Id)
);
GO

---------------------------------------------------
-- TABLE: Budgets
---------------------------------------------------

CREATE TABLE Budgets
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    UserId INT NOT NULL,

    CategoryId INT NOT NULL,

    BudgetAmount DECIMAL(18,2) NOT NULL,

    StartDate DATE NOT NULL,

    EndDate DATE NOT NULL,

    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Budgets_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(Id),

    CONSTRAINT FK_Budgets_Categories
    FOREIGN KEY (CategoryId)
    REFERENCES Categories(Id)
);
GO

---------------------------------------------------
-- TABLE: SavingsGoals
---------------------------------------------------

CREATE TABLE SavingsGoals
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    UserId INT NOT NULL,

    GoalName NVARCHAR(100) NOT NULL,

    TargetAmount DECIMAL(18,2) NOT NULL,

    CurrentAmount DECIMAL(18,2) DEFAULT 0,

    Deadline DATE,

    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_SavingsGoals_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(Id)
);
GO

---------------------------------------------------
-- TABLE: Notifications
---------------------------------------------------

CREATE TABLE Notifications
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    UserId INT NOT NULL,

    Message NVARCHAR(255) NOT NULL,

    IsRead BIT DEFAULT 0,

    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Notifications_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(Id)
);
GO

---------------------------------------------------
-- INSERT DEFAULT CATEGORIES
---------------------------------------------------

INSERT INTO Categories(Name, Description)
VALUES
('Food', 'Food and groceries'),
('Transport', 'Transport expenses'),
('Bills', 'Monthly bills'),
('Entertainment', 'Movies, games, hobbies'),
('Health', 'Medical expenses'),
('Shopping', 'Clothes and shopping'),
('Education', 'Courses and books'),
('Salary', 'Monthly salary'),
('Freelance', 'Freelance income'),
('Investment', 'Investment income');
GO

---------------------------------------------------
-- SAMPLE USER
---------------------------------------------------

INSERT INTO Users
(
    Username,
    Email,
    PasswordHash,
    FirstName,
    LastName
)
VALUES
(
    'admin',
    'admin@financeapp.com',
    'admin123',
    'Admin',
    'User'
);
GO

---------------------------------------------------
-- SAMPLE TRANSACTIONS
---------------------------------------------------

INSERT INTO Transactions
(
    UserId,
    CategoryId,
    Amount,
    Description,
    TransactionType
)
VALUES
(1, 8, 2500.00, 'Monthly Salary', 'Income'),

(1, 1, 120.50, 'Supermarket', 'Expense'),

(1, 2, 45.00, 'Bus Card', 'Expense'),

(1, 4, 80.00, 'Cinema and dinner', 'Expense');
GO

---------------------------------------------------
-- VIEW: Monthly Expenses
---------------------------------------------------

CREATE VIEW vwMonthlyExpenses
AS
SELECT
    YEAR(TransactionDate) AS [Year],
    MONTH(TransactionDate) AS [Month],
    SUM(Amount) AS TotalExpenses
FROM Transactions
WHERE TransactionType = 'Expense'
GROUP BY
    YEAR(TransactionDate),
    MONTH(TransactionDate);
GO

---------------------------------------------------
-- VIEW: User Balance
---------------------------------------------------

CREATE VIEW vwUserBalance
AS
SELECT
    UserId,

    SUM(
        CASE
            WHEN TransactionType = 'Income'
            THEN Amount

            ELSE -Amount
        END
    ) AS Balance

FROM Transactions
GROUP BY UserId;
GO

---------------------------------------------------
-- STORED PROCEDURE: Add Transaction
---------------------------------------------------

CREATE PROCEDURE spAddTransaction
(
    @UserId INT,
    @CategoryId INT,
    @Amount DECIMAL(18,2),
    @Description NVARCHAR(255),
    @TransactionType NVARCHAR(20)
)
AS
BEGIN

    INSERT INTO Transactions
    (
        UserId,
        CategoryId,
        Amount,
        Description,
        TransactionType
    )
    VALUES
    (
        @UserId,
        @CategoryId,
        @Amount,
        @Description,
        @TransactionType
    );

END;
GO

---------------------------------------------------
-- STORED PROCEDURE: Get User Transactions
---------------------------------------------------

CREATE PROCEDURE spGetUserTransactions
(
    @UserId INT
)
AS
BEGIN

    SELECT
        t.Id,
        c.Name AS Category,
        t.Amount,
        t.Description,
        t.TransactionType,
        t.TransactionDate

    FROM Transactions t

    INNER JOIN Categories c
        ON t.CategoryId = c.Id

    WHERE t.UserId = @UserId

    ORDER BY t.TransactionDate DESC;

END;
GO

---------------------------------------------------
-- STORED PROCEDURE: Delete Transaction
---------------------------------------------------

CREATE PROCEDURE spDeleteTransaction
(
    @TransactionId INT
)
AS
BEGIN

    DELETE FROM Transactions
    WHERE Id = @TransactionId;

END;
GO