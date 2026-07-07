USE [UniPlan];
GO

-- Ensure students exist (if not, create them)
DECLARE @PersonID INT, @AccountID INT, @Result BIT;
DECLARE @StudentID1 INT = 1, @StudentID2 INT = 2;

IF NOT EXISTS (SELECT 1 FROM Students WHERE StudentID = @StudentID1)
BEGIN
    EXEC SP_StudentProfile_Insert 
        @FirstName = N'أحمد', 
        @MiddleName = N'علي', 
        @LastName = N'حسن',
        @PersonID = @PersonID OUTPUT,
        @AccountName = N'ahmed.ali', 
        @Password = N'pass123', 
        @Email = N'ahmed@example.com', 
        @AccountID = @AccountID OUTPUT,
        @StudentID = @StudentID1, 
        @MajorID = 1, 
        @Result = @Result OUTPUT;
END

IF NOT EXISTS (SELECT 1 FROM Students WHERE StudentID = @StudentID2)
BEGIN
    EXEC SP_StudentProfile_Insert 
        @FirstName = N'سارة', 
        @MiddleName = N'خالد', 
        @LastName = N'محمد',
        @PersonID = @PersonID OUTPUT,
        @AccountName = N'sara.khaled', 
        @Password = N'pass456', 
        @Email = N'sara@example.com', 
        @AccountID = @AccountID OUTPUT,
        @StudentID = @StudentID2, 
        @MajorID = 1, 
        @Result = @Result OUTPUT;
END

-- Now proceed with the rest (Term, WishList, etc.)
DECLARE @TermID INT = (SELECT TermID FROM AcademicTerms WHERE TermYear = 2026 AND TermType = 2);
DECLARE @RegistrationID INT;
DECLARE @WishListID INT;
DECLARE @ItemID INT;

-- For Student 1
IF NOT EXISTS (SELECT 1 FROM StudentTerms WHERE StudentID = @StudentID1 AND TermID = @TermID)
BEGIN
    EXEC SP_StudentTerms_Insert @StudentID1, @TermID, @RegistrationID OUTPUT;
END
ELSE
BEGIN
    SELECT @RegistrationID = RegistrationID FROM StudentTerms WHERE StudentID = @StudentID1 AND TermID = @TermID;
END

EXEC SP_WishLists_Insert @RegistrationID, @WishListID OUTPUT;

EXEC SP_WishListItems_Insert @WishListID, 53, @ItemID OUTPUT; -- تطوير التطبيقات
EXEC SP_WishListItems_Insert @WishListID, 52, @ItemID OUTPUT; -- تصميم المترجمات
EXEC SP_WishListItems_Insert @WishListID, 58, @ItemID OUTPUT; -- وسائط معطيات
EXEC SP_WishListItems_Insert @WishListID, 43, @ItemID OUTPUT; -- تراسل 1
EXEC SP_WishListItems_Insert @WishListID, 50, @ItemID OUTPUT; -- أمن نظم معلومات

-- For Student 2
IF NOT EXISTS (SELECT 1 FROM StudentTerms WHERE StudentID = @StudentID2 AND TermID = @TermID)
BEGIN
    EXEC SP_StudentTerms_Insert @StudentID2, @TermID, @RegistrationID OUTPUT;
END
ELSE
BEGIN
    SELECT @RegistrationID = RegistrationID FROM StudentTerms WHERE StudentID = @StudentID2 AND TermID = @TermID;
END

EXEC SP_WishLists_Insert @RegistrationID, @WishListID OUTPUT;

EXEC SP_WishListItems_Insert @WishListID, 53, @ItemID OUTPUT;
EXEC SP_WishListItems_Insert @WishListID, 52, @ItemID OUTPUT;

GO