﻿CREATE TABLE [dbo].[Expenses]
(
	[ID] BIGINT NOT NULL PRIMARY KEY DEFAULT 0, 
    [NAME] TEXT NULL, 
    [VALUE] FLOAT NOT NULL DEFAULT 0, 
    [DATE] DATE NOT NULL
)
