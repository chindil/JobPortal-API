using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class Add_SPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"

/****** Object:  StoredProcedure [dbo].[LogDocumentTransactions]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[LogDocumentTransactions]
GO

/****** Object:  StoredProcedure [dbo].[RptIPDocument]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[RptIPDocument]
GO

/****** Object:  StoredProcedure [dbo].[SearchTrademarkLevenstn]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[SearchTrademarkLevenstn]
GO

/****** Object:  StoredProcedure [dbo].[HRMCorporateJobList]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMCorporateJobList]
GO

/****** Object:  StoredProcedure [dbo].[HRMTalentSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMTalentSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobCandidateListByStage]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMJobCandidateListByStage]
GO

/****** Object:  StoredProcedure [dbo].[CRMCorporateSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[CRMCorporateSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMCandidateJobStatSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMCandidateJobStatSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMCandidatePublicInfo]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMCandidatePublicInfo]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobOrderPreview]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMJobOrderPreview]
GO

/****** Object:  StoredProcedure [dbo].[CRMCorporatePreview]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[CRMCorporatePreview]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobOrderSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMJobOrderSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobOrderSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2020-09-06
-- Description:	HRM Job Search; Returns list of job orders and related information.
-- =============================================

/*
	EXEC [HRMJobOrderSearch] '', '', '', ''
	EXEC [HRMJobOrderSearch] '', '', '', '',@CandidateID='100'
	EXEC [HRMJobOrderSearch] '', '', '', '',@CandidateID='100',@CorporateID=0
	EXEC [HRMJobOrderSearch] @Keyword=N'',@Location=N'',@JobIndustry=N'',@CandidateID=100,@CorporateID=0,@SearchMode=N''
*/
CREATE PROCEDURE [dbo].[HRMJobOrderSearch] 
	@SearchMode Nvarchar(50)=NULL,
	@CandidateID int=NULL,
	@CorporateID int=NULL,
	@Keyword nvarchar(50)=null, 
	@Location Nvarchar(50)=null,
	@JobIndustry Nvarchar(50)=NULL,
	@CareerLevels NVARCHAR(50)=null,
	@EmploymentTypes NVARCHAR(50)=null,
	@SalaryFrom NUMERIC(18,2)=null,
	@SalaryTo NUMERIC(18,2)=null,
	@EmployerTypes NVARCHAR(50)=null,
	@JobSpecialties NVARCHAR(50)=null
AS
BEGIN	
	SET NOCOUNT ON;
	    
	--PRINT '@@Keyword ' + @Keyword
	--PRINT '@@Location ' +@Location 
	--PRINT '@@JobIndustry ' +@JobIndustry 
	--PRINT '@@JobSpecialties ' +@JobSpecialties 
	--PRINT '@@CareerLevels ' +@CareerLevels 
	--PRINT '@@EmploymentTypes ' +@EmploymentTypes 
	--PRINT '@@SalaryFrom ' +@SalaryFrom 
	--PRINT '@@SalaryTo ' +@SalaryTo 
	--PRINT '@@EmployerTypes ' +@EmployerTypes 
	--PRINT '@@SearchMode ' +@SearchMode 
	--PRINT '@@CorporateID ' +@CorporateID 
	--PRINT '@@CandidateID ' +@CandidateID 

	IF(@Keyword='') Set @Keyword=null ELSE SET @Keyword=CONCAT('%', @Keyword, '%')
	IF(@Location='') Set @Location=null ELSE SET @Location=CONCAT('%', @Location, '%')
	IF(@JobIndustry='') Set @JobIndustry=null ELSE SET @JobIndustry=CONCAT('%', @JobIndustry, '%')
	IF(@CorporateID <= 0) Set @CorporateID=null
	
	SELECT TOP 50 T0.JobOrderID, T0.JobCode, T0.Title, T2.Name[Country], T0.[Location], T0.[Description], T0.Requirements, T0.Benefits, 
		Isnull(T0.IsShowSalary, 0)[IsShowSalary], IIF(T0.IsShowSalary=1, T0.Salary, 0)[Salary], IIF(T0.IsShowSalary=1, T0.SalaryTo, 0)[SalaryTo], 
		T0.SalaryCurrCD, CAST(T0.SalaryPayCycle AS NVARCHAR)[SalaryPayCycle], CAST(T0.EmploymentType AS NVARCHAR)EmploymentType, 
		T4.Name[JobIndustry], T5.Name[JobSpecialty], T0.JobHoursPerWeek, T0.NumOfAvilJobs, T0.FileAttachments, 
		T0.Comments, T0.TravelRequirements, 
		T0.CorporateID, T0.CorporateContact, T0.CorporateAddress, T0.DateStart, T0.DateEnd, 
		T0.ApplyByEmail, T0.ApplyByMobileNum,		
		T1.[Name][CorporateName], T1.[Address], T1.[Address2], T1.PostalCode, T1.City, T1.[State], T1.Website, T1.Phone, T1.Privacy,
		T2.[Name][CorporateCountryName],
		-1 [ResumeSubmitCount],
		''[SalaryUnit], 
		CAST(IIF(T6.JobOrderID IS NULL, 0, 1) AS bit)[IsBookmarked]
		
	FROM HrJobOrder T0  WITH (NOLOCK)
		LEFT OUTER JOIN Corporate T1 on T0.CorporateID = T1.CorporateID
		LEFT OUTER JOIN Country T2 on T1.CountryID = T2.CountryID
		LEFT OUTER JOIN City T3 on T0.[Location] = T3.Name 
		LEFT OUTER JOIN HrJobIndustry T4 on T0.JobIndustry = T4.ID
		LEFT OUTER JOIN HrJobSpecialty T5 on T0.JobSpecialty = T5.ID
		LEFT OUTER JOIN (SELECT DISTINCT TJS.JobOrderID FROM HrCandidateJobStat TJS WHERE TJS.CandidateID = @CandidateID) T6 ON T6.JobOrderID = T0.JobOrderID
	Where isnull(T0.IsDeleted,0) = 0 
		AND (@Keyword is null OR T0.Title like (@Keyword)) 
		AND (@Location is null OR T3.[Name] LIKE (@Location))
		AND (@JobIndustry is null OR T0.JobIndustry LIKE (@JobIndustry))
		AND (@CorporateID is null OR T0.CorporateID = @CorporateID)
		

	--Log Candidate search insights=============================================
	IF(ISNUMERIC(@CandidateID)=1 AND CAST(@CandidateID AS INT) > 0)
	BEGIN 
		Declare @var int; --Insert insights CREATE & CALL A SP
	END
	--==========================================================================
	
