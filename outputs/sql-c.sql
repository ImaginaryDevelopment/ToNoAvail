-- test if isnull should be inside or outside the sum
select c.id, isnull(sum(cost*quantity),0)
from Customer c
join Order o
on o.customerid = c.custid
    -- should test if this should be getutcdate()

left join orderLine ol on o.orderid = ol.ordId
-- https://stackoverflow.com/questions/19227964/sql-last-6-months
where o.orderdate >= Dateadd(Month, Datediff(Month, 0, DATEADD(m, -6, GETDATE())), 0)
group by c.id
-- if between doesn't compile or doesn't have include/exclude as desired, use this
-- having isnull(sum(cost*quantity),0) > 100 and isnull(sum(cost*quantity), 0) > 500
having isnull(sum(cost*quantity),0) between 100 and 500
