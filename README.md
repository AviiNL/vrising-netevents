# NetEvents

# Using the Git Hook

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
