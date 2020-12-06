USE HealthMinister
GO

DELETE TOP(100) FROM dbo.Directorates 
WHERE GovID IN (SELECT ID FROM Governorates WHERE Gov_Name = 'Muscat')

-- Insert the data after test:
--SET IDENTITY_INSERT [dbo].[Directorates] ON
--INSERT [dbo].[Directorates] ([ID], [WPlace], [GovID], [Dir_Name]) VALUES (8, N'049da3fe-662b-4293-a43b-a1e238cba517', 1, N'Eyad')
--INSERT [dbo].[Directorates] ([ID], [WPlace], [GovID], [Dir_Name]) VALUES (9, N'7f69dfc9-02b8-4484-8d71-c404c49e15ce', 1, N'Mohanned')
--SET IDENTITY_INSERT [dbo].[Directorates] OFF
