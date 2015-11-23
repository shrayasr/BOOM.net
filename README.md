# ಇಟ್ಕೋ
> **itko** is the Kannada word for _Keep_

This is a clone of @holman's [BOOM](https://github.com/holman/BOOM) in .NET written in C#

Commands:

Show available buckets with the number of keys in them

    $ itko 

Creates <bucket> if it doesn't exist or lists out the contents of it if it does.

    $ itko <bucket> 

Creates the <key> under <bucket> with <value>

    $ itko <bucket> <key> <value>

Prints out the value for the <key> under the <bucket>

    $ itko <bucket> <key>

Delete <bucket> and all its keys

    $ itko delete <bucket>

Delete <key> in <bucket>

    $ itko delete <bucket> <key>

Prints everything

    $ itko all

---

Written on a lazy, rainy, Sunday evening in Chennai.
