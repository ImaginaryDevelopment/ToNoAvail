-- test if isnull should be inside or outside the sum
select c.id, isnull(sum(cost*quantity),0)
from Customer c
left join Order o
on o.customerid = c.custid
    -- https://stackoverflow.com/questions/19227964/sql-last-6-months
    -- should test if this should be getutcdate()
    and o.orderdate >= Dateadd(Month, Datediff(Month, 0, DATEADD(m, -6, GETDATE())), 0)
left join orderLine ol on o.orderid = ol.ordId
group by c.id
