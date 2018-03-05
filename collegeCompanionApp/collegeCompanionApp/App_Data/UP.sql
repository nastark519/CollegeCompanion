


CREATE TABLE dbo.City
(
	[CityID] INT IDENTITY(1,1) NOT NULL,
	[CityName] VARCHAR(45) NOT NULL,
	[CityState] VARCHAR(45) NOT NULL,
	CONSTRAINT [PK_dbo.City] PRIMARY KEY (CityID)
);

CREATE TABLE dbo.College
(
	[CollegeID] INT IDENTITY(1,1) NOT NULL,
	[CityID] INT NOT NULL,
	[CollegeName] NVARCHAR (200) NOT NULL,
	CONSTRAINT [PK_dbo.College] PRIMARY KEY (CollegeID),
	CONSTRAINT [PF_dbo.College_City] FOREIGN KEY (CityID) REFERENCES dbo.City (CityID)
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

INSERT INTO dbo.College (CityID, CollegeName) VALUES
('1', 'SSTark University'),
('3', 'Hard College'),
('2', 'Easey School'),
('5', 'Helpful School'),
('6', 'Unhelpful School'),
('4', 'HP College'),
('7', 'Micosoft University'),
('8', 'Yearly University'),
('9', 'Monthly College'),
('10', 'Weekly School'),
('11', 'Daily School'),
('12', 'Lovely School'),
('13', 'Beautiful University'),
('14', 'Pretty College'),
('15', 'Strong School'),
('16', 'Ellie School'),
('17', 'Amanda School'),
('18', 'College College'),
('19', 'Coffee School'),
('20', 'Heavenly School');

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



