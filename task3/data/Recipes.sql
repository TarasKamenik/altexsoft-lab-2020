SET IDENTITY_INSERT [dbo].[Recipes] ON 
GO
INSERT [dbo].[Recipes] ([Id], [Name], [CategoryId], [Description]) VALUES (1, N'шашлык из свинины', 2, N'вкусный и сочный шашлык из свинины')
GO
INSERT [dbo].[Recipes] ([Id], [Name], [CategoryId], [Description]) VALUES (2, N'шашлык из говядины', 2, N'вкусный и сочный шашлык из говядины')
GO
INSERT [dbo].[Recipes] ([Id], [Name], [CategoryId], [Description]) VALUES (3, N'стейк', 1, N'рецепт сочного и невероятно вкусного стейка из говядины средней прожарки (медиум)')
GO
INSERT [dbo].[Recipes] ([Id], [Name], [CategoryId], [Description]) VALUES (4, N'мороженое с клубникой', 4, N'вкусное и ароматное белое мороженое с клубникой')
GO
INSERT [dbo].[Recipes] ([Id], [Name], [CategoryId], [Description]) VALUES (5, N'мороженое с шоколадом', 4, N'вкусное и ароматное белое мороженое с шоколадом')
GO
INSERT [dbo].[Recipes] ([Id], [Name], [CategoryId], [Description]) VALUES (6, N'десерт из творога с бананом и шоколадом', 3, N'очень простой и вкусный десерт')
GO
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO