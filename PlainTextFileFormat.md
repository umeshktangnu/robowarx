# Introduction #
This is just a stub for an article that could contain more general information on the plain-text file format.

# Hardware Specifiers #
Plain-text files may be annotated with hardware specifiers. These are pre-processor directives of the form:
```
   #!!hardware name: value
```
The valid names are expressed in the following table
|NAME|TYPE|
|:---|:---|
|energyMax|integer|
|damageMax|integer|
|shieldMax|integer|
|processorSpeed|integer|
|gunType|None|Rubber|Normal|Explosive|
|hasMissiles|boolean|
|hasTacNukes|boolean|
|hasLasers|boolean|
|hasHellbores|boolean|
|hasDrones|boolean|
|hasMines|boolean|
|hasStunners|boolean|
|noNegEnergy|boolean|
|probeFlag|boolean|
|deathIconFlag|boolean|
|collisionIconFlag|boolean|
|shieldHitIconFlag|boolean|
|hitIconFlag|boolean|
|shieldOnIconFlag|boolean|

Integers may be any positive integer.
Booleans should be the string "true" or "false".
Pipes(|) delimit multiple choices for a type.