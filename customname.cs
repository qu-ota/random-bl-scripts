//
//Custom Shapename (Script_CustomName)
//By Dominoes (37977)
//Host only command to set one's shape name, includes function for use in add-ons like Port's eval
//

function serverCmdSetCustomName(%client, %input, %input2)
{
	if(%client.isHost)
	{	
		%target = findclientbyname(%input);
		
		if(!isObject(%target.player) || !isObject(%target))
			return messageClient(%client,'',"\c6That user either doesn't exist or is not alive.");
		
		%newname = strReplace(%input2,"_"," ");
		
		%target.player.setShapeName(%newname SPC "(" @ %target.name @ ")", 8564862);
		%target.player.ShapeName = %newname SPC "(" @ %target.name @ ")";
		
		messageClient(%target,'',"\c4" SPC %client.name SPC "\c6has set your shape name to \c4" @ %newname @ "\c6, and will reset if you die.");
		messageClient(%client,'',"\c6You have set \c4" @ %target.name @ "\c6's shape name to \c4" @ %newname @ "\c6.");
	}
	else
	{
		return messageClient(%client,'',"\c6You do not have access to this command.");
	}
}

function serverCmdRemoveCustomName(%client, %input)
{
	if(%client.isHost)
	{
		%target = findclientbyname(%input);
		
		if(!isObject(%target.player) || !isObject(%target))
			return messageClient(%client,'',"\c6That user either doesn't exist or is not alive.");
		
		%target.player.setShapeName(%target.name, 8564862);
		%target.player.ShapeName = %target.name;
		
		messageClient(%target,'',"\c4" SPC %target.name SPC "\c6has removed your custom name.");
		messageClient(%client,'',"\c6You have successfully removed \c6" @ %target.name @ "\c6's custom name.");
	}
	else
	{
		return messageClient(%client,'',"\c6You do not have access to this command.");
	}
}