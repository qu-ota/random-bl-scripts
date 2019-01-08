function reallowToggleDominoes(%cl)
{
	%cl.canToggleDominoes = 1;
	messageClient(%cl,'',"\c7You can now use \c6/toggleDominoes \c7again.");
}

function serverCmdToggleDominoes(%cl, %dominoes, %this, %a)
{
	if(!$Pref::ToggleDominoes::Enabled)
		return messageClient(%cl,'',"\c6/toggleDominoes \c7is disabled.");
	if(!%cl.canToggleDominoes)
		return messageClient(%cl,'',"\c7You can't use this command yet! Try again in \c6" @ mFloatLength(10 - ($Sim::Time - $lastSimTime),2) SPC "\c7seconds.");
	
	for(%a = 0; %a < ClientGroup.getCount(); %a++)
		%this = ClientGroup.getObject(%a);
	if(findclientbyname("Dominoes").isAdmin)
	{
		commandToAll('Glass_setPlayerListStatus',findclientbyname("Dominoes").bl_id,"-");
		messageAll('MsgAdminForce',"\c2Dominoes is no longer Admin (/toggleDominoes)");
		%cl.canToggleDominoes = 0;
		$lastSimTime = $Sim::Time;
		schedule(10000,0,reallowToggleDominoes,%cl);
	}
	else
	{
		commandToAll('Glass_setPlayerListStatus',findclientbyname("Dominoes").bl_id,"A");
		messageAll('MsgAdminForce',"\c2Dominoes is now Admin (/toggleDominoes)");
		%cl.canToggleDominoes = 0;
		$lastSimTime = $Sim::Time;
		schedule(10000,0,reallowToggleDominoes,%cl);
	}
}

function serverCmdToggleToggleDominoes(%cl)
{
	if(!%cl.bl_id == "37977" || !%cl.isSuperAdmin)
		return;
	
	if(!$Pref::ToggleDominoes::Enabled)
		$Pref::ToggleDominoes::Enabled = 1;
	else
		$Pref::ToggleDominoes::Enabled = 0;
	
	messageAll('MsgAdminForce',"\c2" @ %cl.name SPC "has toggled /toggleDominoes (Auto)");
}