END



GO

/****** Object:  StoredProcedure [dbo].[CRMCorporatePreview]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Dilhan
-- Create date: 2020-09-06
-- Description:	CRM Corporate details; Returns all related info for a selected corporate entity.
-- Return DTO:	CorporatePublicDTO				
-- =============================================

/*
	EXEC [CRMCorporatePreview] 1, 1
*/
CREATE PROCEDURE [dbo].[CRMCorporatePreview] 
	@CorporateID int,
	@UserName nvarchar(256)
AS
BEGIN	
	SET NOCOUNT ON;
	    
	SELECT T0.CorporateID, T0.UserName, T0.CorporateType, T0.CorporateGroup, T0.[Name], T0.ShortName, T0.LegalType, T0.Category, 
		T0.[Address],T0.[Address2], T0.PostalCode, T0.City, T0.State, T0.CountryID, T0.Nationality, T0.Website, 
		T0.Phone, T0.Phone2, T0.Mobile, T0.Fax, T0.Email, T0.Email2, T0.CurrCD, T0.Remarks, 
		T0.Reference1, T0.Reference2, T0.Reference3, T0.RefObject, T0.CompanyLawyers, T0.CommercialRegInfo, T0.CommercialRegNum, 
		T0.Privacy, T0.[Source], T0.ImportRef, T0.DateAdded, T0.DateLastModified,	
		T2.[Name][CountryName]

	FROM Corporate T0 WITH (NOLOCK)
		LEFT OUTER JOIN Country T2 on T0.CountryID = T2.CountryID
	Where T0.CorporateID = @CorporateID --and isnull(T0.Active, 1) = 1 and isnull(T0.IsDeleted,0) = 0
		--AND (Privacy='' AND T0.UserName = @UserName)


END



GO

/****** Object:  StoredProcedure [dbo].[HRMJobOrderPreview]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2020-09-06
-- Description:	HRM Job order details; Returns all related info for a job order.
--				This includes the current CandidateId to be used to submit the job, if the user opt to submit.
--Output DTO:	HrJobOrderPreview
--Related SPs:	HRMJobOrderPreview, returns the same DTO type
-- =============================================

/*
	EXEC [HRMJobOrderPreview] 2, 100
*/
CREATE PROCEDURE [dbo].[HRMJobOrderPreview] 
	@JobOrderID int, 
	@CandidateID int 
AS
BEGIN	
	SET NOCOUNT ON;
	    
	SELECT ISNULL(@CandidateID,0)[CandidateID], T0.JobOrderID, T0.JobCode, T0.Title, T0.Country, T0.[Location], T0.[Description], T0.Requirements, T0.Benefits, 
		Isnull(T0.IsShowSalary, 0)[IsShowSalary], IIF(T0.IsShowSalary=1, T0.Salary, 0)[Salary], IIF(T0.IsShowSalary=1, T0.SalaryTo, 0)[SalaryTo], 
		T0.SalaryCurrCD, T0.SalaryPayCycle, T0.EmploymentType, T0.JobIndustry, T0.JobSpecialty, T0.JobHoursPerWeek, T0.NumOfAvilJobs, T0.FileAttachments, 
		--0[MinYearsExpRequired], 0[MinCareerLevel], 0[MinEducationLevel], 
		T0.Comments, T0.TravelRequirements, 
		T0.CorporateID, T0.CorporateContact, T0.CorporateAddress, T0.CorporateOperationHours, T0.JobPostPrivacy, 
		T0.DateStart, T0.DateEnd, T0.DateClosed, T0.DateLastPublished, T0.DateAdded, T0.[Status], 
		--'' AS ReportToName, '' AS ReportToClientContact, 
		T0.ApplyByEmail, T0.ApplyByMobileNum,
		
		T1.[Name][CorporateName], T1.[Address], T1.[Address2], T1.PostalCode, T1.City, T1.[State], T1.Website, T1.Phone, T1.Privacy,
		T2.[Name][CountryName],
		(SELECT TOP 1 TJO.ID FROM HrJobSendout TJO WHERE TJO.CandidateID = @CandidateID AND TJO.JobOrderID = @JobOrderID) [PrevSendoutID], 
		CAST(IIF(T6.JobOrderID IS NULL, 0, 1) AS bit)[IsBookmarked]
		
	FROM HrJobOrder T0  WITH (NOLOCK)
		LEFT OUTER JOIN Corporate T1 on T0.CorporateID = T1.CorporateID
		LEFT OUTER JOIN Country T2 on T1.CountryID = T2.CountryID
		LEFT OUTER JOIN (SELECT DISTINCT TJS.JobOrderID FROM HrCandidateJobStat TJS WHERE TJS.CandidateID = @CandidateID) T6 ON T6.JobOrderID = T0.JobOrderID

	Where T0.JobOrderID = @JobOrderID and isnull(T0.IsDeleted,0) = 0

END




GO

/****** Object:  StoredProcedure [dbo].[HRMCandidatePublicInfo]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2020-10-06
-- Description:	HRM Candidate Search; Returns list of candidates and related information.
-- Related SPs:	HRMTalentSearch, HRMCandidateSearch, HRMCandidatePublicInfo, HRMCandidatePublicListByStage returns the same DTO type
-- =============================================

/*
	EXEC [HRMCandidatePublicInfo] 'A', 100, null
*/
CREATE PROCEDURE [dbo].[HRMCandidatePublicInfo]
	@CandidateSource nvarchar(5)= 'A',
	@CandidateID int,
	@JobOrderID int = null
