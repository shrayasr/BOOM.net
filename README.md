# BOOM.net

This is a clone of @holman's [BOOM](https://github.com/holman/BOOM) in .NET written in C#

Commands:

Shows available lists with the number of keys in them

    $ boom.net

Creates the list <list> if it doesn't exist or lists out the contents of it if
it does.

    $ boom.net <list>

Creates the <key> under the list <list> with value <value>

    $ boom.net <list> <key> <value>

Prints out the value for the <key> under the <list>

    $ boom.net <list> <key>

Delete list <list> and all its keys

    $ boom.net delete <list>

Delete key <key> in <list>

    $ boom.net delete <list> <key>

List everything

    $ boom.net all

---

Written on a lazy, rainy, Sunday evening in Chennai.
