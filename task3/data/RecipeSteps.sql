SET IDENTITY_INSERT [dbo].[RecipeSteps] ON 
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (1, 1, 1, N'порезать мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (2, 1, 2, N'замариновать мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (3, 1, 3, N'пожарить мясо на углях')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (4, 2, 1, N'порезать мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (5, 2, 2, N'замариновать мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (6, 2, 3, N'пожарить мясо на углях')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (7, 3, 1, N'приготовить мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (8, 3, 2, N'посолить и поперчить мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (9, 3, 3, N'пожарить мясо')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (10, 4, 1, N'порезать клубнику')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (11, 4, 2, N'посыпать кусочками клубники мороженое')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (12, 5, 1, N'поломать шоколад')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (13, 5, 2, N'посыпать кусочками шоколада мороженое')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (14, 6, 1, N'порезать банан')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (15, 6, 2, N'поломать шоколад')
GO
INSERT [dbo].[RecipeSteps] ([Id], [RecipeId], [Order], [Description]) VALUES (16, 6, 3, N'перемешать творог с бананом и шоколадом')
GO
SET IDENTITY_INSERT [dbo].[RecipeSteps] OFF
GO