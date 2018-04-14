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

DROP TABLE FinLimitList;