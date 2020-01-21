
SELECT r1.Page,SUM(r1.Price) AS Price FROM (
	SELECT co.CustomerID, co.Page, oe.Price
	FROM (OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
	INNER JOIN CustomerOrder co ON o.OrderID = co.OrderID
	WHERE oe.TypeID = 19 AND oe.Number = '123'
) r1 
WHERE r1.CustomerID = '111'
GROUP BY r1.Page
