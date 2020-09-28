declare @CategoryId int;
set @CategoryId = 3;

with Categories_CTE(CategoryId, ParentCategoryId, CategoryName, CategoryPath)
AS
(
	select c.Id, c.ParentCategoryId, c.Name, cast(c.Name as nvarchar(max)) + '\' as CategoryPath
	from Categories c
	where c.Id = @CategoryId
	union all
	select c.Id, c.ParentCategoryId, c.Name, CategoryPath + cast(c.Name as nvarchar(max)) + '\'
	from Categories c
	inner join Categories_CTE cc on cc.CategoryId = c.ParentCategoryId
)

select x.Id as RecipeId, x.Name as RecipeName, ri.IngredientId, i.Name as IngredientName, x.CategoryId, x.CategoryPath
from ( select top 3 r.Id, r.Name, c.CategoryId, c.CategoryPath
	from Recipes r
	inner join Categories_CTE c on c.CategoryId = r.CategoryId
	order by c.CategoryPath) x
left join RecipeIngredients ri on ri.RecipeId = x.Id
left join Ingredients i on ri.IngredientId = i.Id