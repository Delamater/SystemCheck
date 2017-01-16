SELECT 
	@@SPID, 
	SYSTEM_USER, 
	USER, 
	NULL,		-- LogStart
	GETDATE(),	--LogEnd
	IS_SRVROLEMEMBER('sysadmin')
