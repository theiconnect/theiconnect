SELECT
    DATENAME(dw, GETDATE()) AS CurrentDay,
    DAY(GETDATE()) AS CurrentDate,
    YEAR(GETDATE()) AS CurrentYear,
	DATEPART(hour,GetDate())AS hour,
	DATENAME(mm, GETDATE()) AS MONTH,
	DATEPART(minute, GETDATE()) AS CurrentMinute,
    FORMAT(GETDATE(), 'dddd') AS AmPm,
    SYSDATETIMEOFFSET() AS TimeZone

SELECT
	DAY(GETDATE()) AS CurrentDate,
	DATEPART(mm,GETDATE()) AS Month,
    right(cast(YEAR(GETDATE()) as varchar), 2) AS CurrentYear,
	DATEPART(hour,GetDate())AS hour,
	DATEPART(minute, GETDATE()) AS CurrentMinute,
	FORMAT(GETDATE(), 'tt') AS AmPm,
    SYSDATETIMEOFFSET() AS TimeZone

	--select DATEPART(y, getdate())

	select convert(varchar, getdate(), 100)
	union select convert(varchar, getdate(), 101)
	union select convert(varchar, getdate(), 102)
	union select convert(varchar, getdate(), 103)
	union select convert(varchar, getdate(), 104)
	union select convert(varchar, getdate(), 105)
	union select convert(varchar, getdate(), 106)
	union select convert(varchar, getdate(), 107)
	union select convert(varchar, getdate(), 108)


select Eomonth('2025-06-11')
select datediff(yy,getdate(),'18-nov-2001')


begin
	declare @nofy varchar,@Dob varchar,@currentdate int,@nofmonth int,@nofday int
	set @Dob = '2001-11-18'
	set @currentdate = getdate()
	set @nofy=datediff(yy,@Dob,@currentdate)
	set @nofmonth=datediff(mm,@Dob,@currentdate)
	set @nofday=datediff(dd,@Dob,@currentdate)
	if  month(@Dob) > month(@currentdate)
	begin
		set @nofy=@nofy-1
		
	end
print @nofy
end

	




