package SelfChatDisable
{
	function NMH_Type::send(%this)
	{
		%msg = %this.getValue();
		if(%msg $= "/toggleselfchat")
		{
			if(!$Pref::Client::SelfChatDisabled)
			{
				$Pref::Client::SelfChatDisabled = 1;
				messageClient(%cl,'',"\c6You've \c0disabled \c6your ability to chat. Use the command again to enable it.");
			}
			else
			{
				$Pref::Client::SelfChatDisabled = 0;
				messageClient(%cl,'',"\c6You've \c2enabled \c6your ability to chat. Use the command again to disable it.");
			}
		}
		
		if($Pref::Client::SelfChatDisabled == 1)
			return messageClient(%cl,'',"\c0You can't talk because you've muted yourself! \c6Use \c3/toggleselfchat \c6to allow talking.");
		
		parent::send(%this);
	}
};
activatePackage(SelfChatDisable);