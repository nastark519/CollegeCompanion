/*
Users Table
Feilds: UserID, Name, Password stored in encrypted format
Primary Key: UserId
*/

CREATE TABLE CompanionUser ( /*I want to change this to CompainonUser. */
	CompanionID		int				IDENTITY (1, 1) not null,
	[Email]			NVARCHAR(256) not null,
	ASPIdentityID	nvarchar(128)	not null, /*Populated by copying the UserID from Asp Identity, not a FK*/ /*find the ASPIdentity's datatype*/
	PRIMARY KEY (CompanionID ASC)
);

/*
Colleges Table
Feilds: CollegeID, Name, StateName, City, Accreditor, Ownership, Cost
Primary Key: CollegeID
Foreign Key: UserID
*/
CREATE TABLE Colleges (
	CollegeID	int				IDENTITY (1, 1) not null,
	Name		nvarchar(150)	not null,
	StateName	nvarchar(30)	not null,
	City		nvarchar(25)	not null, /*Obtained from SearchForm field.*/
	Accreditor	nvarchar(25),
	Ownership	nvarchar(25)	not null, /*1 is Public, 2 is Private NP, 3 is Private FP*/
	Cost		int				not null,
	PRIMARY KEY (CollegeID ASC)
);

/*Creat Tables*/
CREATE TABLE StateList (
	StateID	INT	IDENTITY(1,1)	NOT NULL,
	QueryName	NVARCHAR(50)	NOT NULL,
	Name		NVARCHAR(50)	NOT NULL,
	StateAbbr	NVARCHAR(2)	NOT NULL,
	PRIMARY KEY(StateID)
);

CREATE TABLE FinLimitList (
	FinLimitID	INT	IDENTITY(1,1)	NOT NULL,
	LowerLimit	INT	NOT NULL,
	UpperLimit	INT NOT NULL,
	PRIMARY KEY (FinLimitID)
);

CREATE TABLE PrivacyList (
	PrivacyID	INT	IDENTITY(1,1)	NOT NULL,
	PrivacyNumber	INT	NOT NULL,
	PrivacyType		NVARCHAR(25) NOT NULL,
	PRIMARY KEY (PrivacyID)
);

CREATE TABLE DegreeList (
	DegreeID	INT	IDENTITY(1,1)	NOT NULL,
	DegreeName	NVARCHAR(100)	NOT NULL,
	DegreeValue	NVARCHAR(50)	NOT NULL,
	PRIMARY KEY(DegreeID)
);

CREATE TABLE DegreeType (
	DegreeTypeID	INT	IDENTITY(1,1)	NOT NULL,
	DegreeTypeName	NVARCHAR(100)	NOT NULL,
	DegreeTypeValue	NVARCHAR(50)	NOT NULL,
	PRIMARY KEY(DegreeTypeID)
);

CREATE TABLE AcceptanceRate (
	AcceptanceRateID	INT	IDENTITY(1,1)	NOT NULL,
	AcceptanceRateValue	NVARCHAR(50)	NOT NULL,
	PRIMARY KEY(AcceptanceRateID)
);

CREATE TABLE DemoRace (
	DemoRaceID	INT	IDENTITY(1,1)	NOT NULL,
	DemoRaceName	NVARCHAR(50)	NOT NULL,
	DemoRaceValue	NVARCHAR(50)	NOT NULL,
	PRIMARY KEY(DemoRaceID)
);

CREATE TABLE DemoAge (
	DemoAgeID	INT	IDENTITY(1,1)	NOT NULL,
	DemoAgeRange	NVARCHAR(50)	NOT NULL,
	DemoAgeRangeValue	NVARCHAR(50)	NOT NULL,
	PRIMARY KEY(DemoAgeID)
);

