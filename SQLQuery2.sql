SELECT SUM(r1.OwnPrice) AS Price FROM (
SELECT co.CustomerID, SUM(oe.OwnPrice) AS Price
FROM (OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
INNER JOIN CustomerOrder co ON o.OrderID = co.OrderID
WHERE oe.TypeID = 19 AND oe.Number = '456'
GROUP BY co.CustomerID
ORDER BY Price DESC
) r1 
WHERE r1.CustomerID = '111'