# itko

This is a clone of @holman's [BOOM](https://github.com/holman/BOOM) in .NET written in C#

Commands:

Shows available lists with the number of keys in them

    $ itko

Creates the list <list> if it doesn't exist or lists out the contents of it if
it does.

    $ itko <list>

Creates the <key> under the list <list> with value <value>

    $ itko <list> <key> <value>

Prints out the value for the <key> under the <list>

    $ itko <list> <key>

Delete list <list> and all its keys

    $ itko delete <list>

Delete key <key> in <list>

    $ itko delete <list> <key>

List everything

    $ itko all

---

Written on a lazy, rainy, Sunday evening in Chennai.