/*Data for Tables*/
INSERT INTO StateList (QueryName, Name, StateAbbr)
VALUES ('Alabama AL', 'Alabama', 'AL'),
	   ('Alaska AK', 'Alaska', 'AK'), 
	   ('American Samoa AS', 'American Samoa', 'AS'),
	   ('Arizona AZ', 'Arizona', 'AZ'),
	   ('Arkansas AR', 'Arkansas', 'AR'), 
	   ('California CA', 'California', 'CA'),
	   ('Colorado CO', 'Colorado', 'CO'),
	   ('Connecticut CT', 'Connecticut', 'CT'),
	   ('Delware DE', 'Delware', 'DE'),
	   ('District of Columbia DC', 'District of Columbia', 'DC'),
	   ('Federated States of Micronesia FM', 'Federated States of Micronesia', 'FM'),
	   ('Florida FL', 'Florida', 'FL'),
	   ('Georgia GA', 'Georgia', 'GA'), 
	   ('Guam GU', 'Guam', 'GU'),
	   ('Hawaii HI', 'Hawaii', 'HI'),
	   ('Idaho ID', 'Idaho', 'ID'),
	   ('Illinois IL', 'Illinois', 'IL'),
	   ('Indiana IN', 'Indiana', 'IN'),
	   ('Iowa IA', 'Iowa', 'IA'),
	   ('Kansas KS', 'Kansas', 'KS'),
	   ('Kentucky KY', 'Kentucky', 'KY'),
	   ('Louisiana LA', 'Louisiana', 'LA'),
	   ('Maine ME', 'Maine', 'ME'),
	   ('Maryland MD', 'Maryland', 'MD'),
	   ('Massachusetts MA', 'Massachusetts', 'MA'),
	   ('Michigan MI', 'Michigan', 'MI'),
	   ('Minnesota MN', 'Minnesota', 'MN'), 
	   ('Mississippi MS', 'Mississippi', 'MS'),
	   ('Missouri MO', 'Missouri', 'MO'),
	   ('Montana MT', 'Montana', 'MT'),
	   ('Nebraska NE', 'Nebraska', 'NE'),
	   ('Nevada NV', 'Nevada', 'NV'),
	   ('New Hampshire NH', 'New Hampshire', 'NH'),
	   ('New Jersey NJ', 'New Jersey', 'NJ'),
	   ('New Mexico NM', 'New Mexico', 'NM'),
	   ('New York NY', 'New York', 'NY'),
	   ('North Carolina NC', 'North Carolina', 'NC'),
	   ('North Dakota ND', 'North Dakota', 'ND'),
	   ('Marshall Islands MH', 'Marshall Islands', 'MH'),
	   ('Northern Mariana Islands MP', 'Northern Mariana Islands', 'MP'),
	   ('Ohio OH', 'Ohio', 'OH'),
	   ('Oklahoma OK', 'Oklahoma', 'OK'),
	   ('Oregon OR', 'Oregon', 'OR'),
	   ('Palau PW', 'Palau', 'PW'),
	   ('Pennsylvania PA', 'Pennsylvania', 'PA'),
	   ('Puerto Rico PR', 'Puerto Rico', 'PR'),
	   ('Rhode Island RI', 'Rhode Island', 'RI'),
	   ('South Carolina SC', 'South Carolina', 'SC'),
	   ('South Dakota SD', 'South Dakota', 'SD'),
	   ('Tennessee TN', 'Tennessee', 'TN'),
	   ('Texas TX', 'Texas', 'TX'),
	   ('Utah UT', 'Utah', 'UT'),
	   ('Vermont VT', 'Vermont', 'VT'),
	   ('Virginia VA', 'Virginia', 'VA'),
	   ('Washington WA', 'Washington', 'WA'),
	   ('West Virginia WV', 'West Virginia', 'WV'),
	   ('Wisconsin WI', 'Wisconsin', 'WI'),
	   ('Wyoming WY', 'Wyoming', 'WY');

INSERT INTO FinLimitList (LowerLimit, UpperLimit)
VALUES (1000, 10000),
	   (10000, 20000),
	   (20000, 30000),
	   (30000, 40000), 
	   (40000, 50000), 
	   (50000, 60000);

INSERT INTO PrivacyList (PrivacyNumber, PrivacyType)
VALUES (1, 'Public'),
	   (2, 'Private, Non-Profit'),
	   (3, 'Private, For-Profit');