AS
BEGIN	
	SET NOCOUNT ON;
	    
	If(@CandidateSource='A')
	BEGIN
		SELECT TOP 50 T0.CandidateID, T0.UserName, T0.FirstName, T0.MiddleName, T0.LastName, T0.NickName,
			T0.Gender, T0.NamePrefix, T0.NameSuffix, T0.Nationality, T0.Mobile, T0.Phone, T0.Phone2, T0.WorkPhone, T0.Email,
			T0.Email2, T0.Fax, T0.Fax2, T0.Address, T0.PostalCode, T0.SecondaryAddress, T0.MaritalStatus, T0.DateOfBirth, T0.DateAvailable,
			T0.DateLastComment, T0.DateLastModified, T0.DateNextCall, T0.TimeZoneOffsetEST, T0.Active, T0.Disability, 
			'A'[CandidateSource], cast(null as int)[JobOrderID]
			,T1.DateAdded[DateApplied], T1.Title[JobTitle],''[City],''[CountryName],
			T0.CurrOccupation
		FROM HrCandidate T0  WITH (NOLOCK)
			LEFT OUTER JOIN HrJobCategory T4 on T0.JobIndustry = T4.JobIndustryID		
			LEFT OUTER JOIN 
				(	Select TOP 1 PT1.CandidateID, PT1.DateAdded, PT2.Title
					FROM HrJobSendout PT1 INNER JOIN HrJobOrder PT2 on PT1.JobOrderID = PT2.JobOrderID 
					Where PT1.CandidateID = @CandidateID AND PT1.JobOrderID=@JobOrderID
					ORDER BY PT1.ID DESC 
				)AS T1 on T0.CandidateID = T1.CandidateID 
			
		Where isnull(T0.IsDeleted,0) = 0 
			AND T0.CandidateID=@CandidateID

	END

		

	--Log Candidate search insights=============================================
	IF(@CandidateID > 0)
	BEGIN 
		Declare @var int; --Insert insights
	END
	--==========================================================================
	
END

GO

/****** Object:  StoredProcedure [dbo].[HRMCandidateJobStatSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2021-02-12
-- Description:	HRM Candidate Stats; Returns list of candidate job stats (saved jobs, applied jobs).
-- =============================================

/*
	EXEC [HRMCandidateJobStatSearch] '100', 'Saved'
	EXEC [HRMCandidateJobStatSearch] '100', 'Applied'
*/
CREATE PROCEDURE [dbo].[HRMCandidateJobStatSearch] 
	@CandidateID int,
	@ListType NVARCHAR(10)='Saved' --Saved, Applied
AS
BEGIN	
	SET NOCOUNT ON;
	IF(@ListType = 'Saved')
	BEGIN
		SELECT TOP 50 TS.CandidateID, T0.JobOrderID, T0.JobCode, T0.Title, T2.Name[Country], T0.[Location], T0.[Description], 
			Isnull(T0.IsShowSalary, 0)[IsShowSalary], IIF(T0.IsShowSalary=1, T0.Salary, 0)[Salary], IIF(T0.IsShowSalary=1, T0.SalaryTo, 0)[SalaryTo], 
			T0.SalaryCurrCD, CAST(T0.SalaryPayCycle AS NVARCHAR)[SalaryPayCycle], CAST(T0.EmploymentType AS NVARCHAR) EmploymentType, 
			T4.Name[JobIndustry], T5.Name[JobSpecialty], T0.DateStart, T0.DateEnd,
			T1.[Name][CorporateName], T2.[Name][CorporateCountryName],
			''[SalaryUnit], CAST(1 as bit)[IsBookmarked]		
		FROM HrCandidateJobStat TS INNER JOIN HrJobOrder T0 WITH (NOLOCK) ON T0.JobOrderID = TS.JobOrderID
			LEFT OUTER JOIN Corporate T1 on T0.CorporateID = T1.CorporateID
			LEFT OUTER JOIN Country T2 on T1.CountryID = T2.CountryID
			--LEFT OUTER JOIN City T3 on T0.[Location] = T3.Name 
			LEFT OUTER JOIN HrJobIndustry T4 on T0.JobIndustry = T4.ID
			LEFT OUTER JOIN HrJobSpecialty T5 on T0.JobSpecialty = T5.ID
		Where isnull(T0.IsDeleted,0) = 0 
			AND (TS.CandidateID = @CandidateID)		
	END
	ELSE IF(@ListType = 'Applied')
	BEGIN
		SELECT TOP 50 @CandidateID[CandidateID], T0.JobOrderID, T0.JobCode, T0.Title, T2.Name[Country], T0.[Location], T0.[Description], 
			Isnull(T0.IsShowSalary, 0)[IsShowSalary], IIF(T0.IsShowSalary=1, T0.Salary, 0)[Salary], IIF(T0.IsShowSalary=1, T0.SalaryTo, 0)[SalaryTo], 
			T0.SalaryCurrCD, CAST(T0.SalaryPayCycle AS NVARCHAR)[SalaryPayCycle], CAST(T0.EmploymentType AS NVARCHAR) EmploymentType, 
			T4.Name[JobIndustry], T5.Name[JobSpecialty], T0.DateStart, T0.DateEnd,
			T1.[Name][CorporateName], T2.[Name][CorporateCountryName],
			''[SalaryUnit],CAST(1 as bit)[IsBookmarked]
		FROM HrJobOrder T0 WITH (NOLOCK) --ON T0.JobOrderID = TS.JobOrderID
			LEFT OUTER JOIN Corporate T1 on T0.CorporateID = T1.CorporateID
			LEFT OUTER JOIN Country T2 on T1.CountryID = T2.CountryID
			--LEFT OUTER JOIN City T3 on T0.[Location] = T3.Name 
			LEFT OUTER JOIN HrJobIndustry T4 on T0.JobIndustry = T4.ID
			LEFT OUTER JOIN HrJobSpecialty T5 on T0.JobSpecialty = T5.ID
		Where isnull(T0.IsDeleted,0) = 0 
			AND T0.JobOrderID IN (SELECT DISTINCT TS.JobOrderID FROM HrJobSendout TS WHERE TS.CandidateID = @CandidateID)

	END
	
END


GO

/****** Object:  StoredProcedure [dbo].[CRMCorporateSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Dilhan
-- Create date: 2020-09-06
-- Description:	CRM Corporate search; Returns all related info for a selected corporate entity.
-- Output DTO:	CorporatePublicDTO
-- Related SPs:	CRMCorporatePreview, CRMCorporateSearch returns the same DTO type	
-- =============================================

/*
	EXEC [CRMCorporateSearch] '', ''
	EXEC [CRMCorporateSearch] 's', 'n'
*/
CREATE PROCEDURE [dbo].[CRMCorporateSearch] 
	@Keyword nvarchar(50), 
	@Location Nvarchar(50),
	@CandidateID Nvarchar(50) = null
