USE [YourDatabaseName]; -- YourDatabaseName替換成你的資料庫名稱，我是用Travel

-- Table: User
CREATE TABLE [User] (
  id INT PRIMARY KEY NOT NULL,
  account VARCHAR(20) NOT NULL,
  [password] VARCHAR(60) NOT NULL,
  identity_card VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  create_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  update_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: Travel
CREATE TABLE Travel (
  id INT PRIMARY KEY NOT NULL,
  place VARCHAR(60) NOT NULL,
  [description] VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,
  create_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  update_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: Reservation
CREATE TABLE Reservation (
  id INT PRIMARY KEY NOT NULL,
  people INT NOT NULL,
  [status] INT NOT NULL,
  user_id INT FOREIGN KEY REFERENCES [User](id),
  attractions INT NOT NULL FOREIGN KEY REFERENCES Travel(id),
  remark VARCHAR(255),
  create_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  update_at DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Table: admin
CREATE TABLE admin (
  id INT PRIMARY KEY NOT NULL,
  user_id INT NOT NULL FOREIGN KEY REFERENCES [User](id),
  created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
  updated_at DATETIME2 NOT NULL DEFAULT GETDATE()
);