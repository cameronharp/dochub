param([switch]$h, [switch]$help, [switch]$i, [switch]$init)

if($h -or $help)
{
    Write-Host
    Write-Host "Dochub Help"
    Write-Host "---------------------"
    Write-Host "  -i|-init      Initializes the project"
    Write-Host "  -h|-help      Displays this view"
    Write-Host

    return
}

if($i -or $init)
{
    # would call C#

    dotnet.exe build -c Release "tools\src\Dochub.Console"

    dotnet.exe .\"tools\src\Dochub.Console\bin\Release\netcoreapp2.0\Dochub.Console.dll" -init

    return
}