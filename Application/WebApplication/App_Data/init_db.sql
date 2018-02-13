IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Account_PlanOfAccounts]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Account] DROP CONSTRAINT [FK_Account_PlanOfAccounts]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Citizenship]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Citizenship]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Disability]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Disability]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_MartialStatus]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_MartialStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Town]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Town]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit] DROP CONSTRAINT [FK_Credit_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_Account_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit] DROP CONSTRAINT [FK_Credit_Account_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_Client]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit] DROP CONSTRAINT [FK_Credit_Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_PlantOfCredits]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit] DROP CONSTRAINT [FK_Credit_PlantOfCredits]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit] DROP CONSTRAINT [FK_Deposit_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_Account_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit] DROP CONSTRAINT [FK_Deposit_Account_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_Client]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit] DROP CONSTRAINT [FK_Deposit_Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_PlanOfDeposits]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit] DROP CONSTRAINT [FK_Deposit_PlanOfDeposits]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfCredit_PlanOfAccount]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfCredit] DROP CONSTRAINT [FK_PlanOfCredit_PlanOfAccount]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfCredit_PlanOfAccount_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfCredit] DROP CONSTRAINT [FK_PlanOfCredit_PlanOfAccount_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfDeposit_PlanOfAccount]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfDeposit] DROP CONSTRAINT [FK_PlanOfDeposit_PlanOfAccount]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfDeposit_PlanOfAccount_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfDeposit] DROP CONSTRAINT [FK_PlanOfDeposit_PlanOfAccount_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Transaction_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Transaction] DROP CONSTRAINT [FK_Transaction_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Transaction_Account_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Transaction] DROP CONSTRAINT [FK_Transaction_Account_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Account]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Citizenship]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Citizenship]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Client]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Credit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Credit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Deposit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Deposit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Disability]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Disability]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[MartialStatus]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [MartialStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfAccount]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfAccount]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfCredit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfCredit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfDeposit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfDeposit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SystemVariables]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [SystemVariables]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Town]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Town]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Transaction]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Transaction]
;

CREATE TABLE [Account]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[PlanId] int NOT NULL,
	[AccountNumber] varchar(13) NOT NULL,
	[DebitValue] money NOT NULL,
	[CreditValue] money NOT NULL,
	[Balance] money NOT NULL
)
;

CREATE TABLE [Citizenship]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Country] varchar(50) NOT NULL
)
;

CREATE TABLE [Client]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Surname] varchar(50) NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Patronymic] varchar(50) NOT NULL,
	[BirthDate] date NOT NULL,
	[Male] bit NOT NULL,
	[PassportSeries] varchar(2) NOT NULL,
	[PassportNumber] varchar(7) NOT NULL,
	[IssuedBy] varchar(100) NOT NULL,
	[IssueDate] date NOT NULL,
	[IdentificationNumber] varchar(50) NOT NULL,
	[BirthPlace] varchar(50) NOT NULL,
	[ResidenceActualPlaceId] int NOT NULL,
	[ResidenceActualAddress] varchar(50) NOT NULL,
	[HomePhoneNumber] varchar(50),
	[MobilePhoneNumber] varchar(50),
	[Email] varchar(50),
	[ResidenceAddress] varchar(100) NOT NULL,
	[MaritalStatusId] int NOT NULL,
	[CitezenshipId] int NOT NULL,
	[DisabilityId] int NOT NULL,
	[Pensioner] bit NOT NULL,
	[MonthlyIncome] money
)
;

CREATE TABLE [Credit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[ClientId] int NOT NULL,
	[PlanId] int NOT NULL,
	[StartDate] int NOT NULL,
	[EndDate] int NOT NULL,
	[Amount] money NOT NULL,
	[MainAccountId] int NOT NULL,
	[PercentAccountId] int NOT NULL,
	[CreditCardPin] varchar(4)
)
;

CREATE TABLE [Deposit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[ClientId] int NOT NULL,
	[PlanId] int NOT NULL,
	[StartDate] int NOT NULL,
	[EndDate] int NOT NULL,
	[MainAccountId] int NOT NULL,
	[PercentAccountId] int NOT NULL,
	[Amount] money NOT NULL
)
;

CREATE TABLE [Disability]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Status] varchar(50) NOT NULL
)
;

CREATE TABLE [MartialStatus]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Status] varchar(50) NOT NULL
)
;

CREATE TABLE [PlanOfAccount]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[AccountNumber] nvarchar(4) NOT NULL,
	[AccountName] nvarchar(50) NOT NULL,
	[AccountType] nvarchar(1) NOT NULL
)
;

CREATE TABLE [PlanOfCredit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[BankDayPeriod] int NOT NULL,
	[Percent] float NOT NULL,
	[Anuity] bit NOT NULL,
	[MinAmount] money,
	[MainAccountId] int NOT NULL,
	[PercentAccountId] int NOT NULL
)
;

CREATE TABLE [PlanOfDeposit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[BankDayPeriod] int NOT NULL,
	[Percent] float NOT NULL,
	[Revocable] bit NOT NULL,
	[MinAmount] money,
	[MainAccountPlanId] int NOT NULL,
	[PercentAccountPlanId] int NOT NULL
)
;

CREATE TABLE [SystemVariables]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[CurrentBankDay] int NOT NULL,
	[StartBankDay] int NOT NULL,
	[StartDate] date NOT NULL
)
;

CREATE TABLE [Town]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[Country] varchar(50) NOT NULL
)
;

CREATE TABLE [Transaction]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[DebetAccountId] int NOT NULL,
	[CreditAccountId] int NOT NULL,
	[Amount] money NOT NULL
)
;

ALTER TABLE [Account] 
 ADD CONSTRAINT [PK_Account]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Citizenship] 
 ADD CONSTRAINT [PK_Citizenship]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [PK_Client]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UQ_Client_PassportSeries_PassportNumber] UNIQUE NONCLUSTERED ([PassportSeries],[PassportNumber])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UQ_Client_IdentificationNumber] UNIQUE NONCLUSTERED ([IdentificationNumber])
;

ALTER TABLE [Credit] 
 ADD CONSTRAINT [PK_Credit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Deposit] 
 ADD CONSTRAINT [PK_Deposit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Disability] 
 ADD CONSTRAINT [PK_Disability]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [MartialStatus] 
 ADD CONSTRAINT [PK_MartialStatus]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [PlanOfAccount] 
 ADD CONSTRAINT [PK_PlanOfAccount]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [PlanOfCredit] 
 ADD CONSTRAINT [PK_PlanOfCredit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [PlanOfDeposit] 
 ADD CONSTRAINT [PK_PlanOfDeposit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [SystemVariables] 
 ADD CONSTRAINT [PK_SystemVariables]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Town] 
 ADD CONSTRAINT [PK_Town]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Transaction] 
 ADD CONSTRAINT [PK_Transaction]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Account] ADD CONSTRAINT [FK_Account_PlanOfAccounts]
	FOREIGN KEY ([PlanId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Citizenship]
	FOREIGN KEY ([CitezenshipId]) REFERENCES [Citizenship] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Disability]
	FOREIGN KEY ([DisabilityId]) REFERENCES [Disability] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_MartialStatus]
	FOREIGN KEY ([MaritalStatusId]) REFERENCES [MartialStatus] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Town]
	FOREIGN KEY ([ResidenceActualPlaceId]) REFERENCES [Town] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit] ADD CONSTRAINT [FK_Credit_Account]
	FOREIGN KEY ([MainAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit] ADD CONSTRAINT [FK_Credit_Account_02]
	FOREIGN KEY ([PercentAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit] ADD CONSTRAINT [FK_Credit_Client]
	FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit] ADD CONSTRAINT [FK_Credit_PlantOfCredits]
	FOREIGN KEY ([PlanId]) REFERENCES [PlanOfCredit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit] ADD CONSTRAINT [FK_Deposit_Account]
	FOREIGN KEY ([MainAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit] ADD CONSTRAINT [FK_Deposit_Account_02]
	FOREIGN KEY ([PercentAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit] ADD CONSTRAINT [FK_Deposit_Client]
	FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit] ADD CONSTRAINT [FK_Deposit_PlanOfDeposits]
	FOREIGN KEY ([PlanId]) REFERENCES [PlanOfDeposit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfCredit] ADD CONSTRAINT [FK_PlanOfCredit_PlanOfAccount]
	FOREIGN KEY ([MainAccountId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfCredit] ADD CONSTRAINT [FK_PlanOfCredit_PlanOfAccount_02]
	FOREIGN KEY ([PercentAccountId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfDeposit] ADD CONSTRAINT [FK_PlanOfDeposit_PlanOfAccount]
	FOREIGN KEY ([MainAccountPlanId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfDeposit] ADD CONSTRAINT [FK_PlanOfDeposit_PlanOfAccount_02]
	FOREIGN KEY ([PercentAccountPlanId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Transaction] ADD CONSTRAINT [FK_Transaction_Account]
	FOREIGN KEY ([DebetAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Transaction] ADD CONSTRAINT [FK_Transaction_Account_02]
	FOREIGN KEY ([CreditAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;
