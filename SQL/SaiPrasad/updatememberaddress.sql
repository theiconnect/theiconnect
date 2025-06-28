
create table Memeber(
Mid_pk int not null primary key identity(1,1),
mname varchar(256))

create table Maddress(
ma_id_pk int not null primary key identity(1,1),
Mid_fk int
constraint FK_Maddress_Memeber foreign key (Mid_fk) references Memeber (Mid_pk),
Line1 varchar(200),
Line2 varchar(200),
city varchar(200),
state varchar(200),
pincode varchar(50),
Type char(1))

select * from Maddress 

declare @memberid int 
declare @membername varchar(50) = 'Sai'

	--set @memberid = 1
declare 
		@PersonAddressLine1 varchar(256)='raidurg',
		@PersonAddressLine2 varchar(256)='hitech city road',
		@percity varchar(256)= 'hyderabad',
		@perAddstate varchar(256) = 'ts',
		@personpin  varchar(256)='500012',

		@presAddLine1  varchar(256) = 'gonegandla',
		@presAddLine2  varchar(256) = 'ymgr',
		@presAddcity    varchar(256)='kurnool',
		@presAddstate   varchar(256) ='AP',
		@presAddpin  varchar(256)= '518463'
	
	if @memberid > 0
	begin
		print 'valid number there is a chance of a member with this id'
		if (exists(select * from Memeber where Mid_pk = @memberid ))
		begin
			update Memeber
			set mname = @membername
			where Mid_pk = @memberid
		end
		else
		begin
			insert into Memeber
            values(@membername)
		end

    end
		else if @memberid <= 0
		begin
			print 'inavalid id'
		return;
		  
		end
		else if @memberid is null
		begin
			print 'this is a new member'
			--insert - Member
			insert into Memeber
            values(@membername)
		end
	    
        
    SET @memberid = SCOPE_IDENTITY();

if (Exists(select * from Maddress where Mid_fk = @memberid and type = 1))
-- Insert permanent address
begin
    update Maddress 
	set Line1  = @PersonAddressLine1,
	Line2 = @PersonAddressLine2,
	city = @percity,
	state = @percity,
	pincode = @personpin
	where Mid_fk = @memberid
end

else
begin
	INSERT INTO Maddress (Mid_fk, Line1, Line2, city, state, pincode, Type)
    VALUES (@memberid,@PersonAddressLine1, @PersonAddressLine2, @percity, @perAddstate, @personpin, 1);
end


if (Exists(select * from Maddress where Mid_fk = @memberid and type = 2))
-- Insert permanent address
begin
    update Maddress 
	set Line1  = @presAddLine1,
	Line2 = @presAddLine2,
	city = @presAddcity,
	state = @presAddstate,
	pincode = @presAddpin
	where Mid_fk = @memberid
end

else
begin
	INSERT INTO Maddress (Mid_fk, Line1, Line2, city, state, pincode, Type)
    VALUES (@memberid, @presAddLine1, @presAddLine2, @presAddcity, @presAddstate,@presAddpin,2);
end
   
    
	select * from Memeber
    SELECT * FROM Maddress;
	
	/*@memberid = null => New member
	@memberid > 0 => possibly existing member so update 
	@memberid other => invalid Id input and stop the execution
	*/

	delete from Memeber
	delete from Maddress*/
	

