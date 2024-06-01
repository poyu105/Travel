
-- Table: User
CREATE TABLE [User] (
  id INT IDENTITY(1,1) PRIMARY KEY,
  account VARCHAR(20) NOT NULL,
  [password] VARCHAR(60) NOT NULL,
  identity_card VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  created_at DATE NOT NULL DEFAULT GetDate(),
  updated_at DATE NOT NULL DEFAULT GetDate()
);

-- Table: Journey
CREATE TABLE Journey (
  id INT IDENTITY(1,1) PRIMARY KEY,
  place VARCHAR(255) NOT NULL,
  start_date DATETIME2 NOT NULL,
  end_date DATETIME2 NOT NULL,
  created_at DATE NOT NULL DEFAULT GetDate(),
  updated_at DATE NOT NULL DEFAULT GetDate()
);

-- Table: Reservation
CREATE TABLE Reservation (
  id INT IDENTITY(1,1) PRIMARY KEY,
  people INT NOT NULL,
  [status] INT NOT NULL,
  user_id INT FOREIGN KEY REFERENCES [User](id),
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  remark VARCHAR(255),
  created_at DATE NOT NULL DEFAULT GetDate(),
  updated_at DATE NOT NULL DEFAULT GetDate()
);

-- Table: Admin
CREATE TABLE Admin (
  id INT IDENTITY(1,1) PRIMARY KEY,
  user_id INT NOT NULL FOREIGN KEY REFERENCES [User](id),
  created_at DATE NOT NULL DEFAULT GetDate(),
  updated_at DATE NOT NULL DEFAULT GetDate()
);

-- Table: Attraction
CREATE TABLE Attraction (
  id INT IDENTITY(1,1) PRIMARY KEY,
  [name] VARCHAR(255),
  [description] VARCHAR(255) NOT NULL,
  Journey_id INT NOT NULL FOREIGN KEY REFERENCES Journey(id),
  created_at DATE NOT NULL DEFAULT GetDate(),
  updated_at DATE NOT NULL DEFAULT GetDate()
);