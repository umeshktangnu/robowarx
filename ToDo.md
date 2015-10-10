# Introduction #

RoboWarX is very incomplete. This is a to-do list in wiki form, to replace the original README. Hopefully, this helps track things a bit better, and maybe even cross reference to useful info for whoever wants to tackle an item.

Items suffixed with bold names are being worked on by that person.


# The list #

  * Interrupts - **Stéphan** (half-assed implementation in trunk)
  * Weapons
    * TacNukes
    * Mines
    * Lasers _(undocumented, thus low prio)_
    * Drones _(undocumented, thus low prio)_
  * Editors
    * Hardware editor
    * Source code editor
      * Source code highlighting
  * Operators
    * BEEP
    * ICON
    * PRINT
    * DEBUG
    * SND
    * MRB _(undocumented, thus low prio)_
  * Registers (besides weapons listed above)
    * CHANNEL
    * HISTORY
    * SIGNAL
    * _(To be written: others?)_
  * Debugger
    * Jump to source
    * Interactive stepping
    * Runtime stack and register inspection
  * Sounds
  * Icons
  * GTK+ GUI polish
  * Windows GUI polish (and may also be outdated in general, at the moment)
  * A Mac OS X native interface?
  * Refactoring
    * Consistent naming _(suggest we use CamelCase in line with the rest of .NET, --Stéphan)_
    * Move the drawing code out of LibRoboWarX, thus removing the System.Drawing dependency.
  * FIXMEs in the code