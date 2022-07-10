# NetEvents

## Work in Progress

This project is an active work in progress.

The end goal of this project is to wrap every network event in an easy to use C# Event API.

## Using the Git Hook

Copy/Paste `.env.example` to `.env` and change the variable to your unhollowed directory

Copy the `hooks/post-merge` file to `.git/hooks/post-merge`

> **NOTE:** `.git` is a hidden directory, make sure to have Show Hidden Files enabled.

Or use git bash:
```
cp hooks/post-merge .git/hooks/post-merge
```

The first time after performing the above steps, you need to manually run the hook:

In Git bash, from the project root folder run:
```
.git/hooks/post-merge
```

## Building

If all is well, the project should build without errors.

Start the server.


## Notes
`App.cs` is included mainly for testing purposes, in a final build as library it should not be included.


# Copyright

The intended goal for this project is a Library that can be included in other projects. However I will not hold it against you if you prefer to cherry-pick features from this project to be included into your own projects to avoid the need for a dependency.