AS
BEGIN	
	SET NOCOUNT ON;
	
	IF(@Keyword='') Set @Keyword=null ELSE SET @Keyword=CONCAT('%', @Keyword, '%')
	IF(@Location='') Set @Location=null ELSE SET @Location=CONCAT('%', @Location, '%')
		    
	SELECT T0.CorporateID, T0.UserName, T0.CorporateType, T0.CorporateGroup, T0.[Name], T0.ShortName, T0.LegalType, T0.Category, 
		T0.[Address],T0.[Address2], T0.PostalCode, T0.City, T0.State, T0.CountryID, T0.Nationality, T0.Website, 
		T0.Phone, T0.Phone2, T0.Mobile, T0.Fax, T0.Email, T0.Email2, T0.CurrCD, T0.Remarks, 
		T0.Reference1, T0.Reference2, T0.Reference3, T0.RefObject, T0.CompanyLawyers, T0.CommercialRegInfo, T0.CommercialRegNum, 
		T0.Privacy, T0.[Source], T0.ImportRef, T0.DateAdded, T0.DateLastModified,	
		T2.[Name][CountryName]

	FROM Corporate T0 WITH (NOLOCK)
		LEFT OUTER JOIN Country T2 on T0.CountryID = T2.CountryID
	Where isnull(T0.IsDeleted,0) = 0 AND ISNULL(T0.Active, 0) = 1 --AND T0.Privacy IN (1,2,3,4...)
		AND (@Keyword is null OR T0.Name like (@Keyword) OR T0.ShortName like (@Keyword) OR T0.Website like (@Keyword)) 
		AND (@Location is null OR T2.[Name] LIKE (@Location))
	
	
	--Log Candidate search insights=============================================
	IF(ISNUMERIC(@CandidateID)=1 AND CAST(@CandidateID AS INT) > 0)
	BEGIN 
		Declare @var int; --Insert insights CREATE & CALL A SP
	END
	--==========================================================================

END

GO

/****** Object:  StoredProcedure [dbo].[HRMJobCandidateListByStage]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2020-10-06
-- Description:	HRM Candidate Public List By Stage; Returns list of candidates and related information.
-- Related SPs:	
-- =============================================

/*
	EXEC [HRMJobCandidateListByStage] 'A', 2
*/
CREATE PROCEDURE [dbo].[HRMJobCandidateListByStage]
	@Stage nvarchar(15)= 'applied', --sourced, applied, shortlisted, assessment, phone-screen, interview, offer, hired
	@JobOrderID int = null
AS
BEGIN	
	SET NOCOUNT ON;
	    
		
		SELECT TOP 800 T1.JobCandidateID, T1.CandidateID, ISNULL(Concat(T1.FirstName,' ', T1.LastName), '[Candidate Name]')[CandidateName], 
			T1.DateAdded, T2.JobOrderID, T2.Title[JobTitle], T1.Email, T1.Mobile, T1.Stage
		FROM HrJobCandidate T1 
			INNER JOIN HrJobOrder T2 on T1.JobOrderID = T2.JobOrderID
			LEFT OUTER JOIN HrCandidate T3 ON T3.CandidateID = T1.CandidateID
		WHERE T1.JobOrderID = @JobOrderID AND T1.Stage = @Stage
		ORDER BY T1.JobCandidateID DESC 
					

	--Log Candidate search insights=============================================
	IF(@JobOrderID > 0)
	BEGIN 
		Declare @var int; --Insert insights
	END
	--==========================================================================
	
END


GO

/****** Object:  StoredProcedure [dbo].[HRMTalentSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2020-10-06
-- Description:	HRM Talent Search; Returns list of candidates and related information.
-- Related SPs:	HRMTalentSearch, HRMCandidateSearch, HRMCandidatePublicInfo, HRMCandidatePublicListByStage returns the same DTO type
-- =============================================

/*
	EXEC [HRMTalentSearch] '', '', '', ''
*/
CREATE PROCEDURE [dbo].[HRMTalentSearch]
	@Keyword nvarchar(50), 
	@Title Nvarchar(50),
	@Country Nvarchar(50),
	@Location Nvarchar(50),
	@JobIndustry int=null,
	@CandidateSource nvarchar(5)= '',
	@CandidateID int = null,
	@JobOrderID int = null
AS
BEGIN	
	SET NOCOUNT ON;
	    
	IF(@Keyword='') Set @Keyword=null ELSE SET @Keyword=CONCAT('%', @Keyword, '%')
	IF(@Location='') Set @Location=null SET @Location=CONCAT('%', @Location, '%')
	
	SELECT TOP 50 T0.CandidateID, ''[UserName], T0.FirstName, T0.MiddleName, T0.LastName, T0.NickName,
		T0.Gender, T0.Nationality, T0.Mobile, T0.Phone, T0.Phone2, T0.WorkPhone, T0.Email,
		T0.Email2, T0.Fax, T0.Address, T0.PostalCode, T0.SecondaryAddress, T0.MaritalStatus, T0.DateOfBirth, T0.DateAvailable,
		T0.DateLastComment, T0.DateLastModified, T0.DateNextCall, T0.TimeZoneOffsetEST, T0.Active, T0.Disability, 
		'A'[CandidateSource], cast(null as int)[JobOrderID], T0.TotalExperience, T0.ExpectedSalary,
		T0.CurrOccupation[CurrentJob], ''[Education], 'fsdfs dfsd, asfdf fdsfadfa'[ExpectedJobs], ''[CountryName], T0.City,
		''[SummaryDesc]
		
		--T2.[Name][CorporateCountryName],		
	FROM HrCandidate T0  WITH (NOLOCK)
		--LEFT OUTER JOIN Country T2 on T1.CountryID = T2.CountryID
		--LEFT OUTER JOIN City T3 on T0.[Location] = T3.CityID 
		LEFT OUTER JOIN HrJobCategory T4 on T0.JobIndustry = T4.JobIndustryID		
	Where isnull(T0.Active, 1) = 1 and isnull(T0.IsDeleted,0) = 0 
		--AND (@CandidateSource='' OR ISnull(T0.CandidateSource, 'A')=@CandidateSource)
		--AND (@Keyword is null OR T0.job like (@Keyword)) 
		--AND (@Location is null OR T3.CityID = @Location)
		AND (@JobIndustry is null OR T0.JobIndustry = @JobIndustry)


		

	--Log Candidate search insights=============================================
	IF(@CandidateID > 0)
	BEGIN 
		Declare @var int; --Insert insights
	END
	--==========================================================================
	
