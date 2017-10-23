Controls:

W or up arrow: acceleration.
S or down arrow: accelerate backwards.
A or left arrow: rotate left.
D or right arrow: rotate right.

space bar: fire bullets.

Assets:

the ship is the same as the one you gave us for the test exercise, the asteroid sprites were made by me.

Above & Beyond:

I made a verry simple boss fight, it's verry unbalanced, and making it led me to make some verry sloppy code.

I had orignally planned for the figth to work by having a series of nodes that the boss would move between, and that it would pick which node to move to by the nodes depending on the players position. I scrapped the idea after I realised that screen wrapping bullets would defeate the purpose of the idea.

The way the boss works is it has a radius in which it will avoid the player and bullets. If neither the player or any of the players bullets are in this area the boss will then make sure it is not with in a specified distance from any edge of the map. (In testing the boss would avoid bullets untill it reached the wrapped around the edge of the map, where it would stay and the player would be able to shoot bullets which would wrap into the boss). After avoiding bullets and making sure its not at the edge of the map the boss will shoot a set number of bullets at the player and then wait a set amount of time, durring this set amount of time the boss will not move. Both the set amount of shots and the wait between these volleys were added to make the boss easier. Despite all of this the boss is still pretty anoying.
