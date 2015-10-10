# Introduction #

Here, I sit down and take a moment to explain how one of the simplest weapons in RoboWarX, the missile, is implemented.


# Plugins #

In order to explain how things work, it's best to follow the code path taken by RoboWarX.

Because weapons are implemented in a modular fashion, the very first thing RoboWarX does is look for plugins implementing weapons. This is done by loading .NET assemblies ending in “.dll” which are located in the same directory as RoboWarX itself.

We then look for classes implementing the RoboWarX.IPluginEntry interface, instantiate them and call the “getPrototypes” method. Registers follow the prototype design pattern, which means simply that we take an object and clone it when we need another copy. (This should probably be phased out, because .NET reflection is more powerful.)

In the Missile code, an implementation of a plugin's entry point boils down to this short piece of code:

```
public class MissileEntry : IPluginEntry
{
    public ITemplateRegister[] getPrototypes()
    {
        MissileRegister missile = new MissileRegister();
        return new ITemplateRegister[] { missile };
    }
}
```

Here, we create a MissileRegister, which is our prototype object. The game clones this object whenever it needs another instance of MissileRegister. Then we return an array of all our prototypes, which in this case is just the single object.

Registers are loaded in this fashion by the compiler, to get a sense of which registers are valid and what their binary representation is, and by the virtual machine, to actually execute the code.


# Register class #

The register classes are required to implement the RoboWarX.ITemplateRegister interface, but in reality most often use the RoboWarX.Arena.Register abstract class for convenience instead. Here's the head of the missile class's declaration:

```
internal class MissileRegister : Register
{
    internal MissileRegister() { 
        name = "MISSILE"
        code = (Int16)Bytecodes.REG_MISSILE;
    }

    [...]
}
```

First thing to note is that both the class itself and it's constructor are internal. Only the MissileEntry class really needs access to those, so they can be kept internal to the same plugin assembly.

There are two important properties of register must always set as seen here, these are the “name” property, which contains register's name as it appears in the code, and the “code” property, which contains the register's binary representation, as it appears in the compiled program.

Moving on down we find the “value” accessors:

```
public override Int16 value
{
    get
    {
        return 0;
    }

    set
    {
        if (!robot.hardware.hasMissiles)
            throw new HardwareException(this.robot, "Missiles not enabled.");
        int power = robot.useEnergy(value);
        if (power > 0)
            robot.shoot(typeof(MissileObject), power);
    }
}
```

The “get” accessor here is called whenever a register is dereferenced. In this example, a robot executing “MISSILE” would simply push 0 to it's stack.

The “set” accessor is called whenever a register is STORE'd to. In the case of missiles, we check whether the robot's hardware has missiles enabled. Once we've confirmed that, we spend some of the robot's energy, the amount written to the register to be precise. The robot's “useEnergy” method will return how much energy of the specified amount we are actually at liberty to use.

If all turns out well and we have some energy to spend, then we tell the robot to fire a MissileObject class. The robot's “shoot” method sees to it that a RoboWarX.Arena.Projectile subclass gets instantiated with the proper parameters, which include coordinates, angle and who owns the projectile. The “shoot” method takes any additional parameters you'd like to pass to the new MissileObject.

**To be written: write up about interrupts and parameter register.**


# Projectile class #

**To be written**