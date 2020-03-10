SELECT SUM(OwnPrice) AS numPrice
                                                     FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                     INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID) 
                                                     WHERE (c.CustomerID = 111) AND (oe.Number = '456') AND (oe.TypeID = 25)