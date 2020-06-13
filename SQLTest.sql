--Вариант, когда связь между таблицами неявная
--Создание таблицы Category
create table dbo.Category
(ID INT IDENTITY NOT NULL,
  name nvarchar(500) null)
insert into dbo.Category (name) values ('Электроинструмент'),('Ручной инструмент'),('Деревообработка')

--Создание таблицы Product
 create table dbo.Product
 (ID INT IDENTITY NOT NULL,
  product_name nvarchar(500) null,
  categories nvarchar(500) null)
  
  Insert into dbo.Product (product_name, categories) values ('Электролобзик', '13'),
															('Электрорубанок','13'),
															('Мультитул','2'),
															('УШМ', '1'),
															('Ручной лобзик', '2'),
															('Шуруповёрт','1'),
															('Фрезер','13'),
															('Наждачная бумага','3'),
															('Гравер','1'),
															('Респиратор',NULL)
  
select * from dbo.Product nolock

--Создание временной таблицы для итогового запроса
declare @Final table (prodname nvarchar(500), catname nvarchar(500))

--Создание временной таблицы с ID продуктов
declare @Prodids table (id int)
insert into @Prodids
select Id from dbo.Product nolock
declare @Prodid int


while exists (select 1 from @Prodids)
begin
    select top 1 @Prodid = id from @Prodids
		--Создание временной таблицы с ID категорий
		declare @Catids table (id int)
		insert into @Catids
		select Id from dbo.Category nolock
		declare @Catid int
		if ((select categories from dbo.product nolock
			where id = @Prodid) is NULL)
			begin 
				insert into @Final 
				select product_name, 'Нет категории' from dbo.Product nolock 
				where id = @Prodid
			end
		else
			while exists (select 1 from @Catids)
			begin
				select top 1 @Catid = id from @Catids 
				insert into @Final
					select product_name
					,(select name from dbo.Category nolock  where id = @Catid) 
					from dbo.Product 
					where id = @Prodid 
					and categories like '%'+(select convert(NVARCHAR(500),@Catid))+'%' 
				delete from @Catids where id = @Catid
			end
		delete from @Prodids where id = @Prodid
end

select prodname as 'Товар', catname as 'Категория'  from @Final

-- Ещё один способ решения данной задачи 
-- создание пар ключ-значение, отдельной таблицы с мэппингом ID, а потом написание простого запроса через JOINы

--Создание таблицы Categoryv2
create table dbo.Categoryv2
(ID INT IDENTITY NOT NULL,
  name nvarchar(500) null, 
  constraint PK_category_Id primary key(id))
insert into dbo.Categoryv2 (name) values ('Электроинструмент'),('Ручной инструмент'),('Деревообработка')

--Создание таблицы Productv2
 create table dbo.Productv2
 (ID INT IDENTITY NOT NULL,
  product_name nvarchar(500) null,
  categories nvarchar(500) null,
  constraint PK_product_Id primary key(id)
  )
  
  Insert into dbo.Productv2 (product_name) values	('Электролобзик'),
													('Электрорубанок'),
													('Мультитул'),
													('УШМ'),
													('Ручной лобзик'),
													('Шуруповёрт'),
													('Фрезер'),
													('Наждачная бумага'),
													('Гравер'),
													('Респиратор')
--select * from dbo.product
--создание таблицы с мэппингом
create table dbo.ProductCategoryMapping (productId int not null,
										categoryId int not null,
										constraint FK_ProductCategoryMapping_productID FOREIGN KEY(productId) references dbo.Productv2 (id),
										constraint FK_ProductCategoryMapping_categoryID FOREIGN KEY(categoryId) references dbo.Categoryv2 (id)
										)

insert into dbo.ProductCategoryMapping (productID,categoryID) values (1,1),
																	 (1,3),
																	 (2,1),
																	 (2,3),
																	 (3,2),
																	 (4,1),
																	 (5,2),
																	 (6,1),
																	 (7,1),
																	 (7,3),
																	 (8,3),
																	 (9,1)


select p.product_name as 'Товар', ISNULL(c.name,'Нет категории') as 'Категория'  from dbo.Productv2 p
left join dbo.ProductCategoryMapping pcm on p.id = pcm.productId
left join dbo.Categoryv2 c on pcm.categoryId =c.ID