END

GO

/****** Object:  StoredProcedure [dbo].[HRMCorporateJobList]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Dilhan
-- Create date: 2020-09-25
-- Description:	HRM get list of jobs & related details of a corporate account; 
--				Returns detail of jobs.
-- =============================================
--sourced, applied, shortlisted, assessment, phone-screen, interview, offer, hired
/*
	EXEC [HRMCorporateJobList] 1
*/
CREATE PROCEDURE [dbo].[HRMCorporateJobList] 
	@CorporateID int = NULL,
	@JobOrderID INT = null
AS
BEGIN	
	SET NOCOUNT ON;
	
	SELECT TOP 50 T0.CorporateID, T0.JobOrderID, T0.JobCode, T0.Title, T0.Country, T2.Name[CountryName], T0.[Location], 
		T0.[Description], T0.Requirements, T0.Benefits, 		
		T0.EmploymentType, T0.JobIndustry, T4.Name [JobIndustryName], T0.JobSpecialty, T0.NumOfAvilJobs, T0.TravelRequirements, T0.CorporateContact, 
		T0.DateStart, T0.DateEnd, T0.ApplyByEmail, T0.ApplyByMobileNum, T0.IsDeleted, T0.[Status],
		T5.SourceCount[SourcedCount], T5.AppliedCount[AppliedCount], 
		T5.ShortlistedCount[ShortlistedCount], T5.AssesmntCount[AssesmntCount], 
		T5.PhoneScreenCount[PhoneScreenCount], T5.InterviewCount[InterviewCount], T5.OfferCount[OfferCount],
		T5.HiredCount[HiredCount],
		T5.DateLastApplied [DateLastApplied]		 
		
	FROM HrJobOrder T0  WITH (NOLOCK)
		LEFT OUTER JOIN Corporate T1 on T0.CorporateID = T1.CorporateID
		LEFT OUTER JOIN Country T2 on T0.Country = T2.CountryID
		--LEFT OUTER JOIN City T3 on T0.[Location] = T3.CityID 
		LEFT OUTER JOIN HrJobIndustry T4 on T0.JobIndustry = T4.ID		
		LEFT OUTER JOIN (
			SELECT PT1.JobOrderID, CAST(MAX(PT1.DateAdded) as Datetime)[DateLastApplied], 
			COUNT(IIF(PT1.Stage='sourced',1,null))[SourceCount], COUNT(IIF(PT1.Stage='applied',1,null))[AppliedCount], 
			COUNT(IIF(PT1.Stage='shortlisted',1,null))[ShortlistedCount], COUNT(IIF(PT1.Stage='assessment',1,null))[AssesmntCount],
			COUNT(IIF(PT1.Stage='phone-screen',1,null))[PhoneScreenCount], COUNT(IIF(PT1.Stage='interview',1,null))[InterviewCount],
			COUNT(IIF(PT1.Stage='offer',1,null))[OfferCount], COUNT(IIF(PT1.Stage='hired',1,null))[HiredCount]
			FROM HrJobCandidate PT1 Group by PT1.JobOrderID
			) AS T5 ON T5.JobOrderID = T0.JobOrderID
	Where (@CorporateID IS NULL OR T0.CorporateID = @CorporateID) AND (@JobOrderID IS NULL OR T0.JobOrderID = @JobOrderID)
	order by JobOrderID desc
			
END



GO

