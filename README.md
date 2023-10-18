
A port of https://github.com/SebLague/Neural-Network-Experiments without the reliance on
Unity. Just the raw neural network code so I can cross-reference output values with my
own implementation. This would be useful for anyone creating a nerual network based off
Sebastian's [YouTube video on *How to Create a Neural Network (and Train it to Identify
Doodles)*](https://www.youtube.com/watch?v=hfMk-kjRv4c).

For example, I wrote a [neural network implementation in
Zig](https://github.com/MadLittleMods/zig-ocr-neural-network) and not seeing the same
training results as demonstrated in the video so it's nice to be able to spot potential
bugs by comparing output values or cost gradient values.


## Pre-requisites

 1. [Download and install the .NET Core
    SDK](https://dotnet.microsoft.com/en-us/download) for your platform (tested with
    .NET 6). For me this looked like the following:
    ```sh
    $ cd ~/Downloads/
    $ wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
    $ chmod +x ./dotnet-install.sh
    $ ./dotnet-install.sh
    dotnet-install: Attempting to download using aka.ms link https://dotnetcli.azureedge.net/dotnet/Sdk/6.0.415/dotnet-sdk-6.0.415-linux-x64.tar.gz
    dotnet-install: Remote file https://dotnetcli.azureedge.net/dotnet/Sdk/6.0.415/dotnet-sdk-6.0.415-linux-x64.tar.gz size is 186298830 bytes.
    dotnet-install: Extracting zip from https://dotnetcli.azureedge.net/dotnet/Sdk/6.0.415/dotnet-sdk-6.0.415-linux-x64.tar.gz
    dotnet-install: Downloaded file size is 186298830 bytes.
    dotnet-install: The remote and local file sizes are equal.
    dotnet-install: Installed version is 6.0.415
    dotnet-install: Adding to current process PATH: `/home/eric/.dotnet`. Note: This change will be visible only when sourcing script.
    dotnet-install: Note that the script does not resolve dependencies during installation.
    dotnet-install: To check the list of dependencies, go to https://learn.microsoft.com/dotnet/core/install, select your operating system and check the "Dependencies" section.
    dotnet-install: Installation finished successfully.
    ```
 1. [Update your `$PATH` environment
    variable](https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#set-environment-variables-system-wide)
    so you can access `dotnet` from the CLI:
    `.bashrc`
    ```sh
    # For .NET dotnet, C# (csharp)
    # https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#set-environment-variables-system-wide
    export DOTNET_ROOT=~/.dotnet
    # export MSBuildSDKsPath=$DOTNET_ROOT/sdk/$(${DOTNET_ROOT}/dotnet --version)/Sdks
    export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
    ```

## Building and running

Tested with .NET 6.

```sh
$ dotnet run
```
