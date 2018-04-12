


/*
CREATE TABLE dbo.City
(
	[CityID] INT IDENTITY(1,1) NOT NULL,
	[CityName] VARCHAR(45) NOT NULL,
	[CityState] VARCHAR(45) NOT NULL,
	CONSTRAINT [PK_dbo.City] PRIMARY KEY (CityID)
);
*/

CREATE TABLE dbo.College
(
	[CollegeID] INT IDENTITY(1,1) NOT NULL,
	[CityName] NVARCHAR (200) NULL,
	[StateName] NVARCHAR (200) NOT NULL,
	[CollegeName] NVARCHAR (200) NOT NULL,
	[Focus] NVARCHAR (200) NULL,
	[Accreditor] NVARCHAR (200) NULL,
	[Ownership] INT NULL,     /* 1 is public 2 is private non-prophet 3 is private for prophet */
	CONSTRAINT [PK_dbo.College] PRIMARY KEY (CollegeID)
);

CREATE TABLE dbo.Party
(
	[PartyID] INT IDENTITY(1,1) NOT NULL,
	[PartyName] NVARCHAR(50) NOT NULL,
	[PartyEmail] VARCHAR(45) NOT NULL,
	CONSTRAINT [PK_dbo.Party] PRIMARY KEY (PartyID)
);

CREATE TABLE dbo.CollegeFavorite
(
	[CollegeFavoriteID] INT IDENTITY(1,1) NOT NULL,
	[CollegeID] INT NULL,
	[PartyID] INT NULL,
	CONSTRAINT [PK_dbo.CollegeFavorite] PRIMARY KEY (CollegeFavoriteID),
	CONSTRAINT [PF_dbo.CollegeFavorite_College] FOREIGN KEY (CollegeID) REFERENCES dbo.College (CollegeID),
	CONSTRAINT [PF_dbo.CollegeFavorite_Party] FOREIGN KEY (PartyID) REFERENCES dbo.Party (PartyID)
);

/*Creat Tables*/
CREATE TABLE StateList (
	StateID	INT	IDENTITY(1,1)	NOT NULL,
	QueryName	NVARCHAR(50)	NOT NULL,
	Name	NVARCHAR(50)	NOT NULL,
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
VALUES (10, 20),
	   (20, 30),
	   (30, 40), 
	   (40, 50), 
	   (50, 60);

INSERT INTO PrivacyList (PrivacyNumber, PrivacyType)
VALUES (1, 'Public'),
	   (2, 'Private, Non-Profit'),
	   (3, 'Private, For-Profit');


/*
INSERT INTO dbo.City (CityName, CityState) VALUES
('SSTarksvill', 'OR'),
('Happy Town', 'VA'),
('Monmouth', 'OR'),
('Iron Man', 'CA'),
('Danials Town', 'WY'),
('Rochelle Land', 'NY'),
('Nathansvill', 'OH'),
('College Town', 'OR'),
('Universityvill', 'WA'),
('Thor City', 'OH'),
('Banner City', 'OR'),
('Portland', 'OR'),
('Oakland', 'CA'),
('Richmond', 'VA'),
('Thanosvill', 'OR'),
('Marvel Town', 'OR'),
('Tony Town', 'CA'),
('Petersburg', 'VA'),
('Hotel', 'CA'),
('Independence', 'OR');
*/

INSERT INTO dbo.College (CityName, StateName, CollegeName, Focus, Accreditor, [Ownership]) VALUES
('SSTarksvill', 'OR', 'SSTark University', 'Math', 'Me baby', '2'),
('Happy Town', 'VA', 'Hard College', 'CS', 'someone else', '3'),
('Monmouth', 'OR', 'Easey School', 'Math', 'Me baby', '1'),
('Iron Man', 'CA', 'Helpful School', 'CS', 'you Mama', '2'),
('Danials Town', 'WY', 'Unhelpful School', 'Math', 'Me baby', '3'),
('Rochelle Land', 'NY', 'HP College', 'CS and Math', 'someone else', '1'),
('Nathansvill', 'OH', 'Micosoft University', 'Math', 'Me baby', '2'),
('College Town', 'OR', 'Yearly University', 'CS', 'someone else', '2'),
('Universityvill', 'WA', 'Monthly College', 'Math', 'Me baby', '3'),
('Thor City', 'OH', 'Weekly School', 'CS and Art', '3oh3', '3'),
('Banner City', 'OR', 'Daily School', 'Math', 'Me baby', '1'),
('Portland', 'OR', 'Lovely School', 'CS', 'someone else', '1'),
('Oakland', 'CA', 'Beautiful University', 'Math', 'Me baby', '2'),
('Richmond', 'VA', 'Pretty College', 'CS', 'so many people', '3'),
('Thanosvill', 'OR', 'Strong School', 'Math', 'Me baby', '1'),
('Marvel Town', 'OR', 'Ellie School', 'CS', 'someone else', '1'),
('Tony Town', 'CA', 'Amanda School', 'Math', 'Me baby', '3'),
('Petersburg', 'VA', 'College College', 'Medical', 'everyone else', '3'),
('Hotel', 'CA', 'Coffee School', 'Math', 'Me baby', '2'),
('Independence', 'OR', 'Heavenly School', 'CS', 'someone else', '1');

INSERT INTO dbo.Party (PartyName, PartyEmail) VALUES
('Nathan Stark', 'nstar@fake.com'),
('Rochelle Simpson', 'rsim@fake.com'),
('Danial Tapia', 'dtapia@fake.com'),
('Amanda Stark', 'astark@fake.com'),
('Ellie Smith', 'esmith@fake.com'),
('Katie Smith', 'ksmith@fake.com'),
('Susan Stark', 'sstark@fake.com'),
('John Stark', 'jstark@fake.com'),
('Kelsey Stark', 'kstark@fake.com'),
('Tyler Stark', 'tstark@fake.com'),
('Mary Barber', 'mbarber@fake.com'),
('Sus Salt', 'ssalt@fake.com'),
('Jack Reacher', 'jreacher@fake.com'),
('Han Solo', 'hsolo@fake.com'),
('Rick Grimes', 'rgrimes@fake.com'),
('Carol Grimes', 'cgrimes@fake.com'),
('Ranger Stark', 'rstark@fake.com'),
('Kat Willaims', 'kwillaims@fake.com'),
('Scott Morse', 'smorse@fake.com'),
('Rob Simpson', 'rsimpson@fake.com');

INSERT INTO dbo.CollegeFavorite (CollegeID, PartyID) VALUES
('1' ,'2'),
('3' ,'2'),
('4' ,'2'),
('1' ,'1'),
('13' ,'1'),
('5' ,'3'),
('7' ,'6'),
('15' ,'20'),
('11' ,'12'),
('19' ,'9'),
('14' ,'16'),
('1' ,'11'),
('5' ,'11'),
('4' ,'8'),
('11' ,'18'),
('12' ,'2');



