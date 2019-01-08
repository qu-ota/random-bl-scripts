$remapDivision[$remapCount]	= "Rapid Clicker & Rapid Fire";
$remapName[$remapCount]		= "Toggle Rapid Clicker";
$remapCmd[$remapCount]		= "rapidClick";
$remapCount++;

$remapName[$remapCount]		= "Toggle Rapidfire";
$remapCmd[$remapCount]		= "rapidFirev2";
$remapCount++;


function rapidClick(%value)
{
	if(%value)
		rapidClickFunc();
	else
	{
		cancel($RapidClick::Schedule);
		mouseFire(0);
	}
}

function rapidFirev2(%value)
{
	if(!isObject(serverConnection.getControlObject().getMountedImage(0)))
		return;
	
	if(%value)
		rapidFireFunc();
	else
		cancel($RapidFire::Schedule);
}

function rapidClickFunc()
{
	$mvTriggerCount0 = !$mvTriggerCount0;
	commandToServer('activateStuff');
	$RapidClick::Schedule = schedule(32,0,rapidClickFunc);
}

function rapidFireFunc()
{
	scrollTools(1);
	scrollTools(-1);
	$RapidFire::Schedule = schedule(40,0,rapidFireFunc);
}