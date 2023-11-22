DROP TABLE IF EXISTS ProductsCategories 
DROP TABLE IF EXISTS Products 
DROP TABLE IF EXISTS Categories

IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name='Goods')
CREATE DATABASE Goods

CREATE TABLE Products
(
    product_id INT IDENTITY PRIMARY KEY,
    product_name NVARCHAR(50) NOT NULL
)
CREATE TABLE Categories
(
    category_id INT IDENTITY PRIMARY KEY,
    category_name NVARCHAR(50) NOT NULL
)

CREATE TABLE ProductsCategories
( 
    product_id int NOT NULL,
    category_id int NOT NULL,
    PRIMARY KEY (product_id, category_id),

    CONSTRAINT fk_person_id FOREIGN KEY (product_id) REFERENCES Products(product_id),
    CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES Categories(category_id)
)

INSERT INTO Categories (category_name) VALUES('food')
INSERT INTO Categories (category_name) VALUES('book')
INSERT INTO Categories (category_name) VALUES('sport')
INSERT INTO Categories (category_name) VALUES('car')
INSERT INTO Categories (category_name) VALUES('tech')

INSERT INTO Products (product_name) VALUES('tesla')
INSERT INTO Products (product_name) VALUES('sport magazine')
INSERT INTO Products (product_name) VALUES('apple')
INSERT INTO Products (product_name) VALUES('football')
INSERT INTO Products (product_name) VALUES('cook book')

--
INSERT INTO Categories (category_name) VALUES('moto')
INSERT INTO Products (product_name) VALUES('blue tractor')
--

INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='tesla'), (SELECT category_id FROM Categories WHERE category_name='car'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='tesla'), (SELECT category_id FROM Categories WHERE category_name='tech'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='sport magazine'), (SELECT category_id FROM Categories WHERE category_name='book'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='sport magazine'), (SELECT category_id FROM Categories WHERE category_name='sport'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='apple'), (SELECT category_id FROM Categories WHERE category_name='food'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='apple'), (SELECT category_id FROM Categories WHERE category_name='tech'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='football'), (SELECT category_id FROM Categories WHERE category_name='sport'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='cook book'), (SELECT category_id FROM Categories WHERE category_name='food'))
INSERT INTO ProductsCategories (product_id, category_id) 
    VALUES((SELECT product_id FROM Products WHERE product_name='cook book'), (SELECT category_id FROM Categories WHERE category_name='book'))


SELECT Products.product_name as product, Categories.category_name as category
FROM Products
    LEFT JOIN ProductsCategories ON Products.product_id=ProductsCategories.product_id
    LEFT JOIN Categories ON ProductsCategories.category_id=Categories.category_id