/****** Object:  StoredProcedure [dbo].[SearchTrademarkLevenstn]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Chinthana Dilhan
-- Create date: 2017-12-18
-- Description:	<Description,,>
-- =============================================
/*
	EXEC SearchTrademarkLevenstn Job, 'LIST', 'a'
	EXEC SearchTrademarkLevenstn TM, 'LIST', 'AMWAY'
	EXEC SearchTrademarkLevenstn Job, 'LIST', null
	EXEC SearchTrademarkLevenstn TM, 'LIST', null
*/
CREATE PROCEDURE [dbo].[SearchTrademarkLevenstn]
(
	@ContentType NVARCHAR(10), -- Job | TM | Both
	@SearchMode NVARCHAR(10)='LIST',
	@TitleOrTM NVARCHAR(100)=NULL, 
	@FileNum int=NULL,
	@RecNum NVARCHAR(50)=NULL,
	@DocCateg NVARCHAR(50)=NULL,
	@MatterType NVARCHAR(50)=NULL,
	@Class NVARCHAR(50)=NULL,
	@PctNum NVARCHAR(50)=NULL,
	@DocStatus INT=NULL,
	@PriorityDate NVARCHAR(30)=NULL,
	@FillingDate NVARCHAR(30)=NULL,
	@RegDate NVARCHAR(30)=NULL,
	@ExpiryDate NVARCHAR(30)=NULL,
	@ClientName NVARCHAR(50)=NULL,
	@SenderEmail NVARCHAR(50)=NULL,
	@CreatedBy NVARCHAR(30)=NULL
	--@InvNum NVARCHAR(50)=NULL,
	--@IsSortAsc NVARCHAR(5)='ASC'
)
AS
BEGIN
	
	--WAITFOR DELAY '00:00:05'; 
	IF(@ContentType in ('TM', 'Both'))
	BEGIN
		DECLARE @MaxF NUMERIC(6,2)= 5; 
		DECLARE @LFPct NUMERIC(6,2)=100/@MaxF, @DFPct NUMERIC(6,2)=100/4;

		SELECT IIF(@TitleOrTM IS NULL, 'N/A', CONCAT(CAST(PT3.ProximityPCT AS NUMERIC(19)),'%'))[ProximityPCT], T0.FileNum[FileNum], T0.TMNum[RecNum], 
			T0.TMWord[TitleOrTM], 
			IIF(@SearchMode ='LIST', NULL, TMLogoFile)[ImagePath], T0.TMLogoName[ImageDesc],  
			T0.ClassID[ClassId], T0.ClassID[ClassName], T0.TMStatus[DocStatus], 
			T2.StatusDesc[DocStatusDesc], T0.DocNum[DocNum], T0.BPCode[ClientCode], T0.BPName[ClientName], PT3.Catg[DocCateg],
			T0.MatterType, T4.MatterTypeDesc, 
			T0.DatePriority[DatePriority], T0.DateFiling[DateFilling], T0.DateReg[DateReg], T0.DateExpire[DateExpiry],
			''[StatusColor]
		FROM Trademark T0 LEFT OUTER JOIN 
				(SELECT MIN(DocNum)[DocNum], MIN(Catg)[Catg], MAX(ProximityPCT)[ProximityPCT]
				FROM
				( 
					SELECT DocNum, CAST(1 AS TINYINT)[Catg], 100[ProximityPCT] FROM Trademark WHERE TMWord = @TitleOrTM
					UNION ALL  
					SELECT DocNum, CAST(2 AS TINYINT)[Catg], (((@MaxF-1)*@LFPct) + (4*@DFPct))/2 FROM Trademark WHERE TMWord LIKE ('%'+ @TitleOrTM+'%')
					UNION ALL 
					SELECT DocNum, CAST(3 AS TINYINT),  	
						(((@MaxF-dbo.LEVENS3(@TitleOrTM, FltWord, @MaxF)-1)*@LFPct) + (CAST(DIFFERENCE(@TitleOrTM, FltWord) AS NUMERIC(9,2))*@DFPct))/2
					FROM (SELECT DocNum, TMWord, dbo.GetAlphaNumChars(TMWord)[FltWord] FROM Trademark) PT1
				) PT2
				WHERE PT2.ProximityPCT IS NOT NULL AND PT2.ProximityPCT >= 0
				GROUP BY PT2.DocNum 
			) PT3 ON PT3.DocNum = T0.DocNum 
			--LEFT OUTER JOIN NiceClass T1 ON T1.ClassID = T0.ClassID
			LEFT OUTER JOIN TMStatus T2 ON T2.StatusID=T0.TMStatus
			LEFT OUTER JOIN BPMaster T3 ON T3.BPCode = T0.BPCode
			LEFT OUTER JOIN MatterType T4 ON T4.MatterTypeID = T0.MatterType AND T4.ModuleID=11
		WHERE (ISNULL(@FileNum, '')='' OR PT3.DocNum IS NOT NULL)
			AND (ISNULL(@Class, '')='' OR CONCAT(T0.ClassID, ',') like CONCAT('%', @Class,',%')) 
			AND (ISNULL(@RecNum, '')='' OR T0.TMNum=@RecNum)
			--AND (ISNULL(@TMLogoName, '')='' OR T0.TMLogoName LIKE CONCAT('%', @TMLogoName,'%'))
			AND (ISNULL(@DocStatus, '')='' OR T0.TMStatus=@DocStatus)
			AND (ISNULL(@FillingDate, '')='' OR T0.DateFiling=@FillingDate)
			AND (ISNULL(@RegDate, '')='' OR T0.DateReg=@RegDate)
			AND (ISNULL(@ClientName, '')='' OR T0.BPName LIKE CONCAT('%', @ClientName,'%'))
			AND (ISNULL(@CreatedBy, '')='' OR T0.CreatedBy=@CreatedBy OR T0.ModifiedBy=@CreatedBy)
		ORDER BY PT3.ProximityPCT DESC
	END
	ELSE IF (@ContentType in ('Job', 'Both'))
	BEGIN

	/*
		ProximityPCT, FileNum, RecNum, TitleOrTM, ImageDesc, TMLogoFile, ClassId, ClassName, 
		DocStatus, DocStatusDesc, DocNum, ClientCode, ClientName, DocCateg, 
		ImagePath, DateFiling, DatePriority, DateFilling, DateReg, DateExpiry, StatusColor
	*/

		IF(@FileNum <= 0) SET @FileNum=NULL;
		IF(@RecNum <= 0) SET @RecNum=NULL
		IF(@MatterType <= 0) SET @MatterType=NULL
		IF(@DocStatus <= 0) SET @DocStatus=NULL
		
		SELECT 
			''[ProximityPCT], T0.FileNum, T0.JobApplcNum[RecNum], T0.PctNum, JobTitle[TitleOrTM], 
			T0.MatterType, T1.MatterTypeDesc, DocStatus, T2.StatusDesc[DocStatusDesc],  
			''[ImagePath], ''[ImageDesc], ''[ClassId], ''[ClassName],
			T0.BPCode[ClientCode], T0.BPName[ClientName], JobCategory[DocCateg], 
			T0.JobSrcSender, T0.JobSrcEmail, T0.JobSrcCC, FORMAT(T0.JobSrcDate, 'yyyy-MM-dd')[JobSrcDate], 
			T0.InvNum, FORMAT(T0.InvDate, 'yyyy-MM-dd')[InvDate], T0.InvAmt, 
			T0.JobRef1, T0.JobRef2, T0.JobRef3, T0.Active, T0.PriorityDetail,
			T0.DatePriority[DatePriority], T0.DateFiling[DateFilling], T0.DateReg[DateReg], T0.DateExpire[DateExpiry],
			ISNULL(T0.ModifiedOn, T0.CreatedOn)[ModifiedOn], ISNULL(T0.ModifiedBy, T0.CreatedBy)[T0.ModifiedBy], 
			T2.StatusColor
		FROM IPJob T0 
			LEFT OUTER JOIN MatterType T1 ON T1.MatterTypeID = T0.MatterType AND T1.ModuleID=10
			LEFT OUTER JOIN IPJobStatus T2 ON T2.StatusID=T0.DocStatus
			LEFT OUTER JOIN BPMaster T3 ON T3.BPCode = T0.BPCode
		WHERE (@FileNum IS NULL OR T0.FileNum=@FileNum)
			AND (@RecNum IS NULL OR T0.JobApplcNum=@RecNum)
			AND (@MatterType IS NULL OR T0.MatterType=@MatterType)
			AND (@DocStatus IS NULL OR T0.DocStatus=@DocStatus)
			AND (ISNULL(@PctNum, '')='' OR T0.PctNum=@PctNum)
			AND (ISNULL(@TitleOrTM, '')='' OR T0.JobTitle like CONCAT('%', @TitleOrTM,'%'))
			--AND (ISNULL(@PriorityDetl, '')='' OR T0.PriorityDetail=@PriorityDetl)
			AND (ISNULL(@FillingDate, '')='' OR T0.DateFiling=@FillingDate)
			AND (ISNULL(@RegDate, '')='' OR T0.DateReg=@RegDate)
			AND (ISNULL(@ExpiryDate, '')='' OR T0.DateExpire=@ExpiryDate)
			--AND (ISNULL(@ClientCode, '')='' OR T0.BPCode=@ClientCode)
			AND (ISNULL(@ClientName, '')='' OR T0.BPName like CONCAT('%', @ClientName,'%'))
			--AND (ISNULL(@SenderName, '')='' OR T0.JobSrcSender like CONCAT('%', @SenderName,'%'))
			AND (ISNULL(@SenderEmail, '')='' OR T0.JobSrcEmail like CONCAT('%', @SenderEmail,'%'))
			--AND (ISNULL(@InvNum, '')='' OR T0.InvNum=@InvNum)
			AND (ISNULL(@CreatedBy, '')='' OR ISNULL(T0.ModifiedOn, T0.CreatedOn) = @CreatedBy)
			--AND (ISNULL(@JobRef, '')='' OR T0.JobRef1 LIKE CONCAT('%', @JobRef,'%') OR T0.JobRef2 LIKE CONCAT('%', @JobRef,'%') OR T0.JobRef3 LIKE CONCAT('%', @JobRef,'%'))
		--ORDER BY CASE @IsSortAsc WHEN 1 THEN -T0.JobFileNum ELSE T0.JobFileNum END ASC	 

	END