INSERT INTO DegreeList (DegreeName, DegreeValue)
VALUES	('Agriculture, Agriculture Operations, And Related Sciences', 'agriculture'),
		('Natural Resources And Conservation', 'resources'),
		('Architecture And Related Services', 'architecture'),
		('Area, Ethnic, Cultural, Gender, And Group Studies', 'ethnic_cultural_gender'),
		('Communication, Journalism, And Related Programs', 'communication'),
		('Communications Technologies/Technicians And Support Services', 'communications_technology'),
		('Computer And Information Sciences And Support Services', 'computer'),
		('Personal And Culinary Services', 'personal_culinary'),
		('Education', 'education'),
		('Engineering', 'engineering'),
		('Engineering Technologies And Engineering-Related Fields', 'engineering_technology'),
		('Foreign Languages, Literatures, And Linguistics', 'language'),
		('Family And Consumer Sciences/Human Sciences', 'family_consumer_science'),
		('Legal Professions And Studies', 'legal'),
		('English Language And Literature/Letters', 'english'),
		('Liberal Arts And Sciences, General Studies And Humanities', 'humanities'),
		('Library Science', 'library'),
		('Biological And Biomedical Sciences', 'biological'),
		('Mathematics And Statistics', 'mathematics'),
		('Military Technologies And Applied Sciences', 'military'),
		('Multi/Interdisciplinary Studies', 'multidiscipline'),
		('Parks, Recreation, Leisure, And Fitness Studies', 'parks_recreation_fitness'),
		('Philosophy And Religious Studies', 'philosophy_religious'),
		('Theology And Religious Vocations', 'theology_religious_vocation'),
		('Physical Sciences', 'physical_science'),
		('Science Technologies/Technicians', 'science_technology'),
		('Psychology', 'psychology'),
		('Homeland Security, Law Enforcement, Firefighting And Related Protective Services', 'security_law_enforcement'),
		('Public Administration And Social Service Professions', 'public_administration_social_service'),
		('Social Sciences', 'social_science'),
		('Construction Trades', 'construction'),
		('Mechanic And Repair Technologies/Technicians', 'mechanic_repair_technology'),
		('Precision Production', 'precision_production'),
		('Transportation And Materials Moving', 'transportation'),
		('Visual And Performing Arts', 'visual_performing'),
		('Health Professions And Related Programs', 'health'),
		('Business, Management, Marketing, And Related Support Services', 'business_marketing'),
		('History', 'history');


INSERT INTO DegreeType (DegreeTypeName, DegreeTypeValue)
VALUES	('Certificate of less than one academic year', 'certificate_lt_1_yr'),
		('Certificate of at least one but less than two academic years', 'certificate_lt_2_yr'),
		('Associate degree', 'assoc'),
		('Awards of at least two but less than four academic years', 'certificate_lt_4_yr'),
		('Bachelor degree', 'bachelors');


INSERT INTO AcceptanceRate (AcceptanceRateValue)
VALUES	('10'),
		('20'),
		('30'),
		('40'),
		('50'),
		('60'),
		('70'),
		('80'),
		('90');

INSERT INTO DemoRace (DemoRaceName, DemoRaceValue)
VALUES	('White', 'wa'),
		('Black', 'ba'),
		('Native American', 'na'),
		('Asian', 'aa'),
		('Pacific Islanders', 'pa'),
		('Multiracial', 'r2'),
		('Hispanic', 'hs'),
		('White, Non-Hispanic', 'wn');

INSERT INTO DemoAge (DemoAgeRange, DemoAgeRangeValue)
VALUES	('0-4', '0_4'),
		('5-9', '5_9'),
		('10-14', '10_14'),
		('15-19', '15_19'),
		('20-24', '20_24'),
		('25-29', '25_29'),
		('30-34', '30_34'),
		('35-39', '35_39'),
		('40-44', '40_44'),
		('45-49', '45_49'),
		('50-54', '50_54'),
		('55-59', '55_59'),
		('60-64', '60_64'),
		('65-69', '65_69'),
		('70-74', '70_74'),
		('75-79', '75_79'),
		('80-84', '80_84');


/*
College_User_Relations Table
Feilds: UserID, CollegeID
Primary Key: UserId, CollegeID
*/
CREATE TABLE College_User_Relations (
	CompanionID	int				not null,
	CollegeID	int				not null,
	Favorite	bit				not null, /*0 is False, 1 is True*/
	Saved		bit				not null, /*0 is False, 1 is True*/
	CONSTRAINT College_CompanionID PRIMARY KEY (CompanionID, CollegeID), /*PK generated by both keys as a relationship.*/
	CONSTRAINT FK_CollegeID FOREIGN KEY (CollegeID) REFERENCES Colleges(CollegeID)
	ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_CompanionID FOREIGN KEY (CompanionID) REFERENCES CompanionUser(CompanionID)
	ON UPDATE CASCADE ON DELETE CASCADE	
);

/*=========INSERT SCRIPTS==============*/

/* I have commented this out because it in not need and I don't want it to break anything if it is tried.
INSERT INTO Users(ASPIdentityID) VALUES (
	'221b'
);
*/
--INSERT INTO Colleges(Name, StateName, City, Accreditor, Focus, Ownership, Cost, AdmissionRate) VALUES (
--	'Hyrule University', 'Hyrule', 'Kakariko', 'Malon Foundation', 'Business', 1, 20000, 80
--);
/* commented out because an erro was being thrown and it doesn't apear to be needed.
INSERT INTO College_User_Relations (UserID, CollegeID, Favorite, Saved) VALUES (
	1, 1, 0, 0
);
*/

/*======================================== Identity tables ====================================================================*/

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);


CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);


CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);



CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);



CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


