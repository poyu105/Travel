-- 假資料 User
INSERT INTO [User] (id, account, [password], identity_card, email, created_at, updated_at)
VALUES
(1, 'user', 'password', 'A123456789', 'user@example.com', GETDATE(), GETDATE()),
(2, 'admin', 'admin', 'B123456789', 'admin@example.com', GETDATE(), GETDATE()),
(3, 'user2', 'password', 'C123456789', 'user2@example.com', GETDATE(), GETDATE()),
(4, 'user3', 'password', 'D123456789', 'user3@example.com', GETDATE(), GETDATE()),
(5, 'admin2', 'admin2', 'E123456789', 'admin2@example.com', GETDATE(), GETDATE());

-- 假資料 Travel
INSERT INTO Journey (id, place, start_date, end_date, created_at, updated_at)
VALUES
(1, 'Destination A', '2024-05-15', '2024-05-20', GETDATE(), GETDATE()),
(2, 'Destination B', '2024-06-10', '2024-06-15', GETDATE(), GETDATE()),
(3, 'Destination C', '2024-07-01', '2024-07-07', GETDATE(), GETDATE()),
(4, 'Destination D', '2024-08-05', '2024-08-10', GETDATE(), GETDATE()),
(5, 'Destination E', '2024-09-20', '2024-09-25', GETDATE(), GETDATE());

-- 假資料 Reservation
INSERT INTO Reservation (id, people, [status], user_id, Journey_id, remark, created_at, updated_at)
VALUES
(1, 2, 1, 1, 1, 'Remark for reservation 1', GETDATE(), GETDATE()),
(2, 3, 1, 2, 2, 'Remark for reservation 2', GETDATE(), GETDATE()),
(3, 1, 2, 3, 3, 'Remark for reservation 3', GETDATE(), GETDATE()),
(4, 4, 1, 4, 4, 'Remark for reservation 4', GETDATE(), GETDATE()),
(5, 2, 1, 5, 5, 'Remark for reservation 5', GETDATE(), GETDATE());

-- 假資料 Admin
INSERT INTO Admin (id, user_id, created_at, updated_at)
VALUES
(1, 2, GETDATE(), GETDATE());

-- 假資料 Attractions
INSERT INTO Attractions (id, place, [description], picture, icon_num, Journey_id, created_at, updated_at)
VALUES
(1, 'Attraction A', 'Description for Attraction A', 'picture_url_for_attraction_a.jpg', '1', 1, GETDATE(), GETDATE()),
(2, 'Attraction B', 'Description for Attraction B', 'picture_url_for_attraction_b.jpg', '2', 1, GETDATE(), GETDATE()),
(3, 'Attraction C', 'Description for Attraction C', 'picture_url_for_attraction_c.jpg', '3', 1, GETDATE(), GETDATE()),
(4, 'Attraction D', 'Description for Attraction D', 'picture_url_for_attraction_d.jpg', '1', 1, GETDATE(), GETDATE()),
(5, 'Attraction E', 'Description for Attraction E', 'picture_url_for_attraction_e.jpg', '2', 1, GETDATE(), GETDATE());
