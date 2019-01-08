package canKill
{
    function minigameCanDamage(%a, %b)
    {
        if (%a.canKill)
            return 1;
        return parent::minigameCanDamage(%a, %b);
    }
};
activatePackage(canKill);