SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1, N'����� �� ����', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (2, N'������', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (3, N'�������', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (4, N'���������', 3)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO