function serverCmdRespawn(%client, %input)
{
	if(%client.isAdmin)
	{
		%target = findclientbyname(%input);
		if(isObject(%target))
		{
			%target.instantrespawn();
			announce("\c2" @ %target.name SPC "\c6has been respawned by\c2" SPC %client.name @ "\c6.");
		}
		else
		{
			messageClient(%client,'',"\c6Invalid player.");
		}
	}
	else
	{
		messageClient(%client,'',"\c6You do not have permission to use this command.");
	}
}