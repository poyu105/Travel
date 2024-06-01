USE [Travel]; -- YourDatabaseName替換成你的資料庫名稱，我是用Travel

-- Table: User
CREATE TABLE [User] (
  id INT IDENTITY(1,1) PRIMARY KEY,
  account VARCHAR(20) NOT NULL,
  [password] VARCHAR(60) NOT NULL,
  identity_card VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- Table: Journey
CREATE TABLE Journey (
  id INT IDENTITY(1,1) PRIMARY KEY,
  place VARCHAR(255) NOT NULL,
<<<<<<< HEAD
  start_date DATETIME2,
  end_date DATETIME2,
  created_at DATETIME2 DEFAULT GETDATE(),
  updated_at DATETIME2 DEFAULT GETDATE()
=======
  start_date DATETIME2 NOT NULL,
  end_date DATETIME2 NOT NULL,
  created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
>>>>>>> fe5c82136ab9efd66c102fc6fc17681e0b4191f6
);

-- Table: Reservation
CREATE TABLE Reservation (
  id INT IDENTITY(1,1) PRIMARY KEY,
  people INT NOT NULL,
  [status] INT NOT NULL,
  user_id INT FOREIGN KEY REFERENCES [User](id),
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  remark VARCHAR(255),
  created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- Table: Admin
CREATE TABLE Admin (
  id INT IDENTITY(1,1) PRIMARY KEY,
  user_id INT NOT NULL FOREIGN KEY REFERENCES [User](id),
  created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

<<<<<<< HEAD
-- Table: Attractions
CREATE TABLE Attraction (
  id INT PRIMARY KEY NOT NULL,
  [name] VARCHAR(255),
  [description] VARCHAR(255) NOT NULL,
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  created_at DATETIME2 DEFAULT GETDATE(),
  updated_at DATETIME2 DEFAULT GETDATE()
=======
-- Table: Attraction
CREATE TABLE Attraction (
  id INT IDENTITY(1,1) PRIMARY KEY,
  [name] VARCHAR(255),
  [description] VARCHAR(255) NOT NULL,
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
>>>>>>> fe5c82136ab9efd66c102fc6fc17681e0b4191f6
);

