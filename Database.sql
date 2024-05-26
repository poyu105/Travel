USE [Travel]; -- YourDatabaseName替換成你的資料庫名稱，我是用Travel

-- Table: User
CREATE TABLE [User] (
  id INT PRIMARY KEY NOT NULL,
  account VARCHAR(20) NOT NULL,
  [password] VARCHAR(60) NOT NULL,
  identity_card VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  updated_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: Journey
CREATE TABLE Journey (
  id INT PRIMARY KEY NOT NULL,
  place VARCHAR(255) NOT NULL,
  icon_num INT NOT NULL,
  start_date DATETIME2 NOT NULL,
  end_date DATETIME2 NOT NULL,
  created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  updated_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: Reservation
CREATE TABLE Reservation (
  id INT PRIMARY KEY NOT NULL,
  people INT NOT NULL,
  [status] INT NOT NULL,
  user_id INT FOREIGN KEY REFERENCES [User](id),
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  remark VARCHAR(255),
  created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  updated_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: Admin
CREATE TABLE Admin (
  id INT PRIMARY KEY NOT NULL,
  user_id INT NOT NULL FOREIGN KEY REFERENCES [User](id),
  created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  updated_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: Attractions
CREATE TABLE Attractions (
  id INT PRIMARY KEY NOT NULL,
  place VARCHAR(255),
  [description] VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  updated_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

