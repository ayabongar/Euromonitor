USE [Euromonitor]
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Insert]    Script Date: 2024/11/06 11:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_Book_Insert]
    @Name NVARCHAR(100),
    @Text NVARCHAR(MAX),
    @PurchasePrice DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Books (Name, Text, PurchasePrice)
    VALUES (@Name, @Text, @PurchasePrice);

    -- Return the ID of the newly added book
    SELECT SCOPE_IDENTITY() AS BookId;
END


-----------------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[usp_Book_SelectAll]    Script Date: 2024/11/06 11:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Book_SelectAll]
AS
BEGIN
    SELECT * FROM Books;
END;



-----------------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[usp_Subscription_Delete]    Script Date: 2024/11/06 11:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_Subscription_Delete]
    @UserId INT,
    @BookId INT
AS
BEGIN
    DELETE FROM Subscriptions WHERE UserId = @UserId AND BookId = @BookId;
END;



-----------------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[usp_Subscription_Insert]    Script Date: 2024/11/06 11:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_Subscription_Insert]
    @UserId INT,
    @BookId INT
AS
BEGIN
    INSERT INTO Subscriptions (UserId, BookId)
    VALUES (@UserId, @BookId);
END;



-----------------------------------------------------------------------------------------------------------------


/****** Object:  StoredProcedure [dbo].[usp_Subscription_SelectByUserId]    Script Date: 2024/11/06 11:40:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_Subscription_SelectByUserId]
    @UserId INT
AS
BEGIN
    SELECT BookId FROM Subscriptions WHERE UserId = @UserId;
END;



-----------------------------------------------------------------------------------------------------------------


/****** Object:  StoredProcedure [dbo].[usp_User_Insert]    Script Date: 2024/11/06 11:41:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_User_Insert]
    @Email NVARCHAR(255),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Users (Email, FirstName, LastName)
    VALUES (@Email, @FirstName, @LastName);
    
    SELECT SCOPE_IDENTITY() AS NewUserId;
END;


-----------------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[usp_User_SelectAll]    Script Date: 2024/11/06 11:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_User_SelectAll]
AS
BEGIN
    SELECT * FROM Users;
END;



-----------------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[usp_User_SelectById]    Script Date: 2024/11/06 11:41:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[usp_User_SelectById]
    @UserId INT
AS
BEGIN
    SELECT * FROM Users WHERE Id = @UserId;
END;