END


GO

/****** Object:  StoredProcedure [dbo].[RptIPDocument]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
	EXEC [RptIPDocument] 10, 8
	EXEC [RptIPDocument] 12, 1
*/

CREATE PROCEDURE [dbo].[RptIPDocument]
(
	@BasePageUid smallint, --10=Job, 12=TM
	@DocNum INT
)
AS
BEGIN
			
	if(@BasePageUid in (10,11))
	Begin 
		SELECT T0.DocNum[DocNum], T0.FileNum[FileNum], T0.MatterType, T0.JobApplcNum[ApplcNum], T0.JobTitle[Desc], T0.PctNum, T0.DocStatus[RecStatus], 
			T0.PriorityDetail, T0.DatePriority, T0.DateFiling, T0.DateReg, T0.DateExpire, 
			T0.BPCode, T0.BPName, T0.BPAddrs, T0.BPEmail, T0.BPPhone, T0.BPFax, 
			T0.JobSrcSender, T0.JobSrcEmail, T0.JobSrcCC, T0.JobSrcDate, T0.InvNum, T0.InvDate, T0.InvAmt, 
			T0.JobRef1[Ref1], T0.JobRef2[Ref2], T0.JobRef3[Ref3], 
			T1.StatusDesc[DocStatusDesc], T1.StatusColor[DocStatusColor], T2.MatterTypeDesc,
			ISNULL(T1.Ref1Title,'Reference')[Ref1Title],ISNULL(T1.Ref2Title,'')[Ref2Title],ISNULL(T1.Ref3Title,'')[Ref3Title],
			T0.CreatedOn, T0.CreatedBy, T0.ModifiedOn, T0.ModifiedBy, T0.TerminalID, T0.SessionID 
		FROM IPJob T0
			LEFT OUTER JOIN IPJobStatus T1 ON T0.DocStatus= T1.StatusID
			LEFT OUTER JOIN MatterType T2 ON T2.ModuleID=103 AND T0.MatterType= T2.MatterTypeID
			--LEFT OUTER JOIN BPMaster T3 ON T3.BPCode = T0.BPCode
		WHERE T0.DocNum = @DocNum
	END  
	ELSE if(@BasePageUid in (12,13))
	Begin 
		SELECT T0.DocNum[DocNum], T0.FileNum[FileNum], T0.MatterType, ''[ApplcNum], ''[Desc], '' [PctNum], T0.TMStatus[RecStatus], 
			T0.PriorityDetail, T0.DatePriority, T0.DateFiling, T0.DateReg, T0.DateExpire, 
			T0.BPCode, T0.BPName, T0.BPAddrs, T0.BPEmail, T0.BPPhone, T0.BPFax, 
			T0.JobSrcSender, T0.JobSrcEmail, T0.JobSrcCC, T0.JobSrcDate, T0.InvNum, T0.InvDate, T0.InvAmt, 
			TMRef1[Ref1], TMRef2[Ref2], TMRef3[Ref3], 
			T2.StatusDesc[DocStatusDesc], T2.StatusColor[DocStatusColor], T3.MatterTypeDesc,
			ISNULL(T2.Ref1Title,'Reference')[Ref1Title],ISNULL(T2.Ref2Title,'')[Ref2Title],ISNULL(T2.Ref3Title,'')[Ref3Title],
			TMNum, TMWord, TMLogoName, TMLogoFile, T0.ClassID, T1.ClassName, T1.ClassDesc, 
			TMTranslation, ClaimingColor, GoodsNServcs, SimilarSounds,
			T0.CreatedOn, T0.CreatedBy, T0.ModifiedOn, T0.ModifiedBy, T0.TerminalID, T0.SessionID
		FROM Trademark T0
			INNER JOIN NiceClass T1 ON T0.ClassID = T1.ClassID
			INNER JOIN TMStatus T2 ON T0.TMStatus = T2.StatusID
			LEFT OUTER JOIN MatterType T3 ON T3.ModuleID=12 AND T0.MatterType=T3.MatterTypeID
			--LEFT OUTER JOIN BPMaster T3 ON T3.BPCode = T0.BPCode
			--LEFT OUTER JOIN TMRegFiles T4 ON T0.TMLogoFile = CONVERT(varchar(70), T4.stream_id)
		WHERE T0.DocNum = @DocNum
	END  


END


GO

/****** Object:  StoredProcedure [dbo].[LogDocumentTransactions]    Script Date: 7/18/2021 9:22:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[LogDocumentTransactions]
(
	@ModuleID INT,
	@DocNum INT,
	@LogUserID NVARCHAR(30),
	@LogSessionID NVARCHAR(50),
	@LoggedModuleID INT
)
as
BEGIN

	--IF(@LogSubmitMode = 'COMMIT')
	--BEGIN
	--	IF(@ModuleID=100)
	--	BEGIN
	--		UPDATE LogTMRegistry SET IsLogCommitted = 1 WHERE RecID = @PreLogRecID
	--	END
	--END

	--INSERT EXISTING DATA AS LOGS BEFORE TRIGGER THE DATA UPDATES------------------------------------------------------
	IF(@ModuleID=100) --Trademark Registry
	BEGIN
		PRINT 'TO BE IMPLEMENTED'
		--INSERT INTO LogTMRegistry
		--(
		--    LogInstanceID, LogCreatedBy, LogCreatedOn, LogSessionID, LoggedModuleID, IsLogCommitted, 
		--	DocNum, TMFileNum, TMNum, TMWord, TMLogoName, TMLogoFile, ClassID, DocStatus, ModuleID, TerminalID, TMTranslation, ClaimingColor,
		--    GoodsNServcs, MatterType, SimilarSounds, BPCode, BPName, BPRegAddrs, BPRegPhone, BPRegEmail, BPRegFax, DateFiling,
		--    DateReg, DateExpire, DatePriority, PriorityDetail, JobSrcSender, JobSrcEmail, JobSrcCC, JobSrcDate, InvNum,
		--    InvDate, InvAmt, TMRef1, TMRef2, TMRef3, Active, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, ImportedOn, ImportRef, SessionID
		--)
		--SELECT ISNULL((SELECT COUNT(DocNum) FROM LogTMRegistry WHERE ModuleID=@ModuleID AND DocNum=@DocNum), 0) + 1, 
		--	@LogUserID, GETDATE(), @LogSessionID, @LoggedModuleID, 1, 
		--	DocNum, TMFileNum, TMNum, TMWord, TMLogoName, TMLogoFile, ClassID, DocStatus, ModuleID, TerminalID, TMTranslation, ClaimingColor,
		--    GoodsNServcs, MatterType, SimilarSounds, BPCode, BPName, BPRegAddrs, BPRegPhone, BPRegEmail, BPRegFax, DateFiling,
		--    DateReg, DateExpire, DatePriority, PriorityDetail, JobSrcSender, JobSrcEmail, JobSrcCC, JobSrcDate, InvNum,
		--    InvDate, InvAmt, TMRef1, TMRef2, TMRef3, Active, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, ImportedOn, ImportRef, SessionID
		--FROM TMRegistry
		--WHERE DocNum = @DocNum 
	END 
	ELSE IF(@ModuleID=103) --Job Registry
	BEGIN
		PRINT 'TO BE IMPLEMENTED'		
		--INSERT INTO LogJobRegistry
		--(
		--    LogInstanceID, LogCreatedBy, LogCreatedOn, LogSessionID, LoggedModuleID, IsLogCommitted, DocNum, JobFileNum,
		--    MatterType, JobApplcNum, JobTitle, PctNum, DocStatus, PriorityDetail, DatePriority, DateFiling, DateReg,
		--    DateExpire, BPCode, BPName, BPAddrs, BPEmail, BPPhone, BPFax, JobSrcSender, JobSrcEmail, JobSrcCC, JobSrcDate,
		--    InvNum, InvDate, InvAmt, JobRef1, JobRef2, JobRef3, Active, ModuleID, TerminalID, CreatedOn, CreatedBy, ModifiedOn,
		--    ModifiedBy, ImportedOn, ImportRef, SessionID
		--)		
		--SELECT ISNULL((SELECT COUNT(DocNum) FROM LogJobRegistry WHERE ModuleID=@ModuleID AND DocNum=@DocNum), 0) + 1, 
		--	@LogUserID, GETDATE(), @LogSessionID, @LoggedModuleID, 1, 
		--	DocNum, JobFileNum, MatterType, JobApplcNum, JobTitle, PctNum, DocStatus, PriorityDetail, DatePriority,
		--	DateFiling, DateReg, DateExpire, BPCode, BPName, BPAddrs, BPEmail, BPPhone, BPFax, JobSrcSender, JobSrcEmail,
		--	JobSrcCC, JobSrcDate, InvNum, InvDate, InvAmt, JobRef1, JobRef2, JobRef3, Active, ModuleID, TerminalID,
		--	CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, ImportedOn, ImportRef, SessionID
		--FROM JobRegistry
		--WHERE DocNum = @DocNum 
	END 

END

GO



";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = @"
/****** Object:  StoredProcedure [dbo].[LogDocumentTransactions]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[LogDocumentTransactions]
GO

/****** Object:  StoredProcedure [dbo].[RptIPDocument]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[RptIPDocument]
GO

/****** Object:  StoredProcedure [dbo].[SearchTrademarkLevenstn]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[SearchTrademarkLevenstn]
GO

/****** Object:  StoredProcedure [dbo].[HRMCorporateJobList]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMCorporateJobList]
GO

/****** Object:  StoredProcedure [dbo].[HRMTalentSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMTalentSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobCandidateListByStage]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMJobCandidateListByStage]
GO

/****** Object:  StoredProcedure [dbo].[CRMCorporateSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[CRMCorporateSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMCandidateJobStatSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMCandidateJobStatSearch]
GO

/****** Object:  StoredProcedure [dbo].[HRMCandidatePublicInfo]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMCandidatePublicInfo]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobOrderPreview]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMJobOrderPreview]
GO

/****** Object:  StoredProcedure [dbo].[CRMCorporatePreview]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[CRMCorporatePreview]
GO

/****** Object:  StoredProcedure [dbo].[HRMJobOrderSearch]    Script Date: 7/18/2021 9:22:33 PM ******/
DROP PROCEDURE [dbo].[HRMJobOrderSearch]
GO
";
            migrationBuilder.Sql(dropProcSql);
        }

    }
}
