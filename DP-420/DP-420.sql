-- Child Properties
SELECT p.name,
    p.categoryName AS category,
    { "price": p.price } AS scannerData
FROM products p
WHERE p.price >= 50 AND p.price <= 100

--IS_DEFINED
--IS_ARRAY
--IS_NULL
--IS_NUMBER
--IS_STRING
