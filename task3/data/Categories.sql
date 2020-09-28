SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (1, N'Блюда из мяса', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (2, N'Шашлык', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (3, N'Десерты', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (4, N'Мороженое', 3)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO