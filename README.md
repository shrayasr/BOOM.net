# ಇಟ್ಕೋ
> **itko** is the Kannada word for _Keep_

This is a clone of @holman's [BOOM](https://github.com/holman/BOOM) in .NET
written in C#

## Demo

![itko demo gif](http://i.imgur.com/PvU095n.gifv)

## Commands

Show available buckets with the number of keys in them

    $ itko 

Creates `<bucket>` if it doesn't exist or lists out the contents of it if it
does.

    $ itko <bucket> 

Creates the `<key>` under `<bucket>` with `<value>`

    $ itko <bucket> <key> <value>

Prints out the value for the `<key>` under the `<bucket>` and copies it to the
clipboard

    $ itko <bucket> <key>

Prefix a `.` before a `<key>` to print out the value for `<key>` under **all**
buckets and copy it to the clipboard. In case of matching keys, the latest
one is retained.

    $ itko .<key>

Delete `<bucket>` and all its keys

    $ itko delete <bucket>

Delete `<key>` in `<bucket>`

    $ itko delete <bucket> <key>

Prints everything

    $ itko all

---

Written on a lazy, rainy, Sunday evening in Chennai